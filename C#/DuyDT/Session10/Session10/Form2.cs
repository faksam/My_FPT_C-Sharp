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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection sqlConn = null;
        private void button2_Click(object sender, EventArgs e)
        {
            //1. setup connection properties
            sqlConn = new SqlConnection();
            sqlConn.ConnectionString = Global.ConnectionString;
            //2. open connection
            sqlConn.Open();
            //3. if connection is opening
            if (sqlConn.State == ConnectionState.Open)
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }
            //4. close connection
            sqlConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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
            while (r.Read())
            {
                listBox1.Items.Add(r.GetString(1));
            }
            //6. close connection
            sqlConn.Close();
        }
    }
}
