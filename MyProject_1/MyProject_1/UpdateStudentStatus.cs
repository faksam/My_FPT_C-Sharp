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
    public partial class UpdateStudentStatus : Form
    {
        string Con = "Server = localhost; Database = MyProject; Integrated security = true";
        public UpdateStudentStatus()
        {
            InitializeComponent();
           
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=IBRAHIM;Initial Catalog=MyProject;Integrated Security=True");
                //SqlCommand cmd = new SqlCommand("insert into StudentStatus VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem + "','" + comboBox2.SelectedItem + "','" + textBox3.Text + "','" + comboBox3.SelectedItem + "');", con);
                SqlCommand cmd = new SqlCommand("select * from MyProject where RollNo = @RollNo", con);
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter value for RollNo!");
                    return;
                }

                cmd.Parameters.AddWithValue("@RollNo", textBox1.Text);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.Read())
                {
                    MessageBox.Show(string.Format("RollNo {0} doesn't exists!", textBox1.Text));
                    return;

                }
                textBox2.Text = dr["@FullName"].ToString();
                comboBox1.SelectedItem = dr["ClassCode"].ToString();
                comboBox2.SelectedItem = dr["SemesterName"].ToString();
                textBox2.Text = dr["SemesterNo"].ToString();
                comboBox2.SelectedItem = dr["Status"].ToString();
               
                dr.Close();
                con.Close();

                button1.Enabled = true;
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=IBRAHIM;Initial Catalog=MyProject;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand("insert into StudentStatus VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem + "','" + comboBox2.SelectedItem + "','" + textBox3.Text + "','" + comboBox3.SelectedItem + "');", con);
            SqlCommand cmd = new SqlCommand("update MyProject set RollNo = @RollNo, FullName = @FullName, ClassCode = @ClassCode, " +
            "SemesterName = @SemesterName, SemesterNo = @SemesterNo, Status = @Status" +
           "WHERE RollNo = @RollNo", con);
            cmd.Parameters.AddWithValue("@RollNo", textBox1.Text);
            cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
            cmd.Parameters.AddWithValue("@ClassCode", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@SemesterName", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@SemesterNo", textBox2.Text);
            cmd.Parameters.AddWithValue("@Status", comboBox2.SelectedItem);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Information of this Student Status is updated!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
