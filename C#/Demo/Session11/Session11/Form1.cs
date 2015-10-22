using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Session11
{
    public partial class Form1 : Form
    {
        string connectionString = "data source = KHJ; database = SampleExam; integrated security = true"; 
        //brigde between Dataset and database
        SqlDataAdapter sda = null;
        //a set of tables
        DataSet ds = null;
        //connection
        SqlConnection sqlConn = null;
        //loa all colors to datagridview
        void loadColors()
        {
            sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            string sqlSelect = "select * from colors";
            SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, sqlConn);
            //create bridge
            sda = new SqlDataAdapter(sqlCmdSelect);
           //create dataset
             ds = new System.Data.DataSet();
             //fill data from database into dataset
            sda.Fill(ds, "Colors");
            //bind ds to datagridview
            dataGridView1.DataSource = ds.Tables[0];
            sqlConn.Close();
        }
        public Form1()
        {
            InitializeComponent();
            loadColors();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string colorName = textBox1.Text;
            if (string.IsNullOrEmpty(colorName))
            {
                MessageBox.Show("Color Name cannot be empty");
                textBox1.Focus();
                return;

            }
            //create new datarow
            DataTable colorsTable = ds.Tables[0];
            DataRow newRow = colorsTable.NewRow();
            //put data to new Row
            newRow[1] = colorName;
            //add newRow to colorsTable
            colorsTable.Rows.Add(newRow);
            //update database automatically
            SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
            sda.Update(ds, "Colors");
            loadColors();
            MessageBox.Show("New row has been added");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //i is index of selected row
            int i = dataGridView1.SelectedCells[0].RowIndex;
            if (i >= 0 && i < dataGridView1.Rows.Count - 1)
            {
                string vid = dataGridView1.Rows[i].Cells[0].Value.ToString();
                int id = int.Parse(vid);
                //get selected row
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.Rows[i];
                //delete dr
                dr.Delete();
                //configure sda
                string sqlDelete = "delete from colors where colorid = @colorid";
                SqlCommand cmdDelete = new SqlCommand(sqlDelete, sqlConn);
                //add parameter to cmd Delete
                cmdDelete.Parameters.AddWithValue("@colorid", id);
                sda.DeleteCommand = cmdDelete;
                //update
                sda.Update(ds, "Colors");

            }
            else
                MessageBox.Show("Please, pick up a row!!");
        }

        
    }
}

