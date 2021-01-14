/*
 **********************************************************
 *                                                        *
 * By: Ameer Kassis - Sameer Zaher - Yuri Malamoud - 41/1 *
 *                                                        *
 **********************************************************
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BeerStoreProject
{
    public partial class MainFormfrm : Form
    {
        private DBSQL dataB;

        public MainFormfrm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string pathDB = Application.StartupPath + @"\..\..\beerstoreDataBase.accdb";

            if (File.Exists(pathDB))
            {
                dataB = new DBSQL(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathDB + ";Persist Security Info=False;");
               
            }
            else
            {
                MessageBox.Show("DataBase" + pathDB + " not found.");
                Application.Exit();
            }
            try
            {
                makeOrderCusEmailcbo.Items.Clear();
                ProdIDNewordercbo.Items.Clear();
                OrderAmountcbo.Items.Clear();
                OrderSumPricetxt.Text = "0";
                OrderPricePerProdtxt.Enabled = false;
                OrderSumPricetxt.Enabled = false;
                FillSupplier();
                FillProducts();
                FillCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     public void FillProducts() //fills products combo boxes
        {
            product[] prodarr = dataB.getAllproducts();

            for (int i = 0; i < prodarr.Length; i++)
            {
                ProdIDNewordercbo.Items.Add(prodarr[i].ID);
            }
        }
     public void FillCustomer() //fills customers combo boxes
        {
            Customers[] custarr = dataB.GetCustomerEmailOnly();
            for (int i = 0; i < custarr.Length; i++)
            {
                makeOrderCusEmailcbo.Items.Add(custarr[i].Customer_Email);
            }
        }
     public void FillSupplier() 
        {
            suppliers[] supparr = dataB.GetSupplierNameOnly();

            for (int i = 0; i < supparr.Length; i++)
            {
                ProductSuppliercbo.Items.Add(supparr[i].Sup_name);
            }
        }//fills suppliers combo boxes

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {
        }

        private void hiToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void Exitbtn_Click_1(object sender, EventArgs e) //Exit buttons
        {
            Application.Exit();
        }

        private void addProdbtn_Click(object sender, EventArgs e) //buttons to add product
        {


            if (!string.IsNullOrWhiteSpace(prodnametxt.Text) && !string.IsNullOrWhiteSpace(prodpricetxt.Text) && !string.IsNullOrWhiteSpace(prodamounttxt.Text) && !string.IsNullOrWhiteSpace(ProductSuppliercbo.Text) && !string.IsNullOrWhiteSpace(prodranktxt.Text))
            {
                product prodArr = new product();
                prodArr.prod_name = prodnametxt.Text;
                prodArr.prod_description = proddesctxt.Text;
                prodArr.prod_rank = int.Parse(prodranktxt.Text);
                prodArr.prod_amount = int.Parse(prodamounttxt.Text);
                prodArr.prod_price = int.Parse(prodpricetxt.Text);
                prodArr.supplier_Id = dataB.getSupplierIdByName(ProductSuppliercbo.Text);

                try
                {
                    dataB.InsertProduct(prodArr);
                    MessageBox.Show("Success the product is insert");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("One or More Field is Empty");
        }

        private void btnAddSupplier_Click(object sender, EventArgs e) //button to add supplier
        {
            if (!string.IsNullOrWhiteSpace(AddSupplierAddresstxt.Text) && !string.IsNullOrWhiteSpace(AddSupplierNametxt.Text) && !string.IsNullOrWhiteSpace(supplierphonetxt.Text) && !string.IsNullOrWhiteSpace(supplieremailtxt.Text))
            {
                suppliers sup = new suppliers();
                sup.Address = AddSupplierAddresstxt.Text;
                sup.Sup_name = AddSupplierNametxt.Text;
                sup.Email = supplieremailtxt.Text;
                sup.Phone = int.Parse(supplierphonetxt.Text);
                try
                {
                    dataB.InsertSupplier(sup);
                    MessageBox.Show("The Supplier Have Been Sucessfully Inserted");
                }
                catch (Exception)
                {
                    MessageBox.Show("Supplier Name Already Exists");
                }
            }
            else
            {
                MessageBox.Show("One Or More Field Is Empty");
            }
        }

        private void btnaddcustomer_Click(object sender, EventArgs e)//button to add customer
        {
            if (!string.IsNullOrWhiteSpace(customerorderamounttxt.Text) && !string.IsNullOrWhiteSpace(customeridtxt.Text) && !string.IsNullOrWhiteSpace(customerphonenumbertxt.Text) && !string.IsNullOrWhiteSpace(customerFirstNametxt.Text) && !string.IsNullOrWhiteSpace(customerLastNametxt.Text) && !string.IsNullOrWhiteSpace(customerAddresstxt.Text) && !string.IsNullOrWhiteSpace(customerEmailtxt.Text))
            {
                Customers cust = new Customers();
                cust.Customer_FirstName = customerFirstNametxt.Text;
                cust.Customer_LastName = customerLastNametxt.Text;
                cust.Customer_id = int.Parse(customeridtxt.Text);
                cust.Customer_amount = int.Parse(customerorderamounttxt.Text);
                cust.Customer_Address = customerAddresstxt.Text;
                cust.Customer_Email = customerEmailtxt.Text;
                cust.Customer_PhoneNo = int.Parse(customerphonenumbertxt.Text);

                try
                {
                    dataB.InsertCustomer(cust);
                    MessageBox.Show("Success the Customer is insert");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("One or More Field is Empty");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblSupplierEmail_Click(object sender, EventArgs e)
        {

        }

        private void deleteSupplierNamebtn_Click(object sender, EventArgs e) //button to delete supplier
        {
            if (!string.IsNullOrWhiteSpace(deleteSupplierNametxt.Text))
            {
                try
                {
                    dataB.RemoveSupplier(deleteSupplierNametxt.Text);
                    MessageBox.Show("Succesfuly REMOVED supplier");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Supplier Name is empty!! make sure to fill it.");

        }

        private void deleteProductbtn_Click(object sender, EventArgs e) //button to delete product
        {
            if (!string.IsNullOrWhiteSpace(deleteProductNametxt.Text))
            {
                try
                {
                    dataB.RemoveSupplier(deleteProductNametxt.Text);
                    MessageBox.Show("Succesfuly REMOVED Products");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Product Name is empty!! make sure to fill it.");
        }

        private void deleteCustomerbtn_Click(object sender, EventArgs e) //button to delete customer
        {
            if (!string.IsNullOrWhiteSpace(deleteCustomeridtxt.Text))
            {
                try
                {
                    dataB.RemoveCustomer(int.Parse(deleteCustomeridtxt.Text));
                    MessageBox.Show("Succesfuly REMOVED customer");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Customer ID is empty!! make sure to fill it.");

        }

        private void deleteSupplierNametxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e) //button to update supplier
        {
            if (!string.IsNullOrEmpty(txtUpdateSupplierId.Text))
            {
                suppliers sup = new suppliers();

                sup.Sup_name = UpdateSupplierNametxt.Text;
                sup.Address = txtUpdateSupplierAddr.Text;
                sup.Phone = int.Parse(txtUpdateSupplierPhone.Text);
                sup.Supplier_id = int.Parse(txtUpdateSupplierId.Text);
                sup.Email = txtUpdateSupplierEmail.Text;

                try
                {
                    dataB.UpdateSupplier(sup);
                    MessageBox.Show("Success the SUPPLIER is Updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Supplier ID is empty!! make sure to fill it.");
        }

        private void UpdateProductBtn_Click(object sender, EventArgs e) //button to update product
        {
            if (!string.IsNullOrEmpty(UpdateByProductIdtxt.Text) && UpdateByProductIdtxt.Text != "(REQUIRED)")
            {
                product prod = new product();

                prod.prod_name = updateProductNametxt.Text;
                prod.prod_description = updateProductDesctxt.Text;
                prod.prod_rank = int.Parse(updateProductRanktxt.Text);
                prod.prod_amount = int.Parse(updateProductAmounttxt.Text);
                prod.prod_price = int.Parse(updateProductPricetxt.Text);
                prod.supplier_Id = int.Parse(updateProductSupplierIdtxt.Text);
                prod.ID = int.Parse(UpdateByProductIdtxt.Text);
                try
                {
                    dataB.UpdateProduct(prod);
                    MessageBox.Show("Success the Product is Updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Product ID is empty!! make sure to fill it.");
        }

        private void UpdateCustomerBtn_Click(object sender, EventArgs e) //button to update customer
        {
            if (!string.IsNullOrEmpty(updateCustomeridtxt.Text))
            {
                Customers cust = new Customers();

                //cust.Customer_id = int.Parse(updateCustomeridtxtbox.Text); //current ID..


                if (!string.IsNullOrWhiteSpace(wrongCustomeridtxt.Text))
                {
                    cust.updCustId = int.Parse(wrongCustomeridtxt.Text); //updating wrong ID..
                    cust.Customer_id = int.Parse(updateCustomeridtxt.Text); //updating wrong ID..
                }
                else
                {
                    cust.Customer_id = int.Parse(updateCustomeridtxt.Text); //current ID..
                    cust.updCustId = int.Parse(updateCustomeridtxt.Text);
                }

                cust.Customer_FirstName = updateCustomerFirstNametxt.Text;
                cust.Customer_LastName = updateCustomerLastNametxt.Text;
                cust.Customer_amount = int.Parse(updateCustomerAOrderAmounttxt.Text);
                cust.Customer_Address = updateCustomerAddresstxt.Text;
                cust.Customer_Email = updateCustomermailtxt.Text;
                cust.Customer_PhoneNo = int.Parse(updateCustomerPhonenumbertxt.Text);

                try
                {
                    dataB.UpdateCustomer(cust);
                    MessageBox.Show("Success the Customer is Updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("One or More Field is Empty");
        }

        private void cmbBoxProductSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void makeOrderCusIDcmbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void makeorderprodnamecmbobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderAmountcbo.Items.Clear();
            product[] prodArr;
            prodArr = dataB.getproductById(int.Parse(ProdIDNewordercbo.Text));
            OrderPricePerProdtxt.Enabled = true;
            OrderPricePerProdtxt.Text = prodArr[0].Price.ToString();
            OrderPricePerProdtxt.Enabled = false;
            int max = prodArr[0].Amount;
            if (prodArr[0].Amount > 50)
            {
                max = 50;
            }

            for (int i = 1; i <= max; i++)
            {
                OrderAmountcbo.Items.Add(i);
            }

            if (!string.IsNullOrEmpty(OrderAmountcbo.Text))
            {
                OrderSumPricetxt.Enabled = true;
                OrderSumPricetxt.Text = (prodArr[0].Price * int.Parse(OrderAmountcbo.Text)).ToString();
                OrderSumPricetxt.Enabled = false;
            }
            
        } 

        private void cmbBoxOrderAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderSumPricetxt.Enabled = true;
            OrderSumPricetxt.Text = (int.Parse(OrderPricePerProdtxt.Text) * int.Parse(OrderAmountcbo.Text)).ToString();
            OrderSumPricetxt.Enabled = false;
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e) //button to submit order (make a new order)
        {
            OrderPricePerProdtxt.Enabled = true;
            OrderSumPricetxt.Enabled = true;

            if (!string.IsNullOrWhiteSpace(makeOrderCusEmailcbo.Text) && !string.IsNullOrWhiteSpace(ProdIDNewordercbo.Text) && !string.IsNullOrWhiteSpace(OrderAmountcbo.Text) && !string.IsNullOrWhiteSpace(OrderPricePerProdtxt.Text) && !string.IsNullOrWhiteSpace(OrderSumPricetxt.Text))
            {
                order ord = new order();

                ord.Customer_id = dataB.GetCustomerIdByEmail(makeOrderCusEmailcbo.Text);
             
                ord.Product_id = int.Parse(ProdIDNewordercbo.Text);
                ord.customer_email= makeOrderCusEmailcbo.Text;
                ord.Sum_pay = int.Parse(OrderSumPricetxt.Text);
                ord.amount = int.Parse(OrderPricePerProdtxt.Text);

                try
                {
                    dataB.InsertOrder(ord);
                    MessageBox.Show("Success the Order is insert");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("one or more fields are empty");
            }
            OrderPricePerProdtxt.Enabled = false;
            OrderSumPricetxt.Enabled = false;
            
        }

        private void tabPage4_Click_1(object sender, EventArgs e)
        {

        }

        private void SupplierProddataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void showbtnSuplierPord_Click(object sender, EventArgs e) 
        {
            product[] prodarr;
            if (!string.IsNullOrWhiteSpace(suppIDSuppProdtext.Text))
            { 
                prodarr = dataB.gettAllProductsSupplierByID(int.Parse(suppIDSuppProdtext.Text));
                SupplierProddataGrd.DataSource = prodarr;
            }
            else
            {
                MessageBox.Show("Please insert the supplier ID!!!");
            }
        }//button to show products by suppliers ID

        private void searchbtn_Click(object sender, EventArgs e) //button to search for customer by his name
        {
            if (!string.IsNullOrWhiteSpace(customerNametxt.Text))
            {
                order[] orderarr;
                orderarr = dataB.getAllOrdersByCustomerName(customerNametxt.Text);
                grdorderCustomer.DataSource = orderarr;
            }
            else
            {
                MessageBox.Show("Please insert the customer NAME!!!");
            }
        }

       private void txtboxprodrank_TextChanged(object sender, EventArgs e) //checks if the rank between 0-10
       {
           int value = Convert.ToInt32(prodranktxt.Text);
           
           if (!(Enumerable.Range(0, 11).Contains(value)))
           {
               MessageBox.Show("Please insert rank between 0-10");
           }

       }

       private void ShowCustomersBtn_Click_1(object sender, EventArgs e)
       {
           Pfile pd = new Pfile("Customers Report.pdf");
           pd.doc.OpenDocument();
           pd.SetTitle("Customers");
           PdfPTable myTable = new PdfPTable(7);
           float[] widthCell = new float[7];
           for (int i = 0; i < 7; i++)
           {
               widthCell[i] = 20;
           }
           PdfPCell myCell = new PdfPCell();
           myCell.FixedHeight = 20;
           myCell.HorizontalAlignment = Element.ALIGN_CENTER;
           myCell.VerticalAlignment = Element.ALIGN_CENTER;

           Customers[] custo;
           custo = dataB.getAllCustomers();
           myCell.Phrase = new Phrase("Customer ID");
           myTable.AddCell(myCell);

           myCell.Phrase = new Phrase(" First Name");
           myTable.AddCell(myCell);

           myCell.Phrase = new Phrase(" Last Name");
           myTable.AddCell(myCell);

           myCell.Phrase = new Phrase("Address");
           myTable.AddCell(myCell);
           myCell.Phrase = new Phrase("Email");
           myTable.AddCell(myCell);
           myCell.Phrase = new Phrase("Phone Number");
           myTable.AddCell(myCell);
           myCell.Phrase = new Phrase("Amount");
           myTable.AddCell(myCell);

           for (int i = 0; i < custo.Length; i++)
           {
               myCell.Phrase = new Phrase(custo[i].Customer_id.ToString());
               myTable.AddCell(myCell);

               myCell.Phrase = new Phrase(custo[i].Customer_FirstName.ToString());
               myTable.AddCell(myCell);

               myCell.Phrase = new Phrase(custo[i].Customer_LastName.ToString());
               myTable.AddCell(myCell);

               myCell.Phrase = new Phrase(custo[i].Customer_Address.ToString());
               myTable.AddCell(myCell);
               myCell.Phrase = new Phrase(custo[i].Customer_Email.ToString());
               myTable.AddCell(myCell);
               myCell.Phrase = new Phrase(custo[i].Customer_PhoneNo.ToString());
               myTable.AddCell(myCell);
               myCell.Phrase = new Phrase(custo[i].Customer_amount.ToString());
               myTable.AddCell(myCell);

           }

           try
           {
               pd.doc.Add(myTable);
               MessageBox.Show("Success file downloaded");
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }


           pd.CloseReport();
       } //button to save pdf file about all the customers in the table

       private void showSuppliersbtn_Click(object sender, EventArgs e)
       {
           
           Pfile pd = new Pfile("Suppliers Report.pdf");
           pd.doc.OpenDocument();
           pd.SetTitle("Suppliers");
           PdfPTable myTable = new PdfPTable(5);
           float[] widthCell = new float[5];
           for (int i = 0; i < 5; i++)
           {
               widthCell[i] = 20;
           }
           PdfPCell myCell = new PdfPCell();
           myCell.FixedHeight = 20;
           myCell.HorizontalAlignment = Element.ALIGN_CENTER;
           myCell.VerticalAlignment = Element.ALIGN_CENTER;

           suppliers[] supp;
           supp = dataB.getAllsuppliers();
           myCell.Phrase = new Phrase("suppplier ID");
           myTable.AddCell(myCell);

           myCell.Phrase = new Phrase(" Name");
           myTable.AddCell(myCell);



           myCell.Phrase = new Phrase("Address");
           myTable.AddCell(myCell);
           myCell.Phrase = new Phrase("Phone Number");
           myTable.AddCell(myCell);
           myCell.Phrase = new Phrase("Email");
           myTable.AddCell(myCell);

           for (int i = 0; i < supp.Length; i++)
           {
               myCell.Phrase = new Phrase(supp[i].Supplier_id.ToString());
               myTable.AddCell(myCell);

               myCell.Phrase = new Phrase(supp[i].Sup_name.ToString());
               myTable.AddCell(myCell);

               myCell.Phrase = new Phrase(supp[i].Address.ToString());
               myTable.AddCell(myCell);

               myCell.Phrase = new Phrase(supp[i].Phone.ToString());
               myTable.AddCell(myCell);
               myCell.Phrase = new Phrase(supp[i].Email.ToString());
               myTable.AddCell(myCell);


           }
           try
           {
               pd.doc.Add(myTable);
               MessageBox.Show("Success file downloaded");
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }


           pd.CloseReport();
       }//button to save pdf file about all the suppliers in the table

       private void UpdateByProductIdtxt_TextChanged(object sender, EventArgs e)
       {

       }

       private void prodnametxt_TextChanged(object sender, EventArgs e)
       {

       }
  
        
    }
}