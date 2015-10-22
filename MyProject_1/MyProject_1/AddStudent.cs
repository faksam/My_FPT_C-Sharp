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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=IBRAHIM;Initial Catalog=MyProject;Integrated Security=True");
          

            SqlCommand cmd = new SqlCommand("insert into Student VALUES('"+textBox1.Text+"','"+comboBox1.SelectedItem+"','"+ textBox2.Text+"','"+ comboBox2.SelectedItem+"');",con);
            
            cmd.Parameters.AddWithValue("@RollNo", textBox1.Text);
             cmd.Parameters.AddWithValue("@ClassCode", comboBox1.SelectedItem);
             cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
             cmd.Parameters.AddWithValue("@Nationality", comboBox2.SelectedItem);
            


            String rn = textBox1.Text;
           // String ccd = comboBox1.Text;
            String fn = textBox2.Text;
           // String na = comboBox2.Text;
            if (String.IsNullOrEmpty(rn)|| String.IsNullOrEmpty(fn) )
                
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
