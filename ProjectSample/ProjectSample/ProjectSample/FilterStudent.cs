using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ProjectSample
{
    public partial class FilterStudent : Form
    {
        public FilterStudent()
        {
            InitializeComponent();
        }
        DataSet MyDataSet = new DataSet();
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string majorS = "";
            if (radioButton1.Checked)
                majorS = "ISE";
            else if (radioButton2.Checked)
                majorS = "IBA";

            string TheCommand = "Select Student.RollNo,Class.ClassCode,FullName, "
                    + "Nationality,Batch,Major,SemesterId,SemesterNo,Status_ "
                    + " From Student,StudentStatus,Class Where (Class.Major='" + majorS.ToString() + "'  AND StudentStatus.SemesterNo = '" + comboBox1.Text.ToString()
                    + "' AND StudentStatus.Status_='" + comboBox2.Text.ToString() + "' AND Class.ClassCode=Student.ClassCode AND Student.RollNo=StudentStatus.RollNo)";
            SqlConnection MyConnection = new SqlConnection("Data Source=FAKSAM;Initial Catalog=Project_CNET;Integrated Security=True");
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter(TheCommand, MyConnection);

            DataSet MyDataSet = new DataSet();
            MyConnection.Open();

            MyDataAdapter.Fill(MyDataSet, "FilterTable");
            MyConnection.Close();
            dataGridView1.DataSource = MyDataSet;
            dataGridView1.DataMember = "FilterTable";
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string majorS = "";
            if (radioButton1.Checked)
                majorS = "ISE";
            else if (radioButton2.Checked)
                majorS = "IBA";

            string TheCommand = "Select Student.RollNo,Class.ClassCode,FullName, "
                    + "Nationality,Batch,Major,SemesterId,SemesterNo,Status_ "
                    + " From Student,StudentStatus,Class Where (Class.Major='" + majorS.ToString() + "'  AND StudentStatus.SemesterNo = '" + comboBox1.Text.ToString()
                    + "' AND StudentStatus.Status_='" + comboBox2.Text.ToString() + "' AND Class.ClassCode=Student.ClassCode AND Student.RollNo=StudentStatus.RollNo)";
            SqlConnection MyConnection = new SqlConnection("Data Source=FAKSAM;Initial Catalog=Project_CNET;Integrated Security=True");
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter(TheCommand, MyConnection);

            DataSet MyDataSet = new DataSet();
            MyConnection.Open();

            MyDataAdapter.Fill(MyDataSet, "FilterTable");
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

            string TheCommand = "Select Student.RollNo,Class.ClassCode,FullName, "
                    + "Nationality,Batch,Major,SemesterId,SemesterNo,Status_ "
                    + " From Student,StudentStatus,Class Where (Class.Major='" + majorS.ToString() + "'  AND StudentStatus.SemesterNo = '" + comboBox1.Text.ToString()
                    + "' AND StudentStatus.Status_='" + comboBox2.Text.ToString() + "' AND Class.ClassCode=Student.ClassCode AND Student.RollNo=StudentStatus.RollNo)";
            SqlConnection MyConnection = new SqlConnection("Data Source=FAKSAM;Initial Catalog=Project_CNET;Integrated Security=True");
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter(TheCommand, MyConnection);

            DataSet MyDataSet = new DataSet();
            MyConnection.Open();

            MyDataAdapter.Fill(MyDataSet, "FilterTable");
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

            string TheCommand = "Select Student.RollNo,Class.ClassCode,FullName, "
                    + "Nationality,Batch,Major,SemesterId,SemesterNo,Status_ "
                    + " From Student,StudentStatus,Class Where (Class.Major='" + majorS.ToString() + "'  AND StudentStatus.SemesterNo = '" + comboBox1.Text.ToString()
                    + "' AND StudentStatus.Status_='" + comboBox2.Text.ToString() + "' AND Class.ClassCode=Student.ClassCode AND Student.RollNo=StudentStatus.RollNo)";
            SqlConnection MyConnection = new SqlConnection("Data Source=FAKSAM;Initial Catalog=Project_CNET;Integrated Security=True");
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter(TheCommand, MyConnection);

            DataSet MyDataSet = new DataSet();
            MyConnection.Open();

            MyDataAdapter.Fill(MyDataSet, "FilterTable");
            MyConnection.Close();
            dataGridView1.DataSource = MyDataSet;
            dataGridView1.DataMember = "FilterTable";
        }
        private void FilterSelection()
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
