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
    public partial class UpdateStudent : Form
    {
        public UpdateStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection MyConnection = new SqlConnection(App.ConnectionString);
            SqlCommand cmd;

            string TheCommand = "";


            TheCommand = "select * from StudentStatus where RollNo = '" + textBox1.Text + "'";
            cmd = new SqlCommand(TheCommand, MyConnection);
            MyConnection.Open();

            SqlDataReader r = cmd.ExecuteReader();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please Enter value for RollNo.");
                return;
            }

            if (r.HasRows == false)
            {
                MessageBox.Show("Student " + textBox1.Text + " does not exist.");
                //throw new Exception();
                return;
            }
              if (r.Read())
                {
                    comboBox1.SelectedIndex = 0;
                    textBox2.Text = r[1].ToString();
                    textBox3.Text = r[2].ToString();
                    comboBox1.Text =r[3].ToString();
                   
                }             
            
            else
            { MessageBox.Show("Student does not exist."); }

            MyConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             SqlConnection MyConnection = new SqlConnection(App.ConnectionString);
            SqlCommand cmd;
            try
            {

                string dbst = "update StudentStatus  set SemesterId ='" + this.textBox2.Text + "',SemesterNo ='" + this.textBox3.Text + "',Status ='"+ this.comboBox1.Text+"'where RollNo = @RollNo";
               // string dbst = "update StudentStatus set Status =@Status where RollNo = @RollNo";
                MyConnection = new SqlConnection(App.ConnectionString);
                MyConnection.Open();
                 cmd = new SqlCommand(dbst, MyConnection);               
                 

                cmd.Parameters.AddWithValue("@RollNo", textBox1.Text);
                cmd.Parameters.AddWithValue("@SemesterNo", textBox3.Text);
                cmd.Parameters.AddWithValue("@Status", comboBox1.SelectedItem.ToString());
               
                cmd.ExecuteNonQuery();

                MessageBox.Show("Information of StudentStatus has been Updated.");
                MyConnection.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
