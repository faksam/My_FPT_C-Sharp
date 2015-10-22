using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Session10a
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection SqlConn = null;
        private void button2_Click(object sender, EventArgs e)
        {
            //1. Set up connection properties
            SqlConn = new SqlConnection();
            SqlConn.ConnectionString = Global.ConnectionString;
            //2.Open connection
            SqlConn.Open();
            //3. if
            if (SqlConn.State == ConnectionState.Open)
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }
            //4.Close connection
            SqlConn.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. OPen connection
            SqlConn.Open();
            //2. create sql statement
            string sqlSelect = "Select * from Colors";
            //3. create sqlCommand
            SqlCommand sqlCmdSelect = new SqlCommand();
            sqlCmdSelect.Connection = SqlConn;
            sqlCmdSelect.CommandText = sqlSelect;
            //4.send, execute and receive result
            SqlDataReader r = sqlCmdSelect.ExecuteReader();
            //5.print
            listBox1.Items.Clear();
            while (r.Read())
            {
                listBox1.Items.Add(r.GetString(1));
                
            }
           
            //6.close
            SqlConn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //1. OPen connection
            SqlConn.Open();
            //2. create sql statement
            string sqlCount = "Select count(*) from Colors";
           //3. create command sender
            SqlCommand sqlCmdCount = new SqlCommand(sqlCount, SqlConn);
            //4. execute sqlCount
            int i = (int)sqlCmdCount.ExecuteScalar();
            //5. print output
            MessageBox.Show("Total records: " + i);
            //6.close
            SqlConn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //open connection
            SqlConn.Open();
            //create sql insert
            string sqlInsert = "insert into colors values(@colorName)";
           // string sqlInsert = string.Format("insert into Colors values('{0}')", textBox1.Text);
            //create command sender
            SqlCommand sqlCmdInsert = new SqlCommand(sqlInsert, SqlConn);
            sqlCmdInsert.Parameters.Add("@colorName", textBox1.Text);
            //execute sqlCmdInsert
            int i = sqlCmdInsert.ExecuteNonQuery();
            MessageBox.Show("New row has been added");
            //close connection
            SqlConn.Close();
            //reload listbox
            button1_Click(null, null);

        }
    }
}
