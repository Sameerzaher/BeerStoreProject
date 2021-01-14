using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerStoreProject
{
    class products
    {
        private int id;
        private string productName;
        private string productdescription;
        private int productRank;
        private int amount;
        private int price;
        private int Supplier_Id;
        public products(int p_id, string pName, string pdescription, int prank, int pamount, int pprice,int Supplier_Id)
        {
            id=p_id;
            productName=pName;
            productdescription=pdescription;
            productRank=prank;
            amount=pamount;
            price=pprice;
        }
        public products()
        {
            id = 0;
            productName = "";
            productdescription = "";
        }
        public int ID
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }

        }
        public string ProductName
        {
            set
            {
                productName = value;

            }
            get
            {
                return productName;
            }

        }
        public string Productdescription
        {
            set
            {
                productdescription = value;

            }
            get
            {
                return productdescription;
            }
        }
        public int ProductRank
        {
            set
            {
                productRank = value;

            }
            get
            {
                return productRank;
            }
        }
        public int Amount
        {
            set
            {
                amount = value;

            }
            get
            {
                return amount;
            }
        }
        public int Price
        {
            set
            {
                price = value;

            }
            get
            {
                return price;
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
