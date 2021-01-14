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
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace BeerStoreProject
{
    class DBSQL : DbAccess
    {
        public DBSQL(string connectionString)
            : base(connectionString)
        {
        }
        // ****** CUSTOMERS ******

        public void InsertCustomer(Customers cust) //insert customer to the table
        {
            string cmdStr = "INSERT INTO [costumer] (fname,lname,ID,address,mail,phone_number,amount) VALUES(@Customer_FirstName,@Customer_LastName,@Customer_id,@Customer_Address,@Customer_Email,@Customer_PhoneNo,@Customer_amount)";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {

                command.Parameters.AddWithValue("@fname", cust.Customer_FirstName);
                command.Parameters.AddWithValue("@lname", cust.Customer_LastName);
                command.Parameters.AddWithValue("@ID", cust.Customer_id);
                command.Parameters.AddWithValue("@address", cust.Customer_Address);
                command.Parameters.AddWithValue("@mail", cust.Customer_Email);
                command.Parameters.AddWithValue("@phone_number", cust.Customer_PhoneNo);
                command.Parameters.AddWithValue("@amount", cust.Customer_amount);
                base.ExecuteSimpleQuery(command);
            }
        }

        public void UpdateCustomer(Customers cust) //update customer in the table
        {
            string cmdStr = "UPDATE [costumer] SET fname=@Customer_FirstName,lname=@Customer_LastName,ID=@updCustId,address=@Customer_Address,mail=@Customer_Email,phone_number=@Customer_PhoneNo,amount=@Customer_amount WHERE ID =" + cust.Customer_id + "";
            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {

                command.Parameters.AddWithValue("@fname", cust.Customer_FirstName);
                command.Parameters.AddWithValue("@lname", cust.Customer_LastName);
                command.Parameters.AddWithValue("@Customer_Id", cust.updCustId);
                command.Parameters.AddWithValue("@address", cust.Customer_Address);
                command.Parameters.AddWithValue("@mail", cust.Customer_Email);
                command.Parameters.AddWithValue("@phone_number", cust.Customer_PhoneNo);
                command.Parameters.AddWithValue("@amount", cust.Customer_amount);
                base.ExecuteSimpleQuery(command);
            }
        }

        public void RemoveCustomer(int id) // Remove customer from the table
        {
            string cmdStr = "DELETE FROM [costumer] WHERE ID =" + id + "";
            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                base.ExecuteSimpleQuery(command);
            }
        }

        public Customers[] getCustomerById(int id) //returns customer by his id
        {
            DataSet ds = new DataSet();
            ArrayList custarr = new ArrayList();
            string cmdStr = "Select * From [customer] Where Customer_id=" + id;

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();
            try
            {
                dt = ds.Tables[0];
            }
            catch { }
            foreach (DataRow tType in dt.Rows)
            {
                Customers customer = new Customers();

                customer.Customer_FirstName = tType[1].ToString();
                customer.Customer_LastName = tType[2].ToString();
                customer.Customer_Address = tType[3].ToString();
                customer.Customer_Email = tType[4].ToString();
                customer.Customer_PhoneNo = int.Parse(tType[5].ToString());
                customer.Customer_amount = int.Parse(tType[6].ToString());

                custarr.Add(custarr);
            }
            return (Customers[])custarr.ToArray(typeof(Customers));
        }

        public Customers[] getAllCustomers() //returns all the customers in the table
        {
            DataSet ds = new DataSet();
            ArrayList custarr = new ArrayList();
            Customers cust = new Customers();
            string cmdStr = "SELECT * FROM costumer";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();

            try
            {
                dt = ds.Tables[0];
            }
            catch
            {
            }
            foreach (DataRow tType in dt.Rows)
            {
                Customers customer = new Customers();

                customer.Customer_id = int.Parse(tType[0].ToString());
                customer.Customer_FirstName = tType[1].ToString();
                customer.Customer_LastName = tType[2].ToString();
                customer.Customer_Address = tType[3].ToString();
                customer.Customer_Email = tType[4].ToString();
                customer.Customer_PhoneNo = int.Parse(tType[5].ToString());
                customer.Customer_amount = int.Parse(tType[6].ToString());

                custarr.Add(customer);
            }
            return (Customers[])custarr.ToArray(typeof(Customers));
        }

        public Customers[] GetCustomerNameOnly() //returns customer by his name
        {
            DataSet ds = new DataSet();
            ArrayList cust = new ArrayList();
            string cmdStr = "Select fname From [costumer]";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();

            try
            {
                dt = ds.Tables[0];
            }
            catch { }
            foreach (DataRow tType in dt.Rows)
            {
                Customers Name = new Customers();

                Name.FirstName = tType[0].ToString();

                cust.Add(Name);
            }
            return (Customers[])cust.ToArray(typeof(Customers));
        }

        public Customers[] GetCustomerEmailOnly() //returns customer by his email
        {
            DataSet ds = new DataSet();
            ArrayList cust = new ArrayList();
            string cmdStr = "Select mail From [costumer]";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();

            try
            {
                dt = ds.Tables[0];
            }
            catch { }
            foreach (DataRow tType in dt.Rows)
            {
                Customers email = new Customers();

                email.Customer_Email = tType[0].ToString();

                cust.Add(email);
            }
            return (Customers[])cust.ToArray(typeof(Customers));
        }

        public int GetCustomerIdByEmail(string mail) //return customer ID by his email
        {
            string cmdStr = "SELECT ID FROM [costumer] WHERE mail=" + "'" + mail + "'";
            int result;
            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                result = ExecuteScalarIntQuery(command);
            }
            return result;
        }

        public order[] GetCustomerNameByEmail(string mail) //return customer NAME by his email
        {
            DataSet ds = new DataSet();
            ArrayList ord = new ArrayList();
            string cmdStr = "SELECT fname FROM [costumer] WHERE mail=" + "'" + mail + "'";
            
            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();

            try
            {
                dt = ds.Tables[0];
            }

            catch { }

            foreach (DataRow tType in dt.Rows)
            {
                order email = new order();

                email.customer_email = tType[0].ToString();

                ord.Add(email);
            }
            return (order[])ord.ToArray(typeof(order));
        }

        public Customers[] GetCustomerIDOnly() //returns Customer IDs
        {
            DataSet ds = new DataSet();
            ArrayList cust = new ArrayList();
            string cmdStr = "Select ID From [costumer]";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();

            try
            {
                dt = ds.Tables[0];
            }
            catch { }
            foreach (DataRow tType in dt.Rows)
            {
                Customers Name = new Customers();

                Name.Customer_FirstName = tType[0].ToString();

                cust.Add(Name);
            }
            return (Customers[])cust.ToArray(typeof(Customers));
        }


        // ****** SUPPLIERS ******
        public void InsertSupplier(suppliers sup) //insert Supplier to the table
        {
            string cmdStr = "INSERT INTO [suppliers] (name,Address,phone,email) VALUES(@Name,@Address,@phone,@email)";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                command.Parameters.AddWithValue("@Name", sup.Sup_name);
                command.Parameters.AddWithValue("@Address", sup.Address);
                command.Parameters.AddWithValue("@phone", sup.Phone);
                command.Parameters.AddWithValue("@email", sup.Email);

                base.ExecuteSimpleQuery(command);
            }
        }

        public void UpdateSupplier(suppliers sup) //updates supplier in the table
        {
            string cmdStr = "UPDATE [suppliers] SET name=@Sup_name,address=@Address,phone=@Phone,email=@Email WHERE supplier_id =" + sup.Supplier_id;

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                command.Parameters.AddWithValue("@name", sup.Sup_name);
                command.Parameters.AddWithValue("@address", sup.Address);
                command.Parameters.AddWithValue("@phone", sup.Phone);
                command.Parameters.AddWithValue("@email", sup.Email);

                base.ExecuteSimpleQuery(command);
            }
        }

        public void RemoveSupplier(string sName) //removes supplier from the table
        {
            string cmdStr = "DELETE FROM [suppliers] WHERE name =" + "'" + sName + "'";
            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                base.ExecuteSimpleQuery(command);
            }
        }

        public int getSupplierIdByName(string name) //returns supplier id by his name
        {
            int result;
            string cmdStr = "SELECT supplier_id FROM [suppliers] WHERE name=" + "'" + name + "'";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                result = ExecuteScalarIntQuery(command);
            }
            return result;
        }   

        public suppliers[] getAllsuppliers() //returns all the suppliers in the table
        {
            DataSet ds = new DataSet();
            ArrayList supparr = new ArrayList();
            string cmdStr = "SELECT * FROM suppliers";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();

            try
            {
                dt = ds.Tables[0];
            }
            catch
            {
            }
            foreach (DataRow tType in dt.Rows)
            {
                suppliers supp = new suppliers();

                supp.Supplier_id = int.Parse(tType[0].ToString());
                supp.Sup_name = tType[1].ToString();
                supp.Address = tType[2].ToString();
                supp.Phone = int.Parse(tType[3].ToString());
                supp.Email = tType[4].ToString();
                

                supparr.Add(supp);
            }
            return (suppliers[])supparr.ToArray(typeof(suppliers));
        }

        public suppliers[] GetSupplierNameOnly() //returns supplier names
        {
            DataSet ds = new DataSet();
            ArrayList sup = new ArrayList();
            string cmdStr = "Select Name From [suppliers]";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();

            try
            {
                dt = ds.Tables[0];
            }
            catch { }
            foreach (DataRow tType in dt.Rows)
            {
                suppliers Name = new suppliers();

                Name.Sup_name = tType[0].ToString();

                sup.Add(Name);
            }
            return (suppliers[])sup.ToArray(typeof(suppliers));
        }


        // ****** PRODUCTS ******
        public void InsertProduct(product prod) //insert product to the table
        {
            string cmdStr = "INSERT INTO [products] (prod_name,prod_description,prod_rank,prod_amount,prod_price,Supplier_Id) VALUES(@prod_name,@prod_description,@prod_rank,@prod_amount,@prod_price,@Supplier_Id)";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                command.Parameters.AddWithValue("@prod_name", prod.ProductName);
                command.Parameters.AddWithValue("@prod_description", prod.Productdescription);
                command.Parameters.AddWithValue("@prod_rank", prod.ProductRank);
                command.Parameters.AddWithValue("@prod_amount", prod.Amount);
                command.Parameters.AddWithValue("@prod_price", prod.Price);
                command.Parameters.AddWithValue("@Supplier_Id", prod.supplier_Id);
                base.ExecuteSimpleQuery(command);
            }
        }

        public void UpdateProduct(product prod) //updates product in the table
        {
            string cmdStr = "UPDATE [products] SET prod_name=@ProductName,prod_description=@prod_description,prod_rank=@prod_rank,prod_amount=@prod_amount,prod_price=@prod_price,Supplier_Id=@supplier_Id WHERE product_id =" + prod.ID;
            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {

                command.Parameters.AddWithValue("@prod_name", prod.ProductName);
                command.Parameters.AddWithValue("@prod_description", prod.Productdescription);
                command.Parameters.AddWithValue("@prod_rank", prod.ProductRank);
                command.Parameters.AddWithValue("@prod_amount", prod.Amount);
                command.Parameters.AddWithValue("@prod_price", prod.Price);
                command.Parameters.AddWithValue("@Supplier_Id", prod.supplier_Id);
                base.ExecuteSimpleQuery(command);
            }
        }

        public void RemoveProduct(string pName) //removes product from the table
        {
            string cmdStr = "DELETE FROM [products] WHERE name =" + "'" + pName + "'";
            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                base.ExecuteSimpleQuery(command);
            }
        }

        public int GetProductNumber() //return product number
        {
            int result;
            string cmdStr = "SELECT COUNT (*) FROM products";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                result = ExecuteScalarIntQuery(command);
            }
            return result;
        }

        public product[] getAllproducts() //returns all the products in the table
        {
            DataSet ds = new DataSet();
            ArrayList Productsarr = new ArrayList();
            string cmdStr = "SELECT * FROM products";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();

            try
            {
                dt = ds.Tables[0];
            }
            catch
            {
            }
            foreach (DataRow tType in dt.Rows)
            {
                product Prod = new product();

                Prod.ID = int.Parse(tType[0].ToString());
                Prod.ProductName = tType[1].ToString();
                Prod.Productdescription = tType[2].ToString();
                Prod.ProductRank = int.Parse(tType[3].ToString());
                Prod.Amount = int.Parse(tType[4].ToString());
                Prod.Price = int.Parse(tType[5].ToString());
                Prod.supplier_Id = int.Parse(tType[6].ToString());

                Productsarr.Add(Prod);
            }
            return (product[])Productsarr.ToArray(typeof(product));
        }

        public product[] GetproductNameOnly() //returns only product name
        {
            DataSet ds = new DataSet();
            ArrayList prod = new ArrayList();
            string cmdStr = "Select prod_name From [products]";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();

            try
            {
                dt = ds.Tables[0];
            }
            catch { }
            foreach (DataRow tType in dt.Rows)
            {
                product Name = new product();

                Name.ProductName = tType[0].ToString();

                prod.Add(Name);
            }
            return (product[])prod.ToArray(typeof(product));
        }

        public product[] getproductById(int id) //returns product by his id
        {
            DataSet ds = new DataSet();
            ArrayList prodarr = new ArrayList();
            string cmdStr = "Select * From [products] Where product_id=" + id;

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();
            try
            {
                dt = ds.Tables[0];
            }
            catch { }
            foreach (DataRow tType in dt.Rows)
            {
                product prod = new product();

                prod.ID = int.Parse(tType[0].ToString());
                prod.ProductName = tType[1].ToString();
                prod.Productdescription = tType[2].ToString();
                prod.ProductRank = int.Parse(tType[3].ToString());
                prod.Amount = int.Parse(tType[4].ToString());
                prod.Price = int.Parse(tType[5].ToString());
                prod.supplier_Id = int.Parse(tType[6].ToString());
                prodarr.Add(prod);
            }
            return (product[])prodarr.ToArray(typeof(product));
        }

        public product[] GetproductIDOnly() //returns product ID only
        {
            DataSet ds = new DataSet();
            ArrayList prod = new ArrayList();
            string cmdStr = "Select product_id From [products]";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();

            try
            {
                dt = ds.Tables[0];
            }
            catch { }
            foreach (DataRow tType in dt.Rows)
            {
                product Name = new product();

                Name.ID = int.Parse(tType[0].ToString());

                prod.Add(Name);
            }
            return (product[])prod.ToArray(typeof(product));
        }

        public DataTable getproductTable() //returns all the product table
        {
            DataSet ds = new DataSet();

            string cmdStr = "SELECT * FROM products";
            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            return ds.Tables[0];
        }

        public int getproductIdByName(string name) //returns product id by his name
        {
            int result;
            string cmdStr = "SELECT product_id FROM [product] WHERE prod_name=" + "'" + name + "'";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                result = ExecuteScalarIntQuery(command);
            }
            return result;
        }   

        public product[] gettAllProductsSupplierByID(int id) //returns all products suppliers by products id
        {
            DataSet ds = new DataSet();
            ArrayList prodarr = new ArrayList();
            string cmdStr = "Select * From [products] Where Supplier_id=" + id;

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();
            try
            {
                dt = ds.Tables[0];
            }
            catch { }
            foreach (DataRow tType in dt.Rows)
            {
                product prod = new product();

                prod.ID = int.Parse(tType[0].ToString());
                prod.ProductName = tType[1].ToString(); 
                prod.Productdescription = tType[2].ToString();
                prod.prod_rank = int.Parse(tType[3].ToString());
                prod.Amount = int.Parse(tType[4].ToString());
                prod.Price = int.Parse(tType[5].ToString());
                prod.supplier_Id = int.Parse(tType[6].ToString());

                prodarr.Add(prod);
            }
            return (product[])prodarr.ToArray(typeof(product));
        }


        // ****** orders ******
        public order[] getAllorders() //returns all the orders in the table
        {
            DataSet ds = new DataSet();
            ArrayList ordersarr = new ArrayList();
            string cmdStr = "SELECT * FROM order";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();

            try
            {
                dt = ds.Tables[0];
            }
            catch
            {
            }
            foreach (DataRow tType in dt.Rows)
            {
                order order = new order();

                order.Order_num = int.Parse(tType[0].ToString());
                order.customer_id = int.Parse(tType[1].ToString());
                order.Product_id = int.Parse(tType[2].ToString());
                order.amount = int.Parse(tType[3].ToString());
                order.Sum_pay = int.Parse(tType[4].ToString());
                order.customer_email = tType[5].ToString();
                ordersarr.Add(order);
            }
            return (order[])ordersarr.ToArray(typeof(order));
        }

        public void InsertOrder(order ord) // inserts order to the table
        {
            string cmdStr = "INSERT INTO [order] (Customer_Id,Product_Id,Amount,sum_pay,Customer_email) VALUES(@Customer_id,@product_id,@Amount,@sum_pay,@Customer_email)";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                command.Parameters.AddWithValue("@customer_Id", ord.customer_id);
                command.Parameters.AddWithValue("@Product_Id", ord.Product_id);
                command.Parameters.AddWithValue("@Amount", ord.amount);
                command.Parameters.AddWithValue("@sum_pay", ord.Sum_pay);
                command.Parameters.AddWithValue("@Customer_email", ord.customer_email);
                
                base.ExecuteSimpleQuery(command);
            }
        }

        public order[] getAllOrdersByCustomerName(string email) //returns all orders by customer name
        {
            DataSet ds = new DataSet();
            ArrayList orderarr = new ArrayList();
            string cmdStr = "Select * From [order] Where Customer_email=" + "'" + email + "'";

            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();
            try
            {
                dt = ds.Tables[0];
            }
            catch { }
            foreach (DataRow tType in dt.Rows)
            {
                order ord = new order();

                ord.Order_num = int.Parse(tType[0].ToString());
                ord.customer_id = int.Parse(tType[1].ToString());
                ord.Product_id =int.Parse( tType[2].ToString());
                ord.amount = int.Parse(tType[3].ToString());
                ord.Sum_pay = int.Parse(tType[4].ToString());
                ord.customer_email = tType[5].ToString();
                
              

                orderarr.Add(ord);
            }
            return (order[])orderarr.ToArray(typeof(order));
        }

    }
}