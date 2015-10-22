using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Session10
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection sqlConn = null;
        private void button1_Click(object sender, EventArgs e)
        {
            //1. setup connection properties
            sqlConn = new SqlConnection();
            sqlConn.ConnectionString = Global.ConnectionString;
            //2. open connection
            sqlConn.Open();
            //3. if connection is opening
            if (sqlConn.State == ConnectionState.Open)
            {
                button1.Enabled = false;
                button2.Enabled = true;
            }
            //4. close connection
            sqlConn.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1. open connection
            sqlConn.Open();
            //2. create sql statement
            string sqlSelect = "Select * from Colors";
            //3. create sqlCommand 
            SqlCommand sqlCmdSelect = new SqlCommand();
            sqlCmdSelect.Connection = sqlConn;
            sqlCmdSelect.CommandText = sqlSelect;
            //4. send, execute and receive result
            SqlDataReader r = sqlCmdSelect.ExecuteReader();
            //5. print out the result
            listBox1.Items.Clear();
            while (r.Read())
            {
                listBox1.Items.Add(r.GetString(1));
            }
            //6. close connection
            sqlConn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //1. open connection
            sqlConn.Open();
            //2. create sql statement
            string sqlCount = "Select count(*) from Colors";
            //3. create command sender
            SqlCommand sqlCmdCount = new SqlCommand(sqlCount, sqlConn);
            //4. execute sqlCount
            int i = (int)sqlCmdCount.ExecuteScalar();
            //5. print output
            MessageBox.Show("Total records: " + i);
            //6. close connection
            sqlConn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //1. open connection
            sqlConn.Open();
            //2. create sql insert
            string sqlInsert = "insert into colors values(@colorName)";
            //3. create command sender
            SqlCommand sqlCmdInsert = new SqlCommand(sqlInsert, sqlConn);
            sqlCmdInsert.Parameters.Add("@colorName", textBox1.Text);
            //4. execute sqlCmdInsert
            int i = sqlCmdInsert.ExecuteNonQuery();
            MessageBox.Show("New row has been added");
            //5. close connection
            sqlConn.Close();
            //reload listbox
            button2_Click(null, null);
        }
    }
}
