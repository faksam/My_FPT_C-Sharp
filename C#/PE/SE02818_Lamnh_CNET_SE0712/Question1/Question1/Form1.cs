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
        public Form1()
        {
            InitializeComponent();
            string sql = "Data Source=localhost;Initial Catalog=Y12S2B3;Integrated Security=True";
            SqlConnection cn = new SqlConnection(sql);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Sizes ORDER BY SizeName", cn);
            DataSet dt = new DataSet();
            da.Fill(dt);
            cbSide.DataSource = dt.Tables[0];
            cbSide.DisplayMember = "SizeName";
            cbSide.ValueMember = "SizeID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbBrand.Text == "")
            {
                MessageBox.Show("Must not be empty");
                return;
            }
            if (tbDescription.Text == "")
            {
                MessageBox.Show("Must not be empty");
                return;
            }
            if (tbCapacity.Text == "")
            {
                MessageBox.Show("Must not be empty");
                return;
            }
            if (tbDimemsion.Text == "")
            {
                MessageBox.Show("Must not be empty");
                return;
            }
            
            try { int.Parse(tbCapacity.Text); }
            catch
            {
                MessageBox.Show(" Capacity Must be numeric");
                return;
            }
            if (int.Parse(tbCapacity.Text) < 0)
            {
                MessageBox.Show("Capacity Must not < 0");
                return;
            }
            string sql = "Data Source=localhost;Initial Catalog=Y12S2B3;Integrated Security=True";
            SqlConnection cn = new SqlConnection(sql);
            SqlCommand cmd = new SqlCommand("INSERT INTO Suitcases(Brand,SizeID,Dimensions,Capacity,Description)"
                                     + "VALUES(@Brand,@SizeID,@Dimensions,@Capacity,@Description)", cn);
            cmd.Parameters.AddWithValue("@Brand", tbBrand.Text);
            cmd.Parameters.AddWithValue("@SizeID", cbSide.SelectedValue);
            cmd.Parameters.AddWithValue("@Dimensions", tbDimemsion.Text);
            cmd.Parameters.AddWithValue("@Capacity", tbCapacity.Text);
            cmd.Parameters.AddWithValue("@Description", tbDescription.Text);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("New information of Suitcase is added");
        }
    }
}
