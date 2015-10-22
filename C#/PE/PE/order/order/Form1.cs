using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace order
{
    public partial class Form1 : Form
    {
        int tong=0;
        string strConn = "server=localhost;database=Restaurant; Integrated Security = true";
        public Form1()
        {
           
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter("select * from Kho order by tenhang", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "tenhang";
            comboBox1.ValueMember = "ItemID";

            SqlDataAdapter da1 = new SqlDataAdapter("select * from Customers order by CustomerID", cn);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            comboBox2.DataSource = ds1.Tables[0];
            comboBox2.DisplayMember = "CustomerName";
            comboBox2.ValueMember = "CustomerID";
            int dem1=0;
            try
            {

                SqlCommand cmd = new SqlCommand("Select Count (OrderID) as dem from OrderList", cn);
                cn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                int dem = 0;
                if (rd.Read())
                    dem = int.Parse(rd["dem"].ToString());
                dem1 = dem+1;
                rd.Close();

                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tb_OrderID.Text = "A" + dem1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("update Kho set soluong = @soluong where ItemID=@ItemID", cn);
                cmd.Parameters.AddWithValue("@ItemID", comboBox1.SelectedValue.ToString());
                int order = Convert.ToInt32(tb_soluong.Text.Trim());
                int kho = Convert.ToInt32(tb_slkho.Text.Trim());
                int con = kho - order;
                if (kho < order)
                {
                    MessageBox.Show("Hang trong kho khong du thong cam!");
                    return;
                }
                cmd.Parameters.AddWithValue("@soluong", con);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Chuc quy khach ngon mieng ^^");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                if (listBox1.Text == "")
                {
                    MessageBox.Show("You don't have order");
                    return;
                }
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Insert into OrderList(OrderID,CustomerID,price,OrderDate)" +
                   "values(@OrderID,@CustomerID,@price,@OrderDate)", cn);

                cmd.Parameters.AddWithValue("@OrderID", tb_OrderID.Text);
                cmd.Parameters.AddWithValue("@CustomerID", comboBox2.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@OrderDate", DateTime.Today);
                cmd.Parameters.AddWithValue("@price", tong);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("select * from Kho where ItemID = @ItemID", cn);
                cmd.Parameters.AddWithValue("@ItemID", comboBox1.SelectedValue.ToString());
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();



                if (!dr.Read())
                {
                    MessageBox.Show(String.Format("Item ID {0} doesn't exist!", comboBox1.Text));
                    cn.Close();
                    return;
                }
                tb_slkho.Text = dr["soluong"].ToString();
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               try
               {
                   SqlConnection cn = new SqlConnection(strConn);
                   SqlCommand cmd = new SqlCommand("select * from Item where ItemID = @ItemID", cn);
                   cmd.Parameters.AddWithValue("@ItemID", comboBox1.SelectedValue.ToString());
                   cn.Open();
                   SqlDataReader dr = cmd.ExecuteReader();

                   if (!dr.Read())
                   {
                       MessageBox.Show(String.Format("Item ID {0} doesn't exist!", comboBox1.Text));
                       cn.Close();
                       return;
                   }
                   tb_giatien.Text = dr["price"].ToString();
                   dr.Close();
                   cn.Close();
              
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message);
               }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tb_CustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string c = comboBox1.SelectedValue.ToString() +"  "+ tb_soluong.Text;
            int tien1 = Convert.ToInt32(tb_giatien.Text.Trim());
            int sl = Convert.ToInt32(tb_soluong.Text.Trim());
            tong = tong + sl * tien1;
            listBox1.Items.Add(c);
        }
    }
}
