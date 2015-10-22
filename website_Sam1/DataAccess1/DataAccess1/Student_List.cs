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
    public partial class DataFilter : Form
    {
       
        public DataFilter()
        {
          
            InitializeComponent();
            // Load All the semesters from semester table to comboBox1
            SqlDataAdapter ad = new SqlDataAdapter("select * from Semester",App.ConnectionString);
            DataSet ds = new DataSet();
            ad.Fill(ds,"Semester");
            //Bin ds.Tables["Semester"] to comboBox1
          comboBox1.DataSource=  ds.Tables["Semester"];
          comboBox1.DisplayMember = "Name";
          comboBox1.ValueMember = "Id";

            //Load all the Record from Semester,StudentStatus,Student from DataView
          string dast = " select Student.RollNo,Student.FullName, StudentStatus.SemesterId, "
              +"Semester.Name, StudentStatus.Status from Student, "
              + "Semester, StudentStatus where Student.RollNo= StudentStatus.RollNo  and StudentStatus.SemesterId = Semester.Id";
          ad = new SqlDataAdapter(dast, App.ConnectionString);
          ad.Fill(ds,"Student");
            // Copy records from ds.Tables["Student"] to dataview
          dv = new DataView(ds.Tables["Student"]);
            //Bind dv to datagridview
          dataGridView1.DataSource = dv;        

        }
        DataView dv = null;

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dv.RowFilter = "";
            }
            else
            {
                string semesterId = comboBox1.SelectedValue.ToString();
                string fullname = textBox1.Text;
                dv.RowFilter = "fullname like '%" + fullname + "%' " + " and SemesterId =" + semesterId;
            }
            //count how many students who are studying
            int ss = 0;
            for (int i = 0; i < dataGridView1.Rows.Count -1; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value.ToString().Equals("Studying"))
                    ss++;
            }
            label4.Text = ""+ss; 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

       

       
    }
}
