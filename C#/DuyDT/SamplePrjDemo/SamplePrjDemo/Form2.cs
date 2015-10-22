using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SamplePrjDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cid = txtId.Text;
            if (string.IsNullOrEmpty(cid))
            {
                MessageBox.Show("Please enter for customer id");
                txtId.Focus();
                return;
            }
            SqlConnection sqlConn = new SqlConnection(Global.ConnectionString);
            string sqlSelect = "select * from customers where customerid = @customerid";
            SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, sqlConn);
            sqlCmdSelect.Parameters.AddWithValue("@customerid", cid);
            sqlConn.Open();
            SqlDataReader r = sqlCmdSelect.ExecuteReader();
            if (r.Read())
            {
                textBox1.Text = r.IsDBNull(1)? "" : r.GetString(1);
                textBox2.Text = r.IsDBNull(2) ? "" : r.GetString(2);
                textBox3.Text = r.IsDBNull(3) ? "" : r.GetString(3);
                textBox4.Text = r.IsDBNull(4) ? "" : r.GetString(4);
                textBox5.Text = r.IsDBNull(5) ? "" : r.GetString(5);
                textBox6.Text = r.IsDBNull(6) ? "" : r.GetString(6);
            }
            else
                MessageBox.Show("Customer id " + cid + " does not exist!");
            sqlConn.Close();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlUpdate = "update Customers set companyName = @v1, ";
            sqlUpdate += " Contactname = @v2, contacttitle = @v3, ";
            sqlUpdate += " address = @v4, phone = @v5, fax = @v6";
            sqlUpdate +=  " where customerid = @v0";
        }
    }
}
