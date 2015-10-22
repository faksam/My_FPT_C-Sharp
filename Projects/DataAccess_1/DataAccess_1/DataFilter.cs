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
    public partial class DataFilter : Form
    {
        public DataFilter()
        {
            InitializeComponent();
            //load all semesters from semester table to combbox1
            SqlDataAdapter sda = new SqlDataAdapter("Select * from semester", App.connectionString);
            DataSet ds = new DataSet();
            sda.Fill(ds, "semester");
            //bind ds.tables["semester " to combobox1
            comboBox1.DataSource = ds.Tables["semester"];
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            //load all records from semester, studentstatus, student to dv
            string sqlSelect = " select student.RollNo, Student.FullName, " +
                " StudentStatus.SemesterId, Semester.name,StudentStatus.Status " +
            "  from student, studentstatus,semester " +
            " where student.RollNo = StudentStatus.RollNo " +
           " and StudentStatus.SemesterId = Semester.Id ";
            sda = new SqlDataAdapter(sqlSelect, App.connectionString);
            sda.Fill(ds, "Students");
            //copy record from ds.tables["students"] to dv
            dv = new DataView(ds.Tables["Students"]);
            //bind dv to datagridview
            dataGridView1.DataSource = dv;
        }
        DataView dv = null;

        private void button1_Click(object sender, EventArgs e)
        {
            // if the checkbox is checked
                if(checkBox1.Checked)
                {
                    dv.RowFilter = "";
                }
            else//if checkbox is not checked
                {
                    string semesterid = comboBox1.SelectedValue.ToString();
                    string fullname = textBox1.Text;
                    dv.RowFilter = "fullname like '%" + fullname + "%' " +
                        "and semesterid = " + semesterid;
                }
            //count how many student who are studying
                int ss = 0;
            for(int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value.ToString().Equals("Studying")) 
                    ss++;
            }
            label3.Text = " Total Studying Student(s): " + ss;
        }
    }
}
