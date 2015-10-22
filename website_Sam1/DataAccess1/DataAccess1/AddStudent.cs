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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
            InitializeComponent();
           // SqlDataAdapter sqlAd = new SqlDataAdapter("select Status from StudentStatus", App.ConnectionString);
           // DataSet ds = new DataSet();
           // //copy data to the ds
           // sqlAd.Fill(ds, "StudentStatus");
           // // copy data from ds.tables["Semester"] to control
           // comboBox2.DataSource = ds.Tables["StudentStatus"];
           // comboBox2.DisplayMember = "Status";
           //// comboBox2.ValueMember = "RollNo";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string classcode = "";
        private void button1_Click(object sender, EventArgs e)
        {
            classcode = comboBox1.Text;
            try
            {

                // string st = "insert into StudentStatus values(@RollNo,@SemesterId,@SemesterNo,@Status)";
                SqlConnection MyConnection = new SqlConnection(App.ConnectionString);
                MyConnection.Open();
                string sqlinsert = "insert into Student values(@RollNo,@ClassCode,@FullName,@Nationality)";
                SqlCommand cmd= new SqlCommand(sqlinsert, MyConnection);               

                cmd.Parameters.AddWithValue("@RollNo", textBox1.Text);
                cmd.Parameters.AddWithValue("@ClassCode",classcode );
                cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Nationality", comboBox2.SelectedItem.ToString());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Infromation of StudentClass has being Saved!");
                MyConnection.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
