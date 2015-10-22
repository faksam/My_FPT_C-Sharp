using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WorkShop2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

              if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter value for Rollno!");
                return;
            }

            SqlConnection conn = new SqlConnection("Data Source=IBRAHIM;Initial Catalog=StudentDB;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("select * from StudentStatus where Rollno = @Rollno", conn);
            cmd.Parameters.AddWithValue("@Rollno", textBox1.Text);

            
            conn.Open();

           
            SqlDataReader dr = cmd.ExecuteReader();

            if (!dr.Read())
            {
                MessageBox.Show(string.Format("RollNo {0} doesn't exists!", textBox1.Text));
                return;

            }
            comboBox2.SelectedIndex = 0;
            textBox3.Text = dr["SemesterId"].ToString();
            textBox2.Text = dr["SemesterNo"].ToString();
            comboBox2.Text = dr["Status"].ToString();

            
            dr.Close();
            conn.Close();

             
        }

        private void button2_Click(object sender, EventArgs e)
        {
             SqlConnection conn = new SqlConnection("Data Source=IBRAHIM;Initial Catalog=StudentDB;Integrated Security=True");
                conn.Open();

            SqlCommand cmd = new SqlCommand("update StudentStatus set Status = @Status WHERE Rollno = @Rollno", conn);
             
           
            cmd.Parameters.AddWithValue("@Rollno", textBox1.Text);
          
            cmd.Parameters.AddWithValue("@Status", comboBox2.Text);
           
            
            cmd.ExecuteNonQuery();
            

                MessageBox.Show("Information of this StudentStatus is updated!");
                conn.Close();
        }

        }
        }
    

