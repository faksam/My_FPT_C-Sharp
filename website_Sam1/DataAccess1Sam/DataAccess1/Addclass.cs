
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /// To do list
            // * 1. Validate the input data
            // * 2. Add a new record to the table named Class
            // * /  

            string classcode = textBox1.Text;
            if (string.IsNullOrEmpty(classcode))
            {
                MessageBox.Show("ClassCode can't be empty");
                return;
            }
            string batchNo = textBox2.Text;
            int v = 0;
            if (int.TryParse(batchNo, out v) == false)
            {
                MessageBox.Show("BatchNo must be an integer number");
                return;
            }
            //2
            try
            {
                SqlConnection sqlConn = new SqlConnection(App.ConnectionString);
                sqlConn.Open();
                //setup sql statement
                string sqlInsert = "insert into Class values(@ClassCode,@BatchNo,@Major)";
                SqlCommand cmd = new SqlCommand(sqlInsert, sqlConn);
                //specify values for parameters
                cmd.Parameters.AddWithValue("@ClassCode", classcode);
                cmd.Parameters.AddWithValue("@BatchNo", v);
                cmd.Parameters.AddWithValue("@Major", comboBox1.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Information of class has been added");
                sqlConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
       
    }
}
