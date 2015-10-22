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
    public partial class AddStudentClass : Form
    {
        public AddStudentClass()
        {
            InitializeComponent();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Semester", App.ConnectionString);
            DataSet ds = new DataSet();
            //copy dt to ds
            sda.Fill(ds,"semester");
            //copy data from ds.table["semester"] to control
            comboBox1.DataSource = ds.Tables["semester"];
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            //disable all control
            comboBox1.Enabled = comboBox2.Enabled = textBox2.Enabled = button2.Enabled = button3.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //enable all control if student is focus
            //use connected layer in this solution
            SqlConnection sqlConn = new SqlConnection(App.ConnectionString);
            string sqlSelect = "select * from Student  where RollNo = 'test' and RollNo not in (select RollNo from StudentStatus)";
            SqlCommand cmdSelect = new SqlCommand(sqlSelect,sqlConn);
            //cmdSelect.Parameters.AddWithValue("@RollNo",textBox1.Text);
            sqlConn.Open();
            SqlDataReader r = cmdSelect.ExecuteReader();
            //if student in focus
            if (r.Read())
            {
                comboBox1.Enabled = comboBox2.Enabled = textBox2.Enabled = button2.Enabled = button3.Enabled = true;
                comboBox1.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show("Student does not exist");
            }
            sqlConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //add information of studentclass to studentstatus
            try
            {
                SqlConnection sqlConn = new SqlConnection(App.ConnectionString);
                string sqlInsert = "insert into StudentStatus values (@v1,@v2,@v3,@v4)";
                SqlCommand sqlCmd = new SqlCommand(sqlInsert, sqlConn);
                sqlConn.Open();
                //specify the values for parameters
                sqlCmd.Parameters.AddWithValue("@v1", textBox1.Text);
                sqlCmd.Parameters.AddWithValue("@v2", comboBox1.SelectedValue.ToString());
                sqlCmd.Parameters.AddWithValue("@v3", textBox2.Text);
                sqlCmd.Parameters.AddWithValue("@v4", comboBox2.SelectedItem.ToString());
                //send sqlInsert to DB
                sqlCmd.ExecuteNonQuery();
                //print output
                MessageBox.Show("Information of studentClass has been added");
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
