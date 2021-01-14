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
    //Constructor for Suppliers
    class suppliers
    {
        private int sup_id;
        private string sup_name;
        private string address;
        private int phone;
        private string email;
        public suppliers( int sId,string sName, string saddress, int sphone, string semail)
        {
            sup_id = sId;
            sup_name=sName;
            address=saddress;
            phone=sphone;
            email=semail;
        }
        public suppliers()
        {
        /*
            sup_name = "";
            address = "";
         * */
           
        }
       public int Supplier_id
        {
            set
            {
                this.sup_id = value;
            }
            get
            {
                return this.sup_id;
            }
        }
        public string Sup_name
        {
            set
            {
                this.sup_name = value;

            }
            get
            {
                return this.sup_name;
            }

        }
        public string Address
        {
            set
            {
                this.address = value;

            }
            get
            {
                return this.address;
            }
        }
        public int Phone
        {
            set
            {
                this.phone = value;
            }
            get
            {
                return this.phone;
            }
        }
        public string Email
        {
            set
            {
                this.email = value;
            }
            get
            {
                return this.email;
            }
        }
        
    }
}
