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
    public partial class Form3 : Form
    {
        SqlConnection sqlConn = null;
        public Form3()
        {
            InitializeComponent();
            sqlConn = new SqlConnection();
            sqlConn.ConnectionString = Global.ConnectionString;
        }
        //load all data in Colors into List(Colors)
        List<Colors> GetAllColors()
        {
            List<Colors> cl = new List<Colors>();
            string sqlSelect = "select * from colors";
            sqlConn.Open();
            SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, sqlConn);
            SqlDataReader r = sqlCmdSelect.ExecuteReader();
            while (r.Read())
            {
                Colors c = new Colors(r.GetInt32(0), r.GetString(1));
                cl.Add(c);
            }
            sqlConn.Close();
            return cl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetAllColors();
        }
    }
}
