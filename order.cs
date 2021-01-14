/*
 **********************************************************
 *                                                        *
 * By: Ameer Kassis - Sameer Zaher - Yuri Malamoud - 41/1 *
 *                                                        *
 **********************************************************
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerStoreProject
{
    //Constructor for orders
    class order
    {
        private int order_num;
        public int Customer_id;
        private int product_id;
        private int Amount;
        private int sum_pay;
        public string Customer_email;
        public order()
        {

        }
        public string customer_email
        {
            get
            {
                return Customer_email;
            }
            set
            {
                this.Customer_email = value;
            }
        }

        public int Order_num
        {
            get
            {
                return order_num;
            }
            set
            {
                this.order_num = value;
            }
        }
        public int customer_id
        {
            get
            {
                return Customer_id;
            }
            set
            {
                this.Customer_id = value;
            }
        }
        public int Product_id
        {
            get
            {
                return product_id;
            }
            set
            {
                this.product_id = value;
            }
        }
        public int amount
        {
            get
            {
                return Amount;
            }
            set
            {
                this.Amount = value;
            }
        }
        public int Sum_pay
        {
            get
            {
                return sum_pay;
            }
            set
            {
                this.sum_pay = value;
            }
        }





    }
}
