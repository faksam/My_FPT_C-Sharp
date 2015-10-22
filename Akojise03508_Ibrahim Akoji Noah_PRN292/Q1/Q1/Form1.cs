using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Q1
{
    public partial class Form1 : Form
    {
        string connectionString = "data source=IBRAHIM; database=Y12S3B1; integrated security=true";

        public Form1()
        {
            InitializeComponent();
            string sql = "select * from colors ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "ColorName";
            comboBox1.ValueMember = "ColorID";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lb = textBox1.Text;
            string pr = textBox2.Text;
            string le = textBox3.Text;
            string di = textBox4.Text;
            if (string.IsNullOrEmpty(lb)||(string.IsNullOrEmpty(pr)||(string.IsNullOrEmpty(le)||(string.IsNullOrEmpty(di)))))
            {
                MessageBox.Show("TextBox Must not be Empty!!!");
                return;
            }

            double st2 = 0;
            if (double.TryParse(pr, out st2) == false)
            {
                MessageBox.Show("Please a numberic");
                return;
            }
            if (st2 < 0)
            {
                MessageBox.Show("must be greater than or equals to zero");
                return;
            }
            double st3 = 0;
            if (double.TryParse(le, out st3) == false)
            {
                MessageBox.Show("Please a numberic");
                return;
            }
            if (st3 < 0)
            {
                MessageBox.Show("must be greater than or equals to zero");
                return;
            }
            double st4 = 0;
            if (double.TryParse(di, out st4) == false)
            {
                MessageBox.Show("Please a numberic");
                return;
            }
            if (st4 < 0)
            {
                MessageBox.Show("must be greater than or equals to zero");
                return;
            }

            try
            {

                SqlConnection sqlConn = new SqlConnection(connectionString);
                SqlCommand sqlCmd = new SqlCommand("insert into Mops values(@v1,@v2,@v3,@v4,@v5)",
                    sqlConn);
                sqlConn.Open();
                sqlCmd.Parameters.AddWithValue("@v1", textBox1.Text);
                sqlCmd.Parameters.AddWithValue("@v2", textBox2.Text);
                sqlCmd.Parameters.AddWithValue("@v3", textBox3.Text);
                sqlCmd.Parameters.AddWithValue("@v4", textBox4.Text);
                sqlCmd.Parameters.AddWithValue("@v5", comboBox1.SelectedValue);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                
                MessageBox.Show( "Information of a new Mops is added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
