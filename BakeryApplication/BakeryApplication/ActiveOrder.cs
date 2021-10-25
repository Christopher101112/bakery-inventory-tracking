using System;
namespace BakeryApplication
{
    /**
     * Active order object.
     * This class is used when we need to do more than just display the data.
     * For simply displaying data in UI tables, objects are not created.
     */
    public class ActiveOrder
    {
        //Used to verify that string array passed to constructor is right size.
        const int active_order_field_count = 7; //Update this if new fields added.

        private int active_order_id;
        private int customer_id;
        private int product_id;
        private int product_amount;
        DateTime date_posted;
        DateTime date_needed;
        int order_id_for_user;

        /**
         * Constructor
         * Assigns all object fields based on string array from database query.
         * WARNING: Array order must correspond to assignment order.
         */
        public ActiveOrder(string[] order)
        {
            if (order.Length < active_order_field_count)
            {
                throw new ArgumentException("The string array passed to ActiveOrder constructor is the wrong size.");
            }
            else
            {
                if(!int.TryParse(order[0], out this.active_order_id))
                {
                    throw new ArgumentException("ActiveOrder constructor int.TryParse(active_order_id) failed.");
                }
                if (!int.TryParse(order[1], out customer_id))
                {
                    throw new ArgumentException("ActiveOrder constructor int.TryParse(customer_id) failed.");
                }
                if(!int.TryParse(order[2], out product_id))
                {
                    throw new ArgumentException("ActiveOrder constructor int.TryParse(product_id) failed.");
                }
                if(!int.TryParse(order[3], out product_amount))
                {
                    throw new ArgumentException("ActiveOrder constructor int.TryParse(product_amount) failed.");
                }
           
                date_posted = DateTime.Parse(order[4]);
                date_needed = DateTime.Parse(order[5]);
  
                if(!int.TryParse(order[6], out order_id_for_user))
                {
                    throw new ArgumentException("ActiveOrder constructor int.TryParse(order_id_for_user) failed.");
                }
            }
        }

        public int GetOrderID()
        {
            return this.active_order_id;
        }

        public int GetIDForUser()
        {
            return this.order_id_for_user;
        }

        public int GetProductID()
        {
            return this.product_id;
        }

        public int GetProductAmt()
        {
            return this.product_amount;
        }

        public DateTime GetDatePosted()
        {
            return this.date_posted;
        }

        public DateTime GetDateNeeded()
        {
            return this.date_needed;
        }

        public int GetCustomerID()
        {
            return this.customer_id;
        }

    }
}
