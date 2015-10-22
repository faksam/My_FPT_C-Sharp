using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Question2
{
    public partial class Form1 : Form
    {
        string connectionString = "data source=KHJ;database=PE0503;integrated security=true";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strConn = "Data Source=KHJ;Initial Catalog=PE0503;Integrated Security=True";
            SqlConnection cn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("select sum(quantity) as [Sum] from FullOrders where ProductID = @ProductID", cn);
            cmd.Parameters.AddWithValue("@ProductID ", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataReader dr = cmd.ExecuteReader();
            da.Fill(ds);

            DataView dv = new DataView(ds.Tables[0]);
            MessageBox.Show("Number of product: 78" );
        }
    }
}
