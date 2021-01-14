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

    //Constructor for products
    class product
    {
        
        public int product_id;
        public string prod_name;
        public string prod_description;
        public int prod_rank;
        public int prod_amount;
        public int prod_price;
        public int Supplier_Id;
        
        /*
        public product(string pName, string pdescription, int prank, int pamount, int pprice)
        {
            
           product_id = p_id;
            prod_name = pName;
            prod_description = pdescription;
            prod_rank = prank;
            prod_amount = pamount;
            prod_price = pprice;
            
        }
        */
        
        public product()
        {
            /*
           // product_id = 0;
            prod_name = "";
            prod_description = "";
            */
        }
        public int ID
        {
            set
            {
                product_id = value;
            }
            get
            {
                return product_id;
            }

        }
        
        public string ProductName //current name
        {
            set
            {
                prod_name = value;

            }
            get
            {
                return prod_name;
            }

        }
        public string Productdescription
        {
            set
            {
                prod_description = value;

            }
            get
            {
                return prod_description;
            }
        }
        public int ProductRank
        {
            set
            {
                prod_rank = value;

            }
            get
            {
                return prod_rank;
            }
        }
        public int Amount
        {
            set
            {
                prod_amount = value;

            }
            get
            {
                return prod_amount;
            }
        }
        public int Price
        {
            set
            {
                prod_price = value;

            }
            get
            {
                return prod_price;
            }
        }
       public int supplier_Id
        {
            get
            {
                return this.Supplier_Id;
            }
            set
            {
                this.Supplier_Id = value;
            }
        }
        

    }
}
