using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataAccess_1
{
    public partial class Form1 : Form
    {
        //provide connection string to Ado connection
        string connectionString = "data source=IBRAHIM; database=StudentDB; integrated security=true;";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);
                sqlconn.Open();
                string sqlselect = "select classcode, batch, major from Class";
                SqlCommand sqlcmd = new SqlCommand(sqlselect,sqlconn);
                SqlDataReader r = sqlcmd.ExecuteReader();// use for select only..
                int row = 0;
                //extract the data from r and display to listview
                while(r.Read())
                {
                    string Classcode = r[0].ToString();
                    string batch = r[1].ToString();
                    string major = r[2].ToString();
                        
                    listView1.Items.Add(Classcode);
                    listView1.Items[row].SubItems.Add(batch);
                    listView1.Items[row].SubItems.Add(major);
                    row++;

                }

                sqlconn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select RollNo, Student.ClassCode, FullName,Nationality, batch, major from Student, Class where Student.ClassCode = Class.ClassCode",
                connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //bind dt to datagridview
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(App.connectionString);
            sqlconn.Open();
            string sqlSelect = "select count(*) from class";
            SqlCommand sqlcmd = new SqlCommand(sqlSelect, sqlconn);
            int totalRecord = (int)sqlcmd.ExecuteScalar();
            MessageBox.Show("Total record(s): " + totalRecord);
            sqlconn.Close();
        }
    }
}
