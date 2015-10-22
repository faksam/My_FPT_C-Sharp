using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MainProject
{
    public partial class AddStudentClass : Form
    {
        public AddStudentClass()
        {
            InitializeComponent();
            SqlDataAdapter sda = new SqlDataAdapter("select * from semester",
                App.connectionApp);
            DataSet ds = new DataSet();
            //copy data to ds
            sda.Fill(ds, "semester");
            //copy data from ds.tables["semester"] to control
            comboBox1.DataSource = ds.Tables["semester"];
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            //display all control
            comboBox1.Enabled = comboBox2.Enabled = textBox2.Enabled
                = button2.Enabled = button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(App.connectionApp);
            string sqlSelect = "select * from student " +
                "where rollno = @rollno and " +
                "rollno not in (select rollno from studentstatus ) ";
            SqlCommand cmdSelect = new SqlCommand(sqlSelect, sqlConn);
            sqlConn.Open();
            cmdSelect.Parameters.AddWithValue("@rollno", textBox1.Text);
            SqlDataReader r = cmdSelect.ExecuteReader();
            // if student is found
            if (r.Read())
            {
                comboBox1.Enabled = comboBox2.Enabled = textBox2.Enabled
                    = button2.Enabled = button3.Enabled = true;
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Student does not exits");
            }
            sqlConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(App.connectionApp);
            string sqlInsert = "insert into StudentStatus values(@v1, @v2, @v3, @v4)";
            SqlCommand sqlcmd = new SqlCommand(sqlInsert, sqlConn);
            sqlConn.Open();
            sqlcmd.Parameters.AddWithValue("@v1", textBox1.Text);
            sqlcmd.Parameters.AddWithValue("@v2", comboBox1.SelectedValue.ToString());
            sqlcmd.Parameters.AddWithValue("@v3", textBox2.Text);
            sqlcmd.Parameters.AddWithValue("@v4", comboBox2.SelectedItem.ToString());
            sqlcmd.ExecuteNonQuery();
            MessageBox.Show("Information of StudentClass has been added");
            sqlConn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
