using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace PE_Sample_00
{
    public partial class Form1 : Form
    {
        string strConn = "Server=KHJ;Database=SampleExam;Integrated security=true";
        
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           button1.Enabled = true;
           button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter value for CustomerID!");
                return;
            }
            
            //1. Tao object Connection
            SqlConnection conn = new SqlConnection(strConn);
            
            //2. Tao object Command
            SqlCommand cmd = new SqlCommand("select * from customers where CustomerID=@CustomerID", conn);
            cmd.Parameters.AddWithValue("@CustomerID", textBox1.Text);

            //3. Mo ket noi
            conn.Open();

            //4. Tạo object DataReader
            SqlDataReader dr = cmd.ExecuteReader();

            //5. Thuc hien method Read() của DataReader

            // Neu khong co customer ID 
            if (!dr.Read())
            {
                MessageBox.Show(string.Format("Customer ID {0} doesn't exists!", textBox2.Text));
                return;

            }

            //Gan cho cac TextBox
            textBox2.Text = dr["CompanyName"].ToString();
            textBox3.Text = dr["Contactname"].ToString();
            textBox4.Text = dr["ContactTitle"].ToString();
            textBox5.Text = dr["Address"].ToString();
            textBox6.Text = dr["Phone"].ToString();
            textBox7.Text = dr["Fax"].ToString();

            // 6. Dong cac ket noi
            dr.Close();
            conn.Close();

           button1.Enabled = false;
           button2.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1. Tao object ket noi
            SqlConnection conn = new SqlConnection(strConn);

            //2. Tao object Command
            SqlCommand cmd = new SqlCommand("update Customers set CompanyName=@CompanyName, ContactName=@ContactName, ContactTitle=@ContactTitle, " +
                "Address=@Address, Phone=@Phone, Fax=@Fax " +
                "WHERE CustomerID=@CustomerID", conn);
            cmd.Parameters.AddWithValue("@CustomerID", textBox1.Text);
            cmd.Parameters.AddWithValue("@CompanyName", textBox2.Text);
            cmd.Parameters.AddWithValue("@ContactName", textBox3.Text);
            cmd.Parameters.AddWithValue("@ContactTitle", textBox4.Text);
            cmd.Parameters.AddWithValue("@Address", textBox5.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox6.Text);
            cmd.Parameters.AddWithValue("@Fax", textBox7.Text);

            MessageBox.Show(cmd.CommandText);

            //3. Mo ket noi
            conn.Open();

            //4. Thuc hien method ExecuteNonQuery() cua object Command
            cmd.ExecuteNonQuery();

            //5. Dong ket noi
            conn.Close();

            MessageBox.Show("Information of this customer is updated!");
        }


        }


        
    
}
