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
    public partial class AddSemester : Form
    {
        public AddSemester()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=IBRAHIM;Initial Catalog=MyProject;Integrated Security=True");


            SqlCommand cmd = new SqlCommand("insert into Semester VALUES('" + textBox1.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + this.dateTimePicker1.Text + "','" + this.dateTimePicker2.Text+ "');", con);

            cmd.Parameters.AddWithValue("@SemesterName", textBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@StartDate", this.dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@EndDate", this.dateTimePicker2.Text);

            cmd.Parameters.AddWithValue("@Id", textBox1.Text.ToString());
            
            String sn = textBox1.Text;
            //String sd = dateTimePicker1;
            //String ed = dateTimePicker2.Text;
            if (String.IsNullOrEmpty(sn))
            {
                MessageBox.Show("your Boxs are Empty");
                return;
            }

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Information of this AddClass is updated!");

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Close();
            
        }
    }
}
