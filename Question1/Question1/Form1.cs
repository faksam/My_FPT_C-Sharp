using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Question1
{
    public partial class Form1 : Form
    {
        string strConn = "Server = localhost; Database = SampleExam; Integrated security = true";
       

        public Form1()
        {
            InitializeComponent();
            btnSave.Enabled = false;
        }
        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = true;
            btnSave.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text == "")
            {
                MessageBox.Show("Please enter value for CustomerID!");
                return;
            }

            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("select * from customers where CustomerID = @CustomerID", conn);
            cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);

            
            conn.Open();

           
            SqlDataReader dr = cmd.ExecuteReader();

            if (!dr.Read())
            {
                MessageBox.Show(string.Format("Customer ID {0} doesn't exists!", txtCustomerID.Text));
                return;

            }

            txtCompanyName.Text = dr["CompanyName"].ToString();
            txtContactName.Text = dr["Contactname"].ToString();
            txtContactTitle.Text = dr["ContactTitle"].ToString();
            txtAddress.Text = dr["Address"].ToString();
            txtPhone.Text = dr["Phone"].ToString();
            txtFax.Text = dr["Fax"].ToString();

           
            dr.Close();
            conn.Close();

            btnSearch.Enabled = false;
            btnSave.Enabled = true;



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(strConn);


            SqlCommand cmd = new SqlCommand("update Customers set CompanyName = @CompanyName, ContactName = @ContactName, ContactTitle = @ContactTitle, " +
             "Address = @Address, Phone = @Phone, Fax = @Fax " +
            "WHERE CustomerID = @CustomerID", conn);
            cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
            cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
            cmd.Parameters.AddWithValue("@ContactName", txtContactName.Text);
            cmd.Parameters.AddWithValue("@ContactTitle", txtContactTitle.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@Fax", txtFax.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

                MessageBox.Show("Information of this customer is updated!");
        }

    }
 

        }

    


