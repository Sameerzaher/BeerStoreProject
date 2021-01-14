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
    //Constructor for Customers
    class Customers
    {
        public int Customer_Id;
        public int UpdCustoId;
        public string FirstName;
        public string LastName;
        public int amount;
        public string Address;
        public string Email;
        public int phone_number;

        public Customers(string cFirstName, string cLastName, int camount, string cAddress, string cEmail, int PhoneNo, int cCustomer_Id, int cUpdCustoId)
        {
            this.Customer_Id = cCustomer_Id;//current ID
            this.UpdCustoId = cUpdCustoId;//updating wrong ID
            this.FirstName = cFirstName;
            this.LastName = cLastName;
            this.amount = camount;
            this.Address = cAddress;
            this.Email = cEmail;
            this.phone_number = PhoneNo;
        }

        public Customers()
        {
        }

        public int updCustId //updating wrong ID
        {
            get
            {
                return this.UpdCustoId;
              }
            set
            {
                this.UpdCustoId = value;
            }
        }

        public int Customer_id //current ID
        {
            get
            {
                return this.Customer_Id;
            }
            set
            {
                this.Customer_Id = value;
            }
        }
        public string Customer_FirstName
        {
            get
            {
                return this.FirstName;
            }
            set
            {
                this.FirstName = value;
            }
        }
        public string Customer_LastName
        {
            get
            {
                return this.LastName;
            }
            set
            {
                this.LastName = value;
            }
        }

        public string Customer_Address
        {
            get
            {
                return this.Address;
            }
            set
            {
                this.Address = value;
            }
        }
        public string Customer_Email
        {
            get
            {
                return this.Email;
            }
            set
            {
                this.Email = value;
            }
        }
        public int Customer_PhoneNo
        {
            get
            {
                return this.phone_number;
            }
            set
            {
                this.phone_number = value;
            }
        }
        public int Customer_amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }
    }
}