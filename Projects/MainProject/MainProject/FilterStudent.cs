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
    public partial class FilterStudent : Form
    {
        public FilterStudent()
        {
            InitializeComponent();
            //load all semesters from semester table to combbox1
            SqlDataAdapter sda = new SqlDataAdapter("Select * from semester", App.connectionApp);
            DataSet ds = new DataSet();
            sda.Fill(ds, "semester");
            //bind ds.tables["semester " to combobox1
            comboBox1.DataSource = ds.Tables["semester"];
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            sda = new SqlDataAdapter("Select * from StudentStatus", App.connectionApp);

            sda.Fill(ds, "StudentStatus");
            //bind ds.table["semester" to combobox1
            comboBox2.DataSource = ds.Tables["StudentStatus"];
            comboBox2.DisplayMember = "Status";
            comboBox2.ValueMember = "RollNo";

            //load all records from semester, studentstatus, student to dv
            string sqlSelect = "select Student.RollNo, Student.ClassCode, Student.FullName, Student.Nationality, Class.Batch, Class.Major, Semester.Name, StudentStatus.SemesterNo, StudentStatus.Status " +
                "from Student, Class, Semester, StudentStatus " +
                "where StudentStatus.RollNo = Student.RollNo " +
                "and StudentStatus.SemesterId = Semester.Id " +
                "and Student.ClassCode = Class.ClassCode ";
            sda = new SqlDataAdapter(sqlSelect, App.connectionApp);
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
                        "and semesterId  "  + semesterid;
                }
            //count how many student who are studying
                int ss = 0;
            for(int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value.ToString().Equals("Studying")) 
                    ss++;
            }
            label4.Text = " Total Studying Student(s): " + ss;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
             string majorS = "";
            if (radioButton1.Checked)
                majorS = "ISE";
            else if (radioButton2.Checked)
                majorS = "IBA";

            string TheCommand = "select Student.RollNo, Student.ClassCode, Student.FullName, Student.Nationality, Class.Batch, Class.Major, Semester.Name, StudentStatus.SemesterNo, StudentStatus.Status " +
                "from Student, Class, Semester, StudentStatus " +
                "where StudentStatus.RollNo = Student.RollNo " +
                "and StudentStatus.SemesterId = Semester.Id " +
                "and Student.ClassCode = Class.ClassCode " +
                    " AND (Class.Major='" + majorS.ToString() + "'  AND StudentStatus.SemesterNo = '" + comboBox1.Text.ToString() + "'" +
                   "AND StudentStatus.Status='" + comboBox2.Text.ToString() + "' )";
            SqlConnection MyConnection = new SqlConnection(App.connectionApp);
            SqlDataAdapter sda = new SqlDataAdapter(TheCommand, MyConnection);

            DataSet MyDataSet = new DataSet();
            MyConnection.Open();

           sda.Fill(MyDataSet, "FilterTable");
            MyConnection.Close();
            dataGridView1.DataSource = MyDataSet;
            dataGridView1.DataMember = "FilterTable";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string majorS = "";
            if (radioButton1.Checked)
                majorS = "ISE";
            else if (radioButton2.Checked)
                majorS = "IBA";

            string TheCommand = "select Student.RollNo, Student.ClassCode, Student.FullName, Student.Nationality, Class.Batch, Class.Major, Semester.Name, StudentStatus.SemesterNo, StudentStatus.Status " +
                 "from Student, Class, Semester, StudentStatus " +
                 "where StudentStatus.RollNo = Student.RollNo " +
                 "and StudentStatus.SemesterId = Semester.Id " +
                 "and Student.ClassCode = Class.ClassCode " +
                     " AND (Class.Major='" + majorS.ToString() + "'  AND StudentStatus.SemesterNo = '" + comboBox1.Text.ToString() + "'" +
                    "AND StudentStatus.Status='" + comboBox2.Text.ToString() + "' )";
            SqlConnection MyConnection = new SqlConnection(App.connectionApp);
            SqlDataAdapter sda = new SqlDataAdapter(TheCommand, MyConnection);

            DataSet MyDataSet = new DataSet();
            MyConnection.Open();

            sda.Fill(MyDataSet, "FilterTable");
            MyConnection.Close();
            dataGridView1.DataSource = MyDataSet;
            dataGridView1.DataMember = "FilterTable";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string majorS = "";
            if (radioButton1.Checked)
                majorS = "ISE";
            else if (radioButton2.Checked)
                majorS = "IBA";

            string TheCommand = "select Student.RollNo, Student.ClassCode, Student.FullName, Student.Nationality, Class.Batch, Class.Major, Semester.Name, StudentStatus.SemesterNo, StudentStatus.Status " +
                "from Student, Class, Semester, StudentStatus " +
                "where StudentStatus.RollNo = Student.RollNo " +
                "and StudentStatus.SemesterId = Semester.Id " +
                "and Student.ClassCode = Class.ClassCode " +
                    " AND (Class.Major='" + majorS.ToString() + "'  AND StudentStatus.SemesterNo = '" + comboBox1.Text.ToString() + "'" +
                   "AND StudentStatus.Status='" + comboBox2.Text.ToString() + "' )";
            SqlConnection MyConnection = new SqlConnection(App.connectionApp);
            SqlDataAdapter sda = new SqlDataAdapter(TheCommand, MyConnection);

            DataSet MyDataSet = new DataSet();
            MyConnection.Open();

           sda.Fill(MyDataSet, "FilterTable");
            MyConnection.Close();
            dataGridView1.DataSource = MyDataSet;
            dataGridView1.DataMember = "FilterTable";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string majorS = "";
            if (radioButton1.Checked)
                majorS = "ISE";
            else if (radioButton2.Checked)
                majorS = "IBA";

            string TheCommand = "select Student.RollNo, Student.ClassCode, Student.FullName, Student.Nationality, Class.Batch, Class.Major, Semester.Name, StudentStatus.SemesterNo, StudentStatus.Status " +
                 "from Student, Class, Semester, StudentStatus " +
                 "where StudentStatus.RollNo = Student.RollNo " +
                 "and StudentStatus.SemesterId = Semester.Id " +
                 "and Student.ClassCode = Class.ClassCode " +
                     " AND (Class.Major='" + majorS.ToString() + "'  AND StudentStatus.SemesterNo = '" + comboBox1.Text.ToString() + "'" +
                    "AND StudentStatus.Status='" + comboBox2.Text.ToString() + "' )";
            SqlConnection MyConnection = new SqlConnection(App.connectionApp);
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter(TheCommand, MyConnection);

            DataSet MyDataSet = new DataSet();
            MyConnection.Open();

            MyDataAdapter.Fill(MyDataSet, "FilterTable");
            MyConnection.Close();
            dataGridView1.DataSource = MyDataSet;
            dataGridView1.DataMember = "FilterTable";
        }

       
        }
        }
    