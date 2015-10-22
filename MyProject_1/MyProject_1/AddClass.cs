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
    public partial class AddClass : Form
    {
        
        public AddClass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=IBRAHIM;Initial Catalog=MyProject;Integrated Security=True");
          

            SqlCommand cmd = new SqlCommand("insert into Class VALUES('"+textBox1.Text+"',"+ textBox2.Text+",'"+ comboBox1.SelectedItem+"');",con);
            
            cmd.Parameters.AddWithValue("@ClassCode", textBox1.Text);
            cmd.Parameters.AddWithValue("@Batch", textBox2.Text);
            cmd.Parameters.AddWithValue("@Major", comboBox1.SelectedItem);

            String cc = textBox1.Text;
            string bn = textBox2.Text;
           
           
            if (String.IsNullOrEmpty(cc) || String.IsNullOrEmpty(bn) )
               
            {
                MessageBox.Show("your Boxs are Empty");
                return;
            }

            double st2 = 1;
            if (double.TryParse(bn, out st2) == false)
            {
                MessageBox.Show("Please a numberic");
                return;
            }
            if (st2 < 1)
            {
                MessageBox.Show("must be greater than or equals to One");
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
