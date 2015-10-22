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
        string strConn = "server=localhost;database=Y12S2B1; Integrated Security = true";
        public Form1()
        {
            InitializeComponent();
            SqlConnection cn = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter("select * from Cabs order by CabName", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "CabName";
            comboBox1.ValueMember = "CabID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            if (tb_Name.Text == "")
            {
                MessageBox.Show("Must input values for Name");
                return;
            }
            if (tb_weight.Text == "")
            {
                MessageBox.Show("Must input values for Total weight");
                return;
            }
            try
            {
                int wheel = Convert.ToInt32(tb_base.Text.Trim());
                if (wheel <= 0)
                {
                    MessageBox.Show("Wheel base must be number integer and greater than 0 !");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Wheel base must be number integer and greater than 0 !");
                return;
            }
            try
            {
                int engine = Convert.ToInt32(tb_Engine.Text.Trim());
                if (engine <= 0)
                {
                    MessageBox.Show("Engine must be number integer and greater than 0 !");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Engine must be number integer and greater than 0 !");
                return;
            }
            try
            {
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Insert into Trucks(TruckName,TotalWeight,Wheelbase,CabID,Engine)" +
                    "values(@TruckName,@TotalWeight,@Wheelbase,@CabID,@Engine)", cn);

                cmd.Parameters.AddWithValue("@TruckName", tb_Name.Text);
                cmd.Parameters.AddWithValue("@TotalWeight", tb_weight.Text);
                cmd.Parameters.AddWithValue("@Wheelbase", tb_base.Text);
                cmd.Parameters.AddWithValue("@CabID", int.Parse(comboBox1.SelectedValue.ToString()));
                cmd.Parameters.AddWithValue("@Engine", tb_Engine.Text);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("New information of Truck is added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
