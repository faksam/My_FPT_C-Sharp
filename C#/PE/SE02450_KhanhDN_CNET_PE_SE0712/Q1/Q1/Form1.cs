using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                DataSet ds = new DataSet();
                String con = "server=localhost;database=Y12S2B3; Integrated Security = true";
                SqlConnection cn = new SqlConnection(con);
                SqlCommand cmd = new SqlCommand("select * from Brands order by BrandName", cn);

                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cn.Close();
                cbBrand.DataSource = ds.Tables[0];
                cbBrand.DisplayMember = "BrandName";
                cbBrand.ValueMember = "BrandID";
            }
            catch (Exception)
            {

                return;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Boolean check = true;
            
            if (tbModel.Text.Length == 0)
            {
                MessageBox.Show("input value to Model textbox");
                check = false;
            }
            if (tbOrigin.Text.Length == 0)
            {
                MessageBox.Show("input value to Origin textbox");
                check = false;
            }
            if (tbWater.Text.Length == 0)
            {
                MessageBox.Show("input value to Water resistant textbox");
                check = false;
            }
            if (tbPrice.Text.Length == 0)
            {
                MessageBox.Show("input value to Price textbox");
                check = false;
            }

           
            try
            {
                double price = double.Parse(tbPrice.Text);
                if (price <= 0)
                {
                    MessageBox.Show("Price must be numeric and greater than 0");
                    check = false;
                }
            }
            catch (Exception)
            {
                
                MessageBox.Show("Price must be numeric and greater than 0");
                check = false;
            }

            if (check == true)
            {
                string strConn = "Server = localhost; database =Y12S2B3; Integrated Security = true";
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Insert into Watches(Model, BrandID, Origin, WaterResistant, Price) " +
                "Values(@Model, @BrandID, @Origin, @WaterResistant, @Price)", cn);
                cmd.Parameters.AddWithValue("@Model", tbModel.Text);
                cmd.Parameters.AddWithValue("@BrandID", cbBrand.SelectedValue);
                cmd.Parameters.AddWithValue("@Origin", tbOrigin.Text);
                cmd.Parameters.AddWithValue("@WaterResistant", tbWater.Text);
                cmd.Parameters.AddWithValue("@Price", double.Parse(tbPrice.Text));
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("New information of Watch is added");
            }
            
        }
    }
}
