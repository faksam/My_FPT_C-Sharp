using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SampleExamDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = true;
            btnSave.Enabled = false;
        }
        
        string connectionString = "data source=DuyDT-PC;database=SampleExam;integrated security=true";
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            /* to do list
             * 1. customer id is empty -> display msg error and stop
             * 2. customer id is not found -> display msg and stop
             * 3. customer id is found -> display customer information
             */
            string cid = textBox1.Text;
            if (string.IsNullOrEmpty(cid))
            {
                MessageBox.Show("Please enter value for customer ID!");
                textBox1.Focus();
                return;
            }
            SqlConnection sqlConn = new SqlConnection(connectionString);
            string sqlSelect = "select * from customers where customerid = @customerid";
            SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, sqlConn);
            sqlConn.Open();
            sqlCmdSelect.Parameters.AddWithValue("@customerid", cid);
            //execute sqlSelect
            SqlDataReader r = sqlCmdSelect.ExecuteReader();
            if (r.Read())
            {
                textBox2.Text = r.IsDBNull(1) ? "" : r.GetString(1);
                textBox3.Text = r.IsDBNull(2) ? "" : r.GetString(2);
                textBox4.Text = r.IsDBNull(3) ? "" : r.GetString(3);
                textBox5.Text = r.IsDBNull(4) ? "" : r.GetString(4);
                textBox6.Text = r.IsDBNull(5) ? "" : r.GetString(5);
                textBox7.Text = r.IsDBNull(6) ? "" : r.GetString(6);
                btnSave.Enabled = true;
                btnSearch.Enabled = false;
            }
            else
                MessageBox.Show("Customer ID " + cid + " does not exist!");
            sqlConn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sqlUpdate = " update customers ";
            sqlUpdate += " set companyname=@v1, ";
            sqlUpdate += " ContactName = @v2, ";
            sqlUpdate += " ContactTitle = @v3, ";
            sqlUpdate += " Address = @v4, ";
            sqlUpdate += " Phone = @v5, ";
            sqlUpdate += " Fax = @v6 ";
            sqlUpdate += " where customerid = @v0";
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlCmdUpdate = new SqlCommand(sqlUpdate, sqlConn);
            sqlConn.Open();
            //set parametes properties
            sqlCmdUpdate.Parameters.AddWithValue("@v0", textBox1.Text);
            sqlCmdUpdate.Parameters.AddWithValue("@v1", textBox2.Text);
            sqlCmdUpdate.Parameters.AddWithValue("@v2", textBox3.Text);
            sqlCmdUpdate.Parameters.AddWithValue("@v3", textBox4.Text);
            sqlCmdUpdate.Parameters.AddWithValue("@v4", textBox5.Text);
            sqlCmdUpdate.Parameters.AddWithValue("@v5", textBox6.Text);
            sqlCmdUpdate.Parameters.AddWithValue("@v6", textBox7.Text);
            int i = sqlCmdUpdate.ExecuteNonQuery();
            if (i != 0)
                MessageBox.Show("Information of this record has been updated");
            sqlConn.Close();

        }
    }
}
