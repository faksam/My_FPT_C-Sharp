using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projectDB
{
    public partial class Form1 : Form
    {
        string strConn = "server=localhost;database=Restaurant; Integrated Security = true";
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (tb_Name.Text == "")
            {
                MessageBox.Show("Must enter values for Name");
                return;
            }
            if (tb_ID.Text == "")
            {
                MessageBox.Show("Must enter values for CustomerID");
                return;
            }
            if (tb_Sex.Text == "")
            {
                MessageBox.Show("Must enter 'M' or 'F' for sex ");
                return;
            }
            if (tb_Sex.Text != "M" && tb_Sex.Text != "F")
            {
                MessageBox.Show("Must enter 'M' or 'F' for sex ");
                return;
            }
            if (tb_address.Text == "")
            {
                MessageBox.Show("Must enter values for Address");
                return;
            }*/
            try
            {
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Insert into Customers(CustomerID,CustomerName,sex,address,tel,email,type)" +
                    "values(@CustomerID,@CustomerName,@sex,@address,@tel,@email,@type)", cn);

                cmd.Parameters.AddWithValue("@CustomerID", tb_ID);
                cmd.Parameters.AddWithValue("@CustomerName", tb_Name.Text);
                cmd.Parameters.AddWithValue("@sex", tb_Sex.Text);
                cmd.Parameters.AddWithValue("@address", tb_address.Text);
                cmd.Parameters.AddWithValue("@tel", tb_tel.Text);
                cmd.Parameters.AddWithValue("@email", tb_email.Text);
                cmd.Parameters.AddWithValue("@type", tb_type.Text);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("New information of Customers is added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
