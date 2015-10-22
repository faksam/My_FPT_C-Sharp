using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WorkShop3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SqlDataAdapter sda = new SqlDataAdapter("select * from colors order by ColorName",
                App.ConnectionString);
            DataSet ds = new DataSet();
            //copy data to ds
            sda.Fill(ds, "Colors");
            //copy data from ds.tables["semester"] to control
            comboBox1.DataSource = ds.Tables["Colors"];
            comboBox1.DisplayMember = "ColorName";
            comboBox1.ValueMember = "ColorId";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string fn = textBox1.Text;
            string up = textBox2.Text;
            if (String.IsNullOrEmpty(fn))
            {
                MessageBox.Show("Please Enter Name Of Flower");
            }
            if (String.IsNullOrEmpty(up))
            {
                MessageBox.Show("Please Enter Unit Price...");
            }
            double pu = 0;
            if (double.TryParse(up, out pu) == false)
            {
                MessageBox.Show("Please a numberic");
                return;
            }
            if (pu < 0)
            {
                MessageBox.Show("must be greater than or equals to zero");
                return;
            }
            try
            {

                SqlConnection conn = new SqlConnection(App.ConnectionString);
                SqlCommand cmd = new SqlCommand("INSERT INTO Flowers(FlowerName, ColorID, UnitPrice) " +
                "VALUES(@FlowerName, @ColorID, @UnitPrice)", conn);
                cmd.Parameters.AddWithValue("@FlowerName", textBox1.Text);
                cmd.Parameters.AddWithValue("@ColorID", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@UnitPrice", double.Parse(textBox2.Text));

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Information of a new flower is addded!"); 
                conn.Close();

               
            }
            catch (Exception ex)
            {
            }
        }
    }
}
