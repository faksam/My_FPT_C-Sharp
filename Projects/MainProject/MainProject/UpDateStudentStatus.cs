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
    public partial class UpDateStudentStatus : Form
    {
        public UpDateStudentStatus()
        {
            InitializeComponent();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Class",
          App.connectionApp);
            DataSet ds = new DataSet();
            //copy data to ds
            sda.Fill(ds, "Class");
            comboBox1.DataSource = ds.Tables["Class"];
            comboBox1.DisplayMember = "ClassCode";
            comboBox1.ValueMember = "ClassCode"; 
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Roll No cannot be Empty!!!");
            }
            else
            {
                SqlCommand cmd;

                string scmd = "select Student.FullName ,Student.ClassCode ,"
               + " Semester.Name, StudentStatus.[SemesterNo],StudentStatus.[Status] "
               + "  from Student, Semester,StudentStatus "
                + " where Student.RollNo = '"+textBox1.Text+"' AND StudentStatus.RollNo = Student.RollNo AND StudentStatus.SemesterId= Semester.Id ";

                 SqlConnection con = new SqlConnection(App.connectionApp);
                con.Open();
                cmd = new SqlCommand(scmd, con);
                var dr = cmd.ExecuteReader();

                if (dr.HasRows == false)
                {
                    MessageBox.Show("RollNo not found!!!");
                    //throw new Exception();
                }
                if (dr.Read())
                {
                    textBox2.Text = dr[0].ToString();
                    comboBox1.SelectedValue = dr[1].ToString();
                    comboBox2.SelectedItem = dr[2].ToString();
                    textBox3.Text = dr[3].ToString();
                    comboBox3.SelectedItem = dr[4].ToString();
   
                }
                con.Close();


            }
            button1.Enabled = false;
            button2.Enabled = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(App.connectionApp);
                SqlCommand cmd = new SqlCommand(" update StudentStatus set StudentStatus.Status = @Status "
                + " WHERE StudentStatus.RollNo = @RollNo ", sqlConn);
              
                cmd.Parameters.AddWithValue("@RollNo", textBox1.Text);
                cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
                cmd.Parameters.AddWithValue("@ClassCode", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@SemesterName", comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("@SemesterNo", textBox3.Text);
                cmd.Parameters.AddWithValue("@Status", comboBox3.SelectedItem);

                sqlConn.Open();
                cmd.ExecuteNonQuery();
                sqlConn.Close();

                MessageBox.Show("Information of this Student Status is updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
