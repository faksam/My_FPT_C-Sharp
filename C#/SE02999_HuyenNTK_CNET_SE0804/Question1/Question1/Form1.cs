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
        string connectionString = "data source=KHJ;database=PE0503;integrated security=true";
        public Form1()
        {
           
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string label = textBox1.Text;
            if (string.IsNullOrEmpty(label))
            {
                MessageBox.Show("Must not be empty");
                return;
            }

            string price = textBox3.Text;
            if (string.IsNullOrEmpty(price))
            {
                MessageBox.Show("Must not be empty");
                return;
            }
            try
            {
                double p = double.Parse(textBox3.Text);
                if (p <= 0)
                {
                    MessageBox.Show("Price must be numeric and greater than 0");
                    return;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Price must be numeric and greater than 0");
                return;
            }

            string color = textBox4.Text;
            if (string.IsNullOrEmpty(color))
            {
                MessageBox.Show("Must not be empty");
                return;
            }

            string acc = textBox5.Text;
            if (string.IsNullOrEmpty(acc))
            {
                MessageBox.Show("Must not be empty");
                return;
            }

            string manID = textBox2.Text;
            if (string.IsNullOrEmpty(label))
            {
                MessageBox.Show("Must not be empty");
                return;
            }

            int iCharacterCounter = 0;
            foreach (char cCharacter in textBox2.Text)
            {
                if (!char.IsNumber(cCharacter))
                {
                    iCharacterCounter++;

                    MessageBox.Show("Must be an integer value");
                    return;
                }
            }

            
            string sqlInsert = " insert into Cookers values (@v0,@v1,@v2,@v3,@v4)";

            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlCmdUpdate = new SqlCommand(sqlInsert, sqlConn);

            sqlConn.Open();
            //set parametes properties
            sqlCmdUpdate.Parameters.AddWithValue("@v0", label);
            sqlCmdUpdate.Parameters.AddWithValue("@v1", manID);
            sqlCmdUpdate.Parameters.AddWithValue("@v2", price);
            sqlCmdUpdate.Parameters.AddWithValue("@v3", acc);
            sqlCmdUpdate.Parameters.AddWithValue("@v4", color);
            

            int i = sqlCmdUpdate.ExecuteNonQuery();
            if (i != 0)
            {
                SqlCommand cmd = new SqlCommand("select * from Cookers  where ManufacturerID = @manufacturerID", sqlConn);
              //  SqlCommand cmd = new SqlCommand("select c.label, m.ManufacturerName, c.Price, c.Accessories, c.Color from Cookers c, Manufacturers m where m.ManufacturerID = c.ManufacturerID    and c.ManufacturerID = @manufacturerID", sqlConn);
                cmd.Parameters.AddWithValue("@ManufacturerID", manID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    MessageBox.Show(string.Format("ManufacturerID {0} doesn't exists!", manID));
                    return;

                }
                
                MessageBox.Show("Label: " +   dr["label"].ToString() + "\nManufacturer: Phillipger" /*+   dr["m.Manufacturername"].ToString() */+ "\nPrice: " +   dr["price"].ToString()+ "\nAccessories: " +   dr["accessories"].ToString()+ "\nColor: " +   dr["color"].ToString());

            }

            sqlConn.Close();
        }

        
    }
}
