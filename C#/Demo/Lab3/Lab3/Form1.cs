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

namespace Lab3
{
    public partial class Form1 : Form
    {
        /*string connectionString = "data source=KHJ;database=Lab3;integrated security=true";
        SqlConnection sqlConn = null;
        //a group of datatable
        DataSet ds = null;
        //bridge between dataset and database
        SqlDataAdapter sda = null;
        //load all colors to datagridview
        void LoadCustomerDetail()
        {
            sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            //sql select statement
            string sqlSelect = "select * from customerDetail";
            SqlCommand cmdSelect = new SqlCommand(sqlSelect, sqlConn);
            //create bridge
            sda = new SqlDataAdapter(cmdSelect);
            //make new dataset
            ds = new System.Data.DataSet();
            //fill data from database into dataset
            sda.Fill(ds, "CustomerDetail");
            //binding ds to datagridview
            textBox1. = ds.Tables[0];
            sqlConn.Close();
        }*/
        public Form1()
        {
            InitializeComponent();
           // LoadCustomerDetail();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (string.IsNullOrEmpty(name)||name.Length >=50)
            {
                MessageBox.Show("Color name can not be empty or not longer than 50 characters");
                textBox1.Focus();
                return;
            }
           // MessageBox.Show("Name: " + name);
           /* //get added table
            DataTable dtCustomerDetail = ds.Tables[0];
            //make new row
            DataRow dr = dtCustomerDetail.NewRow();
            //assign values to dr
            dr[1] = name;
            //add dr to dataset
            dtCustomerDetail.Rows.Add(dr);*/
            
            //Age
            int iCharacterCounter = 0;
            foreach (char cCharacter in textBox2.Text)
            {
                if (!char.IsLetter(cCharacter))
                {
                    iCharacterCounter++;

                    if (iCharacterCounter > 3)
                    {
                        // Display error message
                        MessageBox.Show("Age only accepts maximum 3 characters");

                        // Set focus on Extension Text Field
                        textBox2.Focus();

                        return;
                    }
                }
            }
            
            //Address
            string n = textBox3.Text;


            if (string.IsNullOrEmpty(n))
            {
                MessageBox.Show("Entered again");
                textBox3.Focus();
                return;
            }

            //Phonecell
           string p = textBox4.Text;


            if (string.IsNullOrEmpty(p))
            {
                MessageBox.Show("Entered again");
                textBox4.Focus();
                return;
            }
            //Email
            string h = textBox5.Text;

            if (string.IsNullOrEmpty(h))
            {
                MessageBox.Show("Entered email again");
                textBox5.Focus();
                return;
            }
            //Problem


            //Status
            string[] szStatus = { "Solved", "Unsolved" };

            foreach (string szInfo in szStatus)
                comboBox1.Items.Add(szInfo);

            MessageBox.Show("Name: " + name + "\nAge: " + iCharacterCounter + n + p + h + comboBox1.SelectedItem.ToString());



            //update database
        /*    SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
            sda.Update(ds, "CustomerDetail");
            LoadCustomerDetail();
            MessageBox.Show("New row has been added");*/
        }

        
    }
}
