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
        string connectionString = "data source=KHJ;database=SampleExam;integrated security=true";
        SqlConnection sqlConn = null;
        //a group of datatable
        DataSet ds = null;
        //bridge between dataset and database
        SqlDataAdapter sda = null;
        //load all colors to datagridview
        void LoadColors()
        {
            sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            //sql select statement
            string sqlSelect = "select * from colors";
            SqlCommand cmdSelect = new SqlCommand(sqlSelect, sqlConn);
            //create bridge
            sda = new SqlDataAdapter(cmdSelect);
            //make new dataset
            ds = new System.Data.DataSet();
            //fill data from database into dataset
            sda.Fill(ds, "Colors");
            //binding ds to datagridview
            dataGridView1.DataSource = ds.Tables[0];
            sqlConn.Close();
        }
        public Form1()
        {
            InitializeComponent();
            LoadColors();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string colorName = textBox1.Text;
            if (string.IsNullOrEmpty(colorName))
            {
                MessageBox.Show("Color name can not be empty");
                textBox1.Focus();
                return;
            }
            //get added table
            DataTable dtColors = ds.Tables[0];
            //make new row
            DataRow dr = dtColors.NewRow();
            //assign values to dr
            dr[1] = colorName;
            //add dr to dataset
            dtColors.Rows.Add(dr);
            //update database
            SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
            sda.Update(ds,"Colors");
            LoadColors();
            MessageBox.Show("New row has been added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //get selected row index
            int i = dataGridView1.SelectedCells[0].RowIndex;
            if (i >= 0 && i < dataGridView1.Rows.Count - 1)
            {
                if (MessageBox.Show("Delete this record?",
                                    "Confirmation Dialog",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question)
                                    == System.Windows.Forms.DialogResult.Yes)
                {
                    string vid = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    int id = int.Parse(vid);
                    //get removed row
                    DataTable dt = ds.Tables[0];
                    DataRow dr = dt.Rows[i];
                    //remove dr
                    dr.Delete();
                    //configure sda
                    string sqlDelete = "delete from Colors where colorId=@colorId";
                    SqlCommand cmdDelete = new SqlCommand(sqlDelete, sqlConn);
                    cmdDelete.Parameters.AddWithValue("@colorId", id);
                    sda.DeleteCommand = cmdDelete;
                    //update database
                    sda.Update(ds, "colors");
                }
            }
            else
                MessageBox.Show("Please, select a row!!");
        }
    }
}
