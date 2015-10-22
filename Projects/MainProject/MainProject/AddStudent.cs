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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
            SqlDataAdapter sqlDA = new SqlDataAdapter("select * from Class ", App.connectionApp);
            DataSet ds = new DataSet();
            //copy db to ds
            sqlDA.Fill(ds, "Class");
            //copy data from ds.table["semester"] to control
            comboBox1.DataSource = ds.Tables["Class"];
            comboBox1.DisplayMember = "ClassCode";
            comboBox1.ValueMember = "Batch";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String rn = textBox1.Text;
           String fn = textBox2.Text;
            
            if (String.IsNullOrEmpty(rn) || String.IsNullOrEmpty(fn))
            {
                MessageBox.Show("your Boxs are Empty");
                return;
            }

            try
            {
                SqlConnection sqlconn = new SqlConnection(App.connectionApp);
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("insert into Student VALUES('" + textBox1.Text + "','" + comboBox1.SelectedItem + "','" + textBox2.Text + "','" + comboBox2.SelectedItem + "');", sqlconn);
                cmd.Parameters.AddWithValue("@RollNo", textBox1.Text);
                cmd.Parameters.AddWithValue("@ClassCode", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Nationality", comboBox2.SelectedItem);

               
                cmd.ExecuteNonQuery();
                sqlconn.Close();

                MessageBox.Show("Information of this AddStudent is updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
