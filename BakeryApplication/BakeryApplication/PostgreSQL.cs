using System;
using Npgsql;
using System.Collections;
using System.Collections.Generic;


namespace BakeryApplication
{
    /**
     * Provide means to query or write to the database.
     * Any and all SQL code in the application must be located in this class.
     */
    public static class PostgreSQL
    {
        //Must refer to a database that is up and running, and has the right tables, etc.
        public static string connection_string = ""; //Connection string removed for privacy.

        /**
         * Read a single row from the PostgreSQL database.
         * Return a string array representing that row.
         * No parameterization (because query is hard coded, not vulnerable to injection.)    
         */
        private static string[] ReadSingleRowSQL(string SQL_command)
        {
            //Set up connection
            var connection = new NpgsqlConnection(connection_string);
            connection.Open();

            //Create and execute the command.
            var command = new NpgsqlCommand(SQL_command, connection);
            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();

                //Get output row.
                dr.Read();
                string[] row = new string[dr.FieldCount];
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    row[i] = dr[i].ToString();
                }
                //Return connection to the pool for reuse.
                connection.Close();
                return row;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Only reached if there is an error.
            connection.Close();
            string[] empty_array = new string[0];
            return empty_array;
        }

        /**
         * Read multiple rows from SQL query.
         * Return those rows as a list of string arrays.
         * No parameterization (because query is hard coded, not vulnerable to injection.)
         */
        private static List<string[]> ReadMultipleRowsSQL(string SQL_command)
        {
            //Set up connection
            var connection = new NpgsqlConnection(connection_string);
            connection.Open();

            //Create and execute the command.
            var command = new NpgsqlCommand(SQL_command, connection);
            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();

                //Get every row, convert to string array, add to list.
                List<string[]> rows = new List<string[]>();
                while (dr.Read())
                {
                    string[] row = new string[dr.FieldCount];
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        row[i] = dr[i].ToString();
                    }
                    rows.Add(row);
                }
                //Return connection to the pool for reuse.
                connection.Close();
                return rows;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Only reached if there is an error.
            connection.Close();
            List<string[]> empty_list = new List<string[]>();
            return empty_list; 
        }

        /**
         * Insert values into PostgreSQL database.
         * No parameterization (because transaction is hard coded, not vulnerable to injection.)
         */
        private static void WriteSQL(string SQL_command)
        {
            //Set up connection
            var connection = new NpgsqlConnection(connection_string);
            connection.Open();

            //Create and execute the command
            var command = new NpgsqlCommand(SQL_command, connection);
            try
            {
                command.ExecuteNonQuery(); //Insert.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Return connection to the pool for reuse.
            connection.Close();
        }

        /**
         * Perform a SQL query that returns one single value (scalar).
         * For example, SUM(column).
         * No parameterization (because query is hard coded, not vulnerable to injection.).
         */
        private static object ScalarSQL(string SQL_command)
        {
            //Set up connection
            var connection = new NpgsqlConnection(connection_string);
            connection.Open();

            //Create and execute the command
            var command = new NpgsqlCommand(SQL_command, connection);

            try
            {
                var result = command.ExecuteScalar();
                connection.Close();
                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Only reached if there is an error.
            connection.Close();
            object null_object = null;
            return null_object;
        }



        //Hard coded queries and procedures below.
        //Must be changed manually if it becomes necessary to get different attributes.

        /**
         * Retrieve specific fields from inventory_total that will be
         * displayed to users on InventoryPage.
         */
        public static string[] GetLatestInvTotalsSQL()
        {
            //Order matters. Must match case_types in InventoryPage.
            string command =
            "SELECT original_oboys_36, " +
                "buffalo_chicken_oboys_36, " +
                "donate_oboys_36, " +
                "total_oboys_36 " +
            "FROM inventory_total " +
            "WHERE inventory_total_id= " +
                "(SELECT MAX(inventory_total_id) FROM inventory_total)";

            return ReadSingleRowSQL(command);
        }

        /**
         * Insert inventory update row based on user input.
         * Take in params corresponding to database fields.
         * Create a paramerterized command to protect from injection.
         */
        public static void InsertInvUpdateSQL(int orig_oboy_36, int buff_oboy_36, int donate_oboy_36, string name, string comments, NpgsqlTypes.NpgsqlDateTime timestamp, int total)
        {
            //Set up connection
            var connection = new NpgsqlConnection(connection_string);
            connection.Open();

            var command = new NpgsqlCommand("INSERT INTO inventory_update VALUES " +
                                "(DEFAULT, @orig_oboy_36, @buff_oboy_36, @donate_oboy_36, @name, @comments, @timestamp, @total)", connection);
            //Parameterize
            command.Parameters.AddWithValue("orig_oboy_36", orig_oboy_36);
            command.Parameters.AddWithValue("buff_oboy_36", buff_oboy_36);
            command.Parameters.AddWithValue("donate_oboy_36", donate_oboy_36);
            command.Parameters.AddWithValue("name", name);
            command.Parameters.AddWithValue("comments", comments);
            command.Parameters.AddWithValue("timestamp", timestamp);
            command.Parameters.AddWithValue("total", total);

            try
            {
                command.ExecuteNonQuery(); //Insert.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Return connection to the pool for reuse.
            connection.Close();
        }
   
        /**
         * Insert new totals count after any in/out flow of cases.
         * Take in params corresponding to database fields.
         * Create a paramerterized command to protect from injection.
         */
        public static void InsertInvTotalSQL(int orig_oboy_36, int buff_oboy_36, int donate_oboy_36, int total_oboy_36)
        {
            //Set up connection
            var connection = new NpgsqlConnection(connection_string);
            connection.Open();

            var command = new NpgsqlCommand("INSERT INTO inventory_total VALUES" +
                                "(DEFAULT, @orig_oboy_36, @buff_oboy_36, @donate_oboy_36, @total_oboy_36, " +
                                "(SELECT MAX(inventory_update_id) FROM inventory_update))", connection);
            command.Parameters.AddWithValue("orig_oboy_36", orig_oboy_36);
            command.Parameters.AddWithValue("buff_oboy_36", buff_oboy_36);
            command.Parameters.AddWithValue("donate_oboy_36", donate_oboy_36);
            command.Parameters.AddWithValue("total_oboy_36", total_oboy_36);

            try
            {
                command.ExecuteNonQuery(); //Insert.
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Return connection to the pool for reuse.
            connection.Close();
        }

        /**
         * Retrieve specific fields to represent inventory update rows,
         * which will be displayed in a Nodeview (table) to the user to show
         * a complete history of inventory in/out flow.
         */
        public static List<string[]> GetInventoryUpdateHistoryRows()
        {
            string command = "SELECT inventory_update.original_oboys_36, " +
                                    "inventory_update.buffalo_chicken_oboys_36, " +
                                    "inventory_update.donate_oboys_36, " +
                                    "inventory_update.total_cases_added, " +
                                    "inventory_update.user_name, " +
                                    "inventory_update.user_comments, " +
                                    "inventory_total.total_oboys_36, " +
                                    "inventory_update.update_timestamp " +
                             "FROM inventory_update " +
                             "LEFT JOIN inventory_total " +
                             "ON inventory_total.inventory_update_id = inventory_update.inventory_update_id " +
                             "ORDER BY inventory_update.inventory_update_id";

            List<string[]> rows = ReadMultipleRowsSQL(command);
            return rows;
        }

        /**
         * Get the most recent inventory update information.
         */
        public static string[] GetLatestInventoryUpdateHistoryRow()
        {
            string command = "SELECT inventory_update.original_oboys_36, " +
                                    "inventory_update.buffalo_chicken_oboys_36, " +
                                    "inventory_update.donate_oboys_36, " +
                                    "inventory_update.total_cases_added, " +
                                    "inventory_update.user_name, " +
                                    "inventory_update.user_comments, " +
                                    "inventory_total.total_oboys_36, " +
                                    "inventory_update.update_timestamp " +
                             "FROM inventory_update " +
                             "LEFT JOIN inventory_total " +
                             "ON inventory_total.inventory_update_id = inventory_update.inventory_update_id " +
                             "WHERE inventory_update.inventory_update_id = " +
                                    "(SELECT MAX(inventory_update_id) FROM inventory_update) " +
                             "ORDER BY inventory_update.inventory_update_id";
            return ReadSingleRowSQL(command);
        }

        /**
         * Get latest row containing completed order information. 
         */
        public static string[] GetLatestCompletedOrderRowForUIDisplay()
        {
            string command = "SELECT  customer.name, " +
                                     "product.name, " +
                                     "completed_order.product_amount, " +
                                     "completed_order.date_posted, " +
                                     "completed_order.date_completed, " +
                                     "completed_order.order_id_for_user " +
                            "FROM completed_order " +
                            "LEFT JOIN customer " +
                            "ON customer.customer_id = completed_order.customer_id " +
                            "LEFT JOIN product " +
                            "ON product.product_id = completed_order.product_id " +
                            "WHERE completed_order.completed_order_id = " +
                            "(SELECT MAX(completed_order_id) FROM completed_order) " +
                            "ORDER BY completed_order.completed_order_id";
            return ReadSingleRowSQL(command);
        }

        /**
         * Get rows containing active order information. 
         */
        public static List<string[]> GetActiveOrdersForUIDisplay()
        {
            string command = "SELECT  customer.name, " +
                                     "product.name, " +
                                     "active_order.product_amount, " +
                                     "active_order.date_posted, " +
                                     "active_order.date_needed," +
                                     "active_order.order_id_for_user " +
                             "FROM active_order " +
                             "LEFT JOIN customer " +
                             "ON customer.customer_id = active_order.customer_id " +
                             "LEFT JOIN product " +
                             "ON product.product_id = active_order.product_id; ";

            return ReadMultipleRowsSQL(command);
        }

        /**
         * Get rows containing completed order information.
         */
        public static List<string[]> GetCompletedOrdersForUIDisplay()
        {
            string command = "SELECT  customer.name, " +
                                     "product.name, " +
                                     "completed_order.product_amount, " +
                                     "completed_order.date_posted, " +
                                     "completed_order.date_completed, " +
                                     "completed_order.order_id_for_user " +
                            "FROM completed_order " +
                            "LEFT JOIN customer " +
                            "ON customer.customer_id = completed_order.customer_id " +
                            "LEFT JOIN product " +
                            "ON product.product_id = completed_order.product_id ";
            return ReadMultipleRowsSQL(command);
        }

        /**
         * Get active order row attributes, based on the row's primary key.
         */
        public static string[] GetSingleActiveOrderRow(int id)
        {
            //Set up connection
            var connection = new NpgsqlConnection(connection_string);
            connection.Open();

            var command = new NpgsqlCommand("SELECT * FROM active_order " +
                                            "WHERE active_order.order_id_for_user = @param ", connection);
            command.Parameters.AddWithValue("param", id);
            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();
                dr.Read();
                string[] row = new string[dr.FieldCount];
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    row[i] = dr[i].ToString();
                }
                connection.Close();
                return row;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Only reached if there is an error.
            connection.Close();
            string[] empty_array = new string[0];
            return empty_array;
        }

        /**
         * Convert an active order into a completed order in the database.
         * Delete row from active_order table and represent it in completed_order table.
         */
        public static void ChangeActiveOrderToCompleted(ActiveOrder order)
        {
            var connection = new NpgsqlConnection(connection_string);
            connection.Open();

            var command = new NpgsqlCommand("INSERT INTO completed_order(completed_order_id, customer_id, product_id, product_amount, date_posted, date_needed, order_id_for_user, date_completed) " +
                                            "VALUES (DEFAULT, @customer_id, @product_id, @product_amount, @date_posted, @date_needed, @order_id_for_user, @date_completed)" , connection);
            command.Parameters.AddWithValue("customer_id", order.GetCustomerID());
            command.Parameters.AddWithValue("product_id", order.GetProductID()) ;
            command.Parameters.AddWithValue("product_amount", order.GetProductAmt());

            NpgsqlTypes.NpgsqlDateTime date_posted = new NpgsqlTypes.NpgsqlDateTime(order.GetDatePosted());
            command.Parameters.AddWithValue("date_posted", date_posted);

            NpgsqlTypes.NpgsqlDateTime date_needed = new NpgsqlTypes.NpgsqlDateTime(order.GetDateNeeded());
            command.Parameters.AddWithValue("date_needed", date_needed);

            command.Parameters.AddWithValue("order_id_for_user", order.GetIDForUser());

            NpgsqlTypes.NpgsqlDateTime date_completed = new NpgsqlTypes.NpgsqlDateTime(DateTime.Now);
            command.Parameters.AddWithValue("date_completed", date_completed);

            int insert_result = 0;
            try
            {
                insert_result = command.ExecuteNonQuery(); //Should return 1 (num of rows affected).
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Order information was successfully represented in completed_order table,
            //then we can delete it from active_order.
            if (insert_result == 1)
            {
                DeleteActiveOrderRow(order.GetOrderID());
            }
            
            //Return connection to the pool for reuse.
            connection.Close();
        }

        /**
         * Delete a row (if it exists) from active_order table based on primary key.
         */
        public static void DeleteActiveOrderRow(int active_order_id)
        {
            var connection = new NpgsqlConnection(connection_string);
            connection.Open();

            var command = new NpgsqlCommand("DELETE FROM active_order WHERE active_order_id = @active_order_id ", connection);
            command.Parameters.AddWithValue("active_order_id", active_order_id);

            try
            {
                command.ExecuteNonQuery(); //Delete
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            connection.Close();
        }
    }
}
