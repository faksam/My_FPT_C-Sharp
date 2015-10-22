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
    public partial class FilterStudent : Form
    {
        public FilterStudent()
        {
            InitializeComponent();
            SqlDataAdapter sqlDA = new SqlDataAdapter("select * from Semester",App.ConnectionString);
            DataSet ds = new DataSet();
            //copy db to ds
            sqlDA.Fill(ds,"Semester");
            //copy data from ds.table["semester"] to control
            comboBox1.DataSource = ds.Tables["Semester"];
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sMajor = "";
            if (radioButton1.Checked)
            {
                sMajor = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                sMajor = radioButton2.Text;
            }
            
            try
            {
                SqlConnection sqlConn = new SqlConnection(App.ConnectionString);
                sqlConn.Open();
                string sqlSelect = "SELECT Student.RollNo, Semester.Name, StudentStatus.SemesterNo, StudentStatus.Status"
                                 + " FROM Class, Student, Semester, StudentStatus"
                                 + " WHERE (Class.Major = '" + sMajor.ToString() + "' AND Semester.Name = '" + comboBox1.Text.ToString() + "' AND Class.ClassCode = Student.ClassCode)";
                SqlCommand cmdSelect = new SqlCommand(sqlSelect, sqlConn);
                SqlDataReader r = cmdSelect.ExecuteReader();

                //refresh listview
                listView1.Items.Clear();
                int row = 0;
                while (r.Read())
                {
                    // get the value at the current position
                    string rollNo = r[0].ToString();
                    string semName = r[1].ToString();
                    string semNo = r[2].ToString();
                    string status = r[3].ToString();
                    listView1.Items.Add(rollNo);
                    listView1.Items[row].SubItems.Add(semName);
                    listView1.Items[row].SubItems.Add(semNo);
                    listView1.Items[row].SubItems.Add(status);
                    row++;
                }
                sqlConn.Close();
                cmdSelect.Dispose();
                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //items counting
            label3.Text = "Total Student: " + listView1.Items.Count.ToString() + " student(s)";
        }
    }
}
