using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PE1_DemoNTKH
{
    public partial class Form1 : Form
    {
        string strConn = "Data Source=KHJ;Initial Catalog=NorthWind;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            SqlConnection cn = new SqlConnection(strConn);
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Employees order by Title ", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "Title";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string lastname = textBox1.Text;
            string firstname = textBox2.Text;
            string birthdate = textBox3.Text;
            string address = textBox4.Text;
            string country = textBox5.Text;
            if (lastname == "")
            {
                MessageBox.Show("Please enter values into lastname");
            }
            if (firstname == "")
            {
                MessageBox.Show("Please enter values into firstname");
            }
            if (birthdate == "")
            {
                MessageBox.Show("Please enter values into birthdate");
            }
            if (address == "")
            {
                MessageBox.Show("Please enter values into address");
            }
            if (country == "")
            {
                MessageBox.Show("Please enter values into country");
            }
            try
            {

                string strConn = "Data Source=KHJ;Initial Catalog=NorthWind;Integrated Security=True";
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Insert into Employees(LastName, FirstName, Title, Birthdate, Address, Country) " +
                    "Values(@LastName, @FirstName, @Title, @Birthdate, @Address, @Country)", cn);
                cmd.Parameters.AddWithValue("@LastName", lastname);
                cmd.Parameters.AddWithValue("@FirstName", firstname);
                cmd.Parameters.AddWithValue("@Title", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@Birthdate", birthdate);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Country", country);


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("New information of Employees is added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
       }
}
