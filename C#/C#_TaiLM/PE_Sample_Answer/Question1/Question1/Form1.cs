using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Question1
{
    public partial class Form1 : Form
    {
        string strConn = "server=localhost;database=SampleExam; Integrated Security = true";
    
        public Form1()
        {
            InitializeComponent();
            // Select Customers

            SqlConnection cn = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter("select * from Customers order by CompanyName", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "CompanyName";
            comboBox1.ValueMember = "CustomerID";

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
                MessageBox.Show("Please enter value for Customer ID!");
                return;
            }
            // search and display
            SqlConnection cn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("select * from customers where CustomerID = @CustomerID", cn);
            cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
       //   cmd.Parameters.AddWithValue("@CustomerID", comboBox1.SelectedValue);
            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                MessageBox.Show(String.Format("Customer ID {0} doesn't exist!", txtCustomerID.Text));
                cn.Close();
                return;
            }
            
            txtCompanyName.Text = dr["CompanyName"].ToString();
            txtContactName.Text = dr["ContactName"].ToString();
            txtContactTitle.Text = dr["ContactTitle"].ToString();
            txtAddress.Text = dr["Address"].ToString();
            txtPhone.Text = dr["Phone"].ToString();
            txtFax.Text = dr["Fax"].ToString();

            dr.Close();
            cn.Close();
            
                      
            btnSearch.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("update customers set CompanyName = @CompanyName " +
                    ", ContactName=@ContactName,ContactTitle=@ContactTitle" +
                    ", Address = @Address, Phone = @Phone, Fax = @Fax" +
                    " where CustomerID = @CustomerID", cn);

                cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                cmd.Parameters.AddWithValue("@ContactName", txtContactName.Text);
                cmd.Parameters.AddWithValue("@ContactTitle", txtContactTitle.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Fax", txtFax.Text);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("Information of customer is updated!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = true;
            btnSave.Enabled = false;
            txtCustomerID.Text = comboBox1.SelectedValue.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
