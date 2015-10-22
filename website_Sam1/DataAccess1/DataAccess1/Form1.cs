using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DataAccess1
{
    public partial class Form1 : Form
    {
        //Provide connection string to ADO Connection
        string ConnectionString = @"data source=(local); database= StudentDB;Integrated security= true;";
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //call the sqlconnection
                SqlConnection Sqlcon = new SqlConnection(ConnectionString);
                Sqlcon.Open();
                // sql statement "select/inset/delete/update/create
                string sqlselect = "select ClassCode,Batch,Major from class";
                //send sql statement to the DB
                SqlCommand cmd = new SqlCommand(sqlselect,Sqlcon);
                //use the SqlDataReader only for the select Statement.
                SqlDataReader r = cmd.ExecuteReader();
                //Extract the data from r and display to the listview.
                int row = 0;
                while(r.Read())
                {
                    // get the value at the current postion
                    string ClassCode = r[0].ToString();
                    string Batch = r[1].ToString();
                    string Major = r[2].ToString();
                    listView1.Items.Add(ClassCode);
                    listView1.Items[row].SubItems.Add(Batch);
                    listView1.Items[row].SubItems.Add(Major);
                    row++;
                }
              
                Sqlcon.Close();
                cmd.Dispose();
                r.Close();
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                //call the sqlconnection
                SqlConnection Sqlcon = new SqlConnection(ConnectionString);
                Sqlcon.Open();
                // sql statement "select/inset/delete/update/create
                string sqlselect2 = "select Id,Name,StartDate,EndDate from Semester";
                //send sql statement to the DB
                SqlCommand cmd = new SqlCommand(sqlselect2, Sqlcon);
                //use the SqlDataReader only for the select Statement.
                SqlDataReader r = cmd.ExecuteReader();
                //Extract the data from r and display to the listview.
                int row = 0;
                while (r.Read())
                {
                    // get the value at the current postion
                    string Id = r[0].ToString();
                    string Name = r[1].ToString();
                    string StartDate = r[2].ToString();
                    string EndDate = r[2].ToString();
                    listView2.Items.Add(Id);
                    listView2.Items[row].SubItems.Add(Name);
                    listView2.Items[row].SubItems.Add(StartDate);
                    listView2.Items[row].SubItems.Add(EndDate);
                    row++;
                }

                Sqlcon.Close();
                cmd.Dispose();
                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlStatement = "select ClassCode,Batch,Major from class";
            SqlDataAdapter ad = new SqlDataAdapter(sqlStatement,ConnectionString);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            //Bind dt to the datagridview
            dataGridView1.DataSource = dt;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(App.ConnectionString);
            sqlcon.Open();
            string bdst = "select count(*) from Class ";
            SqlCommand cmd = new SqlCommand(bdst,sqlcon);
            int totalRecord = (int)cmd.ExecuteScalar();
            MessageBox.Show("Total Count: " + totalRecord);
            sqlcon.Close();
        }
    }
}
