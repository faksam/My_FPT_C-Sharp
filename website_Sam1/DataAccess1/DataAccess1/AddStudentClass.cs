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
            SqlDataAdapter sqlAd = new SqlDataAdapter("select * from Semester",App.ConnectionString);
            DataSet ds = new DataSet();
            //copy data to the ds
            sqlAd.Fill(ds,"Semester");
            // copy data from ds.tables["Semester"] to control
            comboBox2.DataSource = ds.Tables["Semester"];
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";

            //disable all control
            comboBox1.Enabled = comboBox2.Enabled =textBox3.Enabled = button2.Enabled = button3.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Enable all control if the student id found
            //use the connected layer in this solution
            SqlConnection MyConnection = new SqlConnection(App.ConnectionString);
            SqlCommand cmd;       

            string TheCommand = "";
           
           
                TheCommand = "select * from Student where RollNo= 'ttest' and RollNo not in (select RollNo from StudentStatus)";
                cmd = new SqlCommand(TheCommand, MyConnection);
                MyConnection.Open();

                SqlDataReader r = cmd.ExecuteReader();
                 if (r.Read())
            {
                     comboBox1.Enabled = comboBox2.Enabled = textBox3.Enabled
                         = button2.Enabled = button3.Enabled= true;
                     comboBox1.SelectedIndex = 0;
               
            }
                 else
                 { MessageBox.Show("Student does not exist.");}
               
                MyConnection.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
              
               // string st = "insert into StudentStatus values(@RollNo,@SemesterId,@SemesterNo,@Status)";
                SqlConnection MyConnection = new SqlConnection(App.ConnectionString);
                string sqlinsert = "insert into StudentStatus values(@v1,@v2,@v3,@v4)";
                SqlCommand cmd;
                cmd = new SqlCommand(sqlinsert, MyConnection);
                MyConnection.Open();              

                cmd.Parameters.AddWithValue("@v1", textBox1.Text);
                cmd.Parameters.AddWithValue("@v2", comboBox2.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@v3",textBox3.Text);
                cmd.Parameters.AddWithValue("@v4",comboBox1.SelectedItem.ToString());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Infromation of StudentClass has being Saved!");
                MyConnection.Close();
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
