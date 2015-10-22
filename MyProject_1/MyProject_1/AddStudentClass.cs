using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyProject_1
{
    public partial class AddStudentClass : Form
    {
        public AddStudentClass()
        {
            InitializeComponent();
        }
         private void AddStudentClass_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
           

            SqlConnection con = new SqlConnection("Data Source=IBRAHIM;Initial Catalog=MyProject;Integrated Security=True");


            SqlCommand cmd = new SqlCommand("insert into StudentStatus VALUES('" + textBox1.Text + "','" + comboBox1.SelectedItem + "','" + textBox2.Text + "','" + comboBox2.SelectedItem + "');", con);

            cmd.Parameters.AddWithValue("@RollNo", textBox1.Text);
            cmd.Parameters.AddWithValue("@SemesterID", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@SemesterNo", textBox2.Text);
            cmd.Parameters.AddWithValue("@Status", comboBox2.SelectedItem);


            MessageBox.Show("Information of Student Class is updated!");


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=IBRAHIM;Initial Catalog=MyProject;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from MyProject where RollNo = @RollNo", con);
            cmd.Parameters.AddWithValue("@RollNo", textBox1.Text);
            con.Open();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter value for RollNo!");
                return;
            }

            

            SqlDataReader dr = cmd.ExecuteReader();

            if (!dr.Read())
            {
                MessageBox.Show(string.Format("RollNo {0} doesn't exists!", textBox1.Text));
                return;

            }
            comboBox1.SelectedItem = dr["SemesterID"].ToString();
            textBox2.Text = dr["SemesterNo"].ToString();
            comboBox2.SelectedItem = dr["Status"].ToString();
           
            dr.Close();
            con.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         
    }
}
