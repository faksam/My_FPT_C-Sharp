using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
namespace Lap_03
{
    public partial class Form1 : Form
    {
        string connectionString = "data source=KHJ;database=Lab3;integrated security=true";
        private bool IsValidNumber(string pwd)
        {
            if (pwd.Length > 3) return false;
            double x = Double.Parse(pwd);
            if (x <= 0) return false;

            bool test = true;
            foreach (char c in pwd.ToCharArray())
            {
                if (char.IsLetter(c))
                {
                    test = false;
                    break;
                }
            }
            return test;
        }

        public static bool isValidEmail(string inputEmail)
        {
           // if (inputEmail.Length <= 10) return false;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex reg = new Regex(strRegex);
            if (reg.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string add = textBox3.Text;
            string phone = textBox4.Text;
            string status = comboBox1.Text;

            //name
            string name = textBox1.Text;
            if (string.IsNullOrEmpty(name) || name.Length > 50)
            {
                MessageBox.Show("Name cannot be null or blank and \nName cannot longer than 50 characters.");
                textBox1.Focus();
                return;
            }
            //age
            string age = textBox2.Text;
            if (!IsValidNumber(age))
            {
                MessageBox.Show("Age cannot be null or must be positive number and not longer 3 character.");
                textBox2.Focus();
                return;   
            }
            //Email
            string email = textBox5.Text;
            if (!isValidEmail(email))
            {
                MessageBox.Show("Email cannot be null or must have only one @ character.");
                textBox2.Focus();
                return;  
            }
            string proEnt = "";
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                proEnt = checkBox1.Text;
            }

            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                proEnt += checkBox2.Text;
            }
            string sqlInsert = " insert into CustomerDetail values (@v0,@v1,@v2,@v3,@v4,@v5,@v6)";

            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlCmdUpdate = new SqlCommand(sqlInsert, sqlConn);

            sqlConn.Open();
            //set parametes properties
            sqlCmdUpdate.Parameters.AddWithValue("@v0", name);
            sqlCmdUpdate.Parameters.AddWithValue("@v1", age);
            sqlCmdUpdate.Parameters.AddWithValue("@v2", add);
            sqlCmdUpdate.Parameters.AddWithValue("@v3", phone);
            sqlCmdUpdate.Parameters.AddWithValue("@v4", email);
            sqlCmdUpdate.Parameters.AddWithValue("@v5", proEnt);
            sqlCmdUpdate.Parameters.AddWithValue("@v6", status);

            int i = sqlCmdUpdate.ExecuteNonQuery();
            if (i != 0)
                MessageBox.Show("Inserted");
            sqlConn.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = ""; 
            textBox4.Text = "";
            textBox5.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            comboBox1.SelectedIndex = 0;
            MessageBox.Show("Clear all inputs...");
        }

        

    }
}
