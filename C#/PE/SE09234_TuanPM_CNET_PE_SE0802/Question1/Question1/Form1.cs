using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Question1
{
    public partial class Form1 : Form
    {
        String strConn = "Data Source=localhost;Initial Catalog=Y12S2B3;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            SqlConnection cn = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from Sizes ORDER BY SizeName", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            cbSize.DataSource = ds.Tables[0];
            cbSize.DisplayMember = "SizeName";
            cbSize.ValueMember = "SizeID";
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (txtBrand.Text.Equals(""))
            {
                MessageBox.Show("Please enter value for Brand !");
                return;
            }
            if (txtDimension.Text.Equals(""))
            {
                MessageBox.Show("Please enter value for Dimensions !");
                return;
            }
            if (txtCapacity.Text.Equals(""))
            {
                MessageBox.Show("Please enter value for Capacity !");
                return;
            }

            if (txtDescription.Text.Equals(""))
            {
                MessageBox.Show("Please enter value for Description !");
                return;
            }

            int capacity = 0;
            try
            {

                capacity = int.Parse(txtCapacity.Text);
                if (capacity <= 0)
                {
                    MessageBox.Show("Capacity must be greater than 0 !");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Capacity must be integer !");
                return;
            }
            try
           {
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("INSERT INTO Suitcases(Brand,SizeID,Dimensions,Capacity, Description) VALUES (@Brand,@SizeID,@Dimensions,@Capacity,@Description)", cn);

                cmd.Parameters.AddWithValue("@Brand", txtBrand.Text);
                cmd.Parameters.AddWithValue("@SizeID", cbSize.SelectedValue);
                cmd.Parameters.AddWithValue("@Dimensions", txtDimension.Text);
                cmd.Parameters.AddWithValue("@Capacity", capacity);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
           }
            catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
               return;
           }
            MessageBox.Show("New information of Suitcases is added");
        }
    }
}
