using System;
using Gtk;
using Gdk;
using System.Collections;
using System.Collections.Generic;
namespace BakeryApplication
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class InventoryPage : Gtk.Bin
    {
        public static InventoryPage inventorypage_instance; //Used as 'this' instance.

        //Declared here to allow editing after build.
        private static Table table_user_input; 
        ListStore store_shipping_history;
        ListStore store_active_orders;
        ListStore store_completed_orders;

        /**
         * WARNING: regarding string lists below:
         *      When adding a new field, update SQL code and database structure accordingly.
         *      Order matters.
         */

        /**
         * The columns for current inventory display table.
         */
        private static List<string> case_types = new List<string>()
        {
            "Original",
            "Buffalo chicken",
            "Donation",
            "Total"
        };

        /**
         * User input fields for updating inventory.
         */
        private static List<string> user_input_fields = new List<string>()
        {
            "Original",
            "Buffalo chicken",
            "Donation",
            "User name",
            "Comments"
        };

        /**
         * Column names for active orders Nodeview. Nodeview dynamically generated from this list.
         */
        private static List<string> active_order_nodeview_cols = new List<string>()
        {
            "Customer",
            "Product",
            "Amount (cases)",
            "Date posted",
            "Date needed",
            "Order ID"
        };

        /**
         * Column names for completed orders Nodeview. Nodeview dynamically generated from this list.
         */
        private static List<string> completed_order_nodeview_cols = new List<string>()
        {
            "Customer",
            "Product",
            "Amount (cases)",
            "Date posted",
            "Date completed",
            "Order ID"
        };

        /**
         * Column names for shipping history Nodeview. Nodeview dynamically generated from this list.
         */
        private static List<string> shipping_history_nodeview_cols = new List<string>()
        {
            "Original",
            "Buffalo chicken",
            "Donation",
            "Total moved",
            "Name",
            "Comments",
            "New inventory total",
            "Date/time",
        };
  
        //Case count totals retrieved from database.
        private static int[] case_counts = new int[case_types.Count];

        //Labels to display above case count totals.
        private static Label[] case_counts_labels = new Label[case_types.Count];

        //Labels to display case type (text) corresponding to case count label.
        private static Label[] case_types_labels = new Label[case_types.Count];

        //Dictionary (C#'s HashMap) to store the latest total values for each column.
        //Key is (case type string name) and value is (case count int).
        private static Dictionary<string, int> case_counts_map = new Dictionary<string, int>();

        //Dictionary (C#'s HashMap) to store the EntryBoxes for each table column.
        private static Dictionary<string, Entry> entry_boxes_map = new Dictionary<string, Entry>();

        public InventoryPage()
        {
            this.Build();
            inventorypage_instance = this;

            //Style labels
            labelCurrentInventory.ModifyFont(StyleGUI.title_font);

            //Style eventboxes
            eventboxLabelCurrent.ModifyBg(StateType.Normal, StyleGUI.dark_grey);
            eventboxMain.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxCurrentInventory.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxNavigation.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxButtonHome.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxButtonUpdate.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxButtonRequestUpdate.ModifyBg(StateType.Normal, StyleGUI.background_color);
            eventboxNotebookHistory.ModifyBg(StateType.Normal, StyleGUI.background_color);

            //Style buttons
            StyleGUI.ButtonSetup(buttonHome);
            buttonHome.ModifyFont(StyleGUI.medium_font);

            //Setup tables
            Table table_current_inventory = new Table(2, (uint)case_types.Count, true);
            table_current_inventory.RowSpacing = 0;
            vboxCurrentInventory.Add(table_current_inventory);
            table_user_input = new Table(2, (uint)user_input_fields.Count, true); //Global
            table_user_input.RowSpacing = 0;
            vboxCurrentInventory.Add(table_user_input);

            //Setup shipping history nodeview
            //Go through column list and make a column for each.
            Type[] shipping_history_data_types = new Type[shipping_history_nodeview_cols.Count]; //Arg for making a "ListStore".
            for (int m=0; m<shipping_history_nodeview_cols.Count; m++)
            {
                TreeViewColumn col = new TreeViewColumn();
                col.Title = shipping_history_nodeview_cols[m].ToString();
                col.MinWidth = 100;
                col.Expand = true;
                this.nodeviewShippingHistory.NodeSelection.NodeView.AppendColumn(col);
               
                CellRendererText cell = new CellRendererText();
                col.PackStart(cell, true);
                col.AddAttribute(cell, "text", m);
                shipping_history_data_types[m] = typeof(string); //To ease ORM code, all fields will be string.
            }
            store_shipping_history = new ListStore(shipping_history_data_types);
            this.nodeviewShippingHistory.NodeSelection.NodeView.Model = store_shipping_history;

            //Setup active orders nodeview.
            //Go through column list and make a column for each.
            Type[] active_order_data_types = new Type[active_order_nodeview_cols.Count];
            for(int n=0; n<active_order_nodeview_cols.Count; n++)
            {
                TreeViewColumn col = new TreeViewColumn();
                col.Title = active_order_nodeview_cols[n].ToString();
                col.MinWidth = 100;
                col.Expand = true;
                this.nodeviewActiveOrders.NodeSelection.NodeView.AppendColumn(col);

                CellRendererText cell = new CellRendererText();
                col.PackStart(cell, true);
                col.AddAttribute(cell, "text", n);
                active_order_data_types[n] = typeof(string);
            }
            store_active_orders = new ListStore(active_order_data_types);
            this.nodeviewActiveOrders.NodeSelection.NodeView.Model = store_active_orders;

            //Setup completed orders nodeview.
            //Go through column list and make a column for each.
            Type[] completed_order_data_types = new Type[completed_order_nodeview_cols.Count];
            for (int l = 0; l < completed_order_nodeview_cols.Count; l++)
            {
                TreeViewColumn col = new TreeViewColumn();
                col.Title = completed_order_nodeview_cols[l].ToString();
                col.MinWidth = 100;
                col.Expand = true;
                this.nodeviewCompletedOrders.NodeSelection.NodeView.AppendColumn(col);

                CellRendererText cell = new CellRendererText();
                col.PackStart(cell, true);
                col.AddAttribute(cell, "text", l);
                completed_order_data_types[l] = typeof(string);
            }
            store_completed_orders = new ListStore(completed_order_data_types);
            this.nodeviewCompletedOrders.NodeSelection.NodeView.Model = store_completed_orders;

            //Setup inventory current table.
            uint i = 0;
            uint j = 1;
            foreach (var column in case_types)
            {
                //Eventboxes for row 1 (headers) of totals display.
                EventBox eventbox = new EventBox(); 
                eventbox.ModifyBg(StateType.Normal, StyleGUI.background_color);
                eventbox.BorderWidth = 5;
                Label label = new Label(column.ToString());
                label.ModifyFont(StyleGUI.large_font_italic);
                eventbox.Add(label);
                case_types_labels[i] = label;
                
                //Eventboxes for row 2 (case count) of totals display.
                EventBox eventbox2 = new EventBox(); 
                eventbox2.ModifyBg(StateType.Normal, StyleGUI.light_grey);
                eventbox2.BorderWidth = 0;
                Label label2 = new Label(case_counts[i].ToString()); //"0" default because case_counts not yet filled.
                label2.ModifyFont(StyleGUI.large_font_italic);
                eventbox2.Add(label2);
                case_counts_labels[i] = label2;

                //Populate each row of table.
                table_current_inventory.Attach(eventbox, i, j, 0, 1); //First row
                table_current_inventory.Attach(eventbox2, i, j, 1, 2); //Second row

                i++;
                j++;
            }

            //Setup user input table.
            uint p = 0;
            uint q = 1;
            foreach (var column in user_input_fields)
            {
                //Eventboxes for row 1 (headers) of user inputs.
                EventBox eventbox = new EventBox();
                eventbox.ModifyBg(StateType.Normal, StyleGUI.background_color);
                eventbox.BorderWidth = 5;
                Label label = new Label(column.ToString());
                label.ModifyFont(StyleGUI.medium_font_italic);
                eventbox.Add(label);

                //Eventboxes for row 2 (entryboxes) of user inputs.
                EventBox eventbox2 = new EventBox();
                eventbox2.ModifyBg(StateType.Normal, StyleGUI.light_grey);
                eventbox2.BorderWidth = 0;
                Entry entry = new Entry();
                entry.WidthRequest = 30;
                entry.ModifyBg(StateType.Normal, StyleGUI.light_grey);
                entry.ModifyBase(StateType.Normal, StyleGUI.light_grey);
                entry_boxes_map.Add(label.Text, entry); //Input field label name is the key, entry box is the value.
                eventbox2.Add(entry);

                //Populate each row of table.
                table_user_input.Attach(eventbox, p, q, 0, 1); //First row
                table_user_input.Attach(eventbox2, p, q, 1, 2); //Second row

                p++;
                q++;
            }
        }

        /**
         * Called when MainWindow's SetPage() sets this page to be displayed.
         */
        public void ActivatePage()
        {
            //Populate case_counts table with current values from database.
            PopulateCaseCounts(); //Current totals
            PopulateInventoryUpdateHistoryNodeview();
            PopulateActiveOrdersNodeview();
            PopulateCompletedOrdersNodeview();
            HideUserupdateUI(); //Only show it upon user request.
            HideActiveOrderUI();
        }

        /**
         * Called when MainWindow's SetPage() sets any other page to be displayed.
         */
        public void DeactivatePage()
        {
            case_counts_map.Clear(); //Will be repopulated upon screen activation.
            ResetUserupdateEntryBoxes(); //Restore user input entryboxes to defaults.
            HideUserupdateUI(); //Restore user input options to defaults.
            HideActiveOrderUI(); 
            ClearInventoryUpdateHistoryNodeview();
            ClearActiveOrdersNodeview();
            ClearCompletedOrdersNodeview();
        }
        
        /**
         * Call to the database for current inventory numbers. 
         * Then display those numbers in the user interface.
         */
        public void PopulateCaseCounts()
        {
            //Clear the display so it can be refilled with updated data.
            case_counts_map.Clear();

            string[] latest_case_counts = PostgreSQL.GetLatestInvTotalsSQL();
            
            for (int i = 0; i < case_counts.Length; i++)
            {
                int.TryParse(latest_case_counts[i], out case_counts[i]); //No check because checked upon database insertion.
                case_counts_labels[i].Text = case_counts[i].ToString(); //Labels to display numbers.
                case_counts_map.Add(case_types_labels[i].Text, case_counts[i]); //Populate map.
            }
        }

        /**
         * Populate the active orders nodeview with current data.
         * Display all such records from the database.
         */
        public void PopulateActiveOrdersNodeview()
        {
            List<string[]> rows = PostgreSQL.GetActiveOrdersForUIDisplay();
            foreach(var row in rows)
            {
                store_active_orders.AppendValues(row);
            }
        }

        /**
         * Populate the completed orders nodeview with current data.
         * Display all such records from the database.
         */
        public void PopulateCompletedOrdersNodeview()
        {
            List<string[]> rows = PostgreSQL.GetCompletedOrdersForUIDisplay();
            foreach(var row in rows)
            {
                store_completed_orders.AppendValues(row);
            }
        }

        /**
         * Populate the inventory update history nodeview with current data.
         * Display all such records from the database.
         */
        public void PopulateInventoryUpdateHistoryNodeview()
        {
            List<string[]> rows = PostgreSQL.GetInventoryUpdateHistoryRows();
            foreach(var row in rows)
            {
                store_shipping_history.AppendValues(row);
            }
        }

        /**
         * Update the inventory update history nodeview with single latest database record.
         * Used to update history table in real time when user makes an update in the application.
         */
        public void UpdateInventoryUpdateHistoryNodeview()
        {
            string[] row = PostgreSQL.GetLatestInventoryUpdateHistoryRow();
            store_shipping_history.AppendValues(row);
        }

        /**
         * Add only the most recent row in completed_order table to the UI display.
         * This rather than calling PopulateCompletedOrdersNodeview() and
         * reloading all completed orders, of which there will eventually be many.
         */
        public void UpdateCompletedOrderNodeview()
        {
            string[] row = PostgreSQL.GetLatestCompletedOrderRowForUIDisplay();
            store_completed_orders.AppendValues(row);
        }

        /**
         * This button shows and hides(depending on its state) active order UI.
         */
        protected void OnButtonRequestOrderCompletionClicked(object sender, EventArgs e)
        {
            if (eventboxActiveOrderUI.Visible)
            {
                HideActiveOrderUI();
            }
            else
            {
                ShowActiveOrderUI();
            }
        }

        /**
         * Hide and restore active order update UI to its defaults.
         */
        protected void HideActiveOrderUI()
        {
            eventboxActiveOrderUI.HideAll();
            entryActiveOrderID.Text = ""; 
            eventboxButtonSubmit.HideAll();
            buttonRequestOrderCompletion.Label = "+ change active order to 'completed'";
            buttonRequestOrderCompletion.Relief = ReliefStyle.None;
            buttonRequestOrderCompletion.UseUnderline = false;
        }

        /**
         * Display active order UI (for changing active order to completed).
         */
        protected void ShowActiveOrderUI()
        {
            eventboxActiveOrderUI.ShowAll();
            eventboxButtonSubmit.ShowAll();
            buttonRequestOrderCompletion.Label = "Cancel";
            buttonRequestOrderCompletion.Relief = ReliefStyle.Normal;
            buttonRequestOrderCompletion.UseUnderline = true;
        }

        /**
         * This button shows and hides (depending on its state) inventory update UI.
         */
        protected void OnButtonRequestUpdateClicked(object sender, EventArgs e)
        {
            if (buttonUpdate.Visible) //User wants to close entry UI.
            {
                HideUserupdateUI(); 
                ResetUserupdateEntryBoxes();
            }
            else if (!buttonUpdate.Visible) //User wants to open entry UI.
            {
                ShowUserupdateUI();
            }
        }

        /**
         * Hide and restore inventory update UI to its default settings.
         */
        protected void HideUserupdateUI()
        {
            table_user_input.HideAll();
            buttonUpdate.Hide();
            buttonRequestUpdate.Label = "+ make an inventory update";
            buttonRequestUpdate.Relief = ReliefStyle.None;
            buttonRequestUpdate.UseUnderline = false;
        }

        /**
         * Display inventory update UI.
         */
        protected void ShowUserupdateUI()
        {
            table_user_input.ShowAll();
            buttonUpdate.Show();
            buttonRequestUpdate.Label = "Close";
            buttonRequestUpdate.Relief = ReliefStyle.Normal;
            buttonRequestUpdate.UseUnderline = true;
        }

        /**
         * Clear the entry boxes of any text or special styling.
         */
        public static void ResetUserupdateEntryBoxes()
        {
            foreach (var pair in entry_boxes_map)
            {
                pair.Value.Text = "";
                pair.Value.ModifyBase(StateType.Normal, StyleGUI.light_grey);
            }
        }

        /**
         * Display success in the user entry fields.
         */
        public static void SuccessUserUpdateEntryBoxes()
        {
            foreach (var pair in entry_boxes_map)
            {
                pair.Value.Text = "success";
                pair.Value.ModifyBase(StateType.Normal, StyleGUI.success_green);
            }
        }

        /**
         * Upon 'Update' click, process contents of entryboxes.
         * Adds these values to update the database if all checks are passed.
         */
        protected void OnButtonUpdateClicked(object sender, EventArgs e)
        {
            //Used to determine whether the SQL insert can be called.
            bool all_user_inputs_valid = true;
      
            //Get user input values, check their validity.
            //The default value of Entry box is empty string.
            int orig_oboy_36; //Param 1
            bool valid_orig_oboy_36_input = int.TryParse(entry_boxes_map["Original"].Text, out orig_oboy_36);
            if (!valid_orig_oboy_36_input)
            {
                all_user_inputs_valid = false;
                entry_boxes_map["Original"].ModifyBase(StateType.Normal, StyleGUI.warning_red);
                entry_boxes_map["Original"].Text += " is an invalid entry.";
            }

            int buff_oboy_36; //Param 2
            bool valid_buff_oboy_36_input = int.TryParse(entry_boxes_map["Buffalo chicken"].Text, out buff_oboy_36);
            if (!valid_buff_oboy_36_input)
            {
                all_user_inputs_valid = false;
                entry_boxes_map["Buffalo chicken"].ModifyBase(StateType.Normal, StyleGUI.warning_red);
                entry_boxes_map["Buffalo chicken"].Text += " is an invalid entry.";
            }

            int donate_oboy_36; //Param 3
            bool valid_donate_oboy_36_input = int.TryParse(entry_boxes_map["Donation"].Text, out donate_oboy_36);
            if (!valid_donate_oboy_36_input)
            {
                all_user_inputs_valid = false;
                entry_boxes_map["Donation"].ModifyBase(StateType.Normal, StyleGUI.warning_red);
                entry_boxes_map["Donation"].Text += " is an invalid entry.";
            }

            string name = entry_boxes_map["User name"].Text; //Param 4
            if (name == "")
            {
                all_user_inputs_valid = false;
                entry_boxes_map["User name"].ModifyBase(StateType.Normal, StyleGUI.warning_red);
                entry_boxes_map["User name"].Text += " is an invalid entry.";
            }

            //No need to check (comments not required).
            string comments = entry_boxes_map["Comments"].Text; //Param 5

            DateTime temp_timestamp = DateTime.Now; //Param 6
            NpgsqlTypes.NpgsqlDateTime timestamp = new NpgsqlTypes.NpgsqlDateTime(temp_timestamp);

            int total = orig_oboy_36 + buff_oboy_36 + donate_oboy_36; //Param 7

            //Process the user input values.
            if (all_user_inputs_valid)
            {
                PostgreSQL.InsertInvUpdateSQL(orig_oboy_36, buff_oboy_36, donate_oboy_36, name, comments, timestamp, total);

                //Based on latest update, update new totals to inventory total table.
                int orig_oboy_36_total = case_counts_map["Original"] + orig_oboy_36;
                int buff_oboy_36_total = case_counts_map["Buffalo chicken"] + buff_oboy_36;
                int donate_oboy_36_total = case_counts_map["Donation"] + donate_oboy_36;
                int total_oboy_36 = case_counts_map["Total"] + total;
                PostgreSQL.InsertInvTotalSQL(orig_oboy_36_total, buff_oboy_36_total, donate_oboy_36_total, total_oboy_36);

                PopulateCaseCounts(); //Display updated numbers.
                SuccessUserUpdateEntryBoxes(); //Display success messages.
                UpdateInventoryUpdateHistoryNodeview(); //Display record (in history nodeview) of the update that just took place.
            }
        }

        /**
         * Return to HomePage. InventoryPage.DeactivateScreen() will be called by MainWindow.
         */
        protected void OnButtonHomeClicked(object sender, EventArgs e)
        {
            MainWindow.SetPage(typeof(HomePage));
        }

        /**
         * Clear all rows from the active orders Nodeview.
         */
        public void ClearActiveOrdersNodeview()
        {
            store_active_orders.Clear();
        }

        /**
         * Clear all rows from the completed orders Nodeview.
         */
        public void ClearCompletedOrdersNodeview()
        {
            store_completed_orders.Clear();
        }

        /**
         * Clear all rows from the update history Nodeview.
         */
        public void ClearInventoryUpdateHistoryNodeview()
        {
            store_shipping_history.Clear();
        }

        /**
         * Change 'active order' to 'completed order' based on order ID input by user.
         */
        protected void OnButtonSubmitClicked(object sender, EventArgs e)
        {
            //Get user input in int form.
            int input = -1; 
            if(!int.TryParse(entryActiveOrderID.Text, out input))
            {
                entryActiveOrderID.Text += (": invalid entry");
            }
            else
            {
                //Check there is an order with that order number.
                string[] arr = PostgreSQL.GetSingleActiveOrderRow(input);
                if (arr.Length == 0)
                {
                    entryActiveOrderID.Text += (": no order found");
                }
                //Change that order from 'active' to 'completed' in the database.
                else
                {
                    ActiveOrder active_order = new ActiveOrder(arr);
                    PostgreSQL.ChangeActiveOrderToCompleted(active_order);
                    entryActiveOrderID.Text += (" (Success_");
                }
                //Update the UI nodeview displays to show this change.
                ClearActiveOrdersNodeview(); //Clear and reload as there are not many active orders.
                PopulateActiveOrdersNodeview();
                UpdateCompletedOrderNodeview(); //Do not clear and reload as there are many completed orders.
            }
        }
    }
}
