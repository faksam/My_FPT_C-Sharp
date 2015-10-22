using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataAccess_1
{
    public partial class AddClass : Form
    {
        public AddClass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string classcode = textBox1.Text;
            if(string.IsNullOrEmpty(classcode))
            {
                MessageBox.Show("Classcode can not be Empty.. ");
                return;
            }
            string batchNo = textBox2.Text;
            int v = 0;
            if(int.TryParse(batchNo, out v) == false)                       
            {
                MessageBox.Show("BatchNo must be integer number");
                    return;
            }
            try{
                SqlConnection sqlconn = new SqlConnection(App.connectionString);
                sqlconn.Open();
                //setup sql statement
                string sqlInsert = "insert into Class values(@Classcode,@batch,@major)";
                SqlCommand sqlcmd = new SqlCommand(sqlInsert, sqlconn);
                //specify values for parameters
                sqlcmd.Parameters.AddWithValue("@Classcode", classcode);
                sqlcmd.Parameters.AddWithValue("@batch", v);
                sqlcmd.Parameters.AddWithValue("@major", comboBox1.SelectedItem.ToString());
                // send and receive result from db
                sqlcmd.ExecuteNonQuery(); // delete, update, insert
                MessageBox.Show("Informationof class has been added");
                sqlconn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
