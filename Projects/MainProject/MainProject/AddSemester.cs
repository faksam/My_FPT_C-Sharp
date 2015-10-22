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
    public partial class AddSemester : Form
    {
        public AddSemester()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String sn = textBox1.Text;
            if (String.IsNullOrEmpty(sn))
            {
                MessageBox.Show("your Boxs are Empty");
                return;
            }

            try
            {
                SqlConnection sqlconn = new SqlConnection(App.connectionApp);
                SqlCommand cmd = new SqlCommand(" insert into Semester VALUES ('" + textBox1.Text.ToString() + "','"
                     + this.dateTimePicker1.Text + "','" + this.dateTimePicker2.Text + "');", sqlconn);

                cmd.Parameters.AddWithValue("@SemesterName", textBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@StartDate", this.dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@EndDate", this.dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text.ToString());
                sqlconn.Open();
                cmd.ExecuteNonQuery();
                sqlconn.Close();

                MessageBox.Show("Information of this AddSemester is updated!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
