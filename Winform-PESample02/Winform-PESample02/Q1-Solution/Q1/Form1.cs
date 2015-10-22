using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Q1
{
    public partial class Form1 : Form
    {
        string connectionString = "data source=IBRAHIM;database=CNET_PE;integrated security=true";

        public Form1()
        {

            InitializeComponent();
            string sql = "select * from MaterialGroups order by GroupName ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "GroupName";
            comboBox1.ValueMember = "MaterialGroupId";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = textBox1.Text;
            string name = textBox2.Text;
            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("Please enter material type code");
                return;
            }
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter material type name");
                return;
            }
            try
            {

                SqlConnection sqlConn = new SqlConnection(connectionString);
                SqlCommand sqlCmd = new SqlCommand("insert into MaterialTypes values(@v1,@v2,@v3,@v4)",
                    sqlConn);
                sqlConn.Open();
                sqlCmd.Parameters.AddWithValue("@v1", code);
                sqlCmd.Parameters.AddWithValue("@v2", name);
                sqlCmd.Parameters.AddWithValue("@v3", comboBox1.SelectedValue);
                sqlCmd.Parameters.AddWithValue("@v4", checkBox1.Checked);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                string msg = "A new material type is added\n" +
                    "Material type code: " + code + "\n" +
                    "Material type name: " + name + "\n" +
                    "Material type group: " + comboBox1.SelectedValue + "\n" +
                    "Is " + (checkBox1.Checked?"":"not") +" Detail";
                MessageBox.Show(msg, "Information Dialog");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
