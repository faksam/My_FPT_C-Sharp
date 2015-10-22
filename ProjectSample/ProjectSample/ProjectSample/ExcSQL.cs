using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace ProjectSample
{
    class ExcSQL
    {
        private string classCode;
        public string ClassCode
        {
            get { return classCode; }
            set { classCode = value; }
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        private string semesterName;
        public string SemesterName
        {
            get { return semesterName; }
            set { semesterName = value; }
        }

        private string rollNo;
        public string RollNo
        {
            get { return rollNo; }
            set { rollNo = value; }
        }

        private string semesterNo;
        public string SemesterNo
        {
            get { return semesterNo; }
            set { semesterNo = value; }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }



        public void TheSave(string PassedCommands)
        {
            
            SqlConnection MyConnection = new SqlConnection("Data Source=FAKSAM;Initial Catalog=Project_CNET;Integrated Security=True");
            SqlCommand MyCommand;
            MyConnection.Open();
            MyCommand = new SqlCommand(PassedCommands, MyConnection);
            MyCommand.ExecuteNonQuery();
            MyConnection.Close();
        }


        public void TheSearchParent()
        {
            string PassedCommands = "SELECT SemesterId,SemesterNo,Status_ FROM StudentStatus WHERE RollNo = '";// + //textBox1.Text + "'";
            SqlConnection MyConnection = new SqlConnection("Data Source=FAKSAM;Initial Catalog=Project_CNET;Integrated Security=True");
            SqlCommand MyCommand;
            MyConnection.Open();
            MyCommand = new SqlCommand(PassedCommands, MyConnection);
            var dr = MyCommand.ExecuteReader();

            if (dr.HasRows == false)
            {
                MessageBox.Show("RollNo not found!!!");
                //throw new Exception();
            }
            if (dr.Read())
            {
                SemesterName = dr[0].ToString();
                SemesterNo = dr[1].ToString();
                Status = dr[2].ToString();
            }
            MyConnection.Close();
        }

        public void TheSearch1(string PassedCommands)
        {

            SqlConnection MyConnection = new SqlConnection("Data Source=FAKSAM;Initial Catalog=Project_CNET;Integrated Security=True");
            SqlCommand MyCommand;
            MyConnection.Open();
            MyCommand = new SqlCommand(PassedCommands, MyConnection);
            var dr = MyCommand.ExecuteReader();

            if (dr.HasRows == false)
            {
                MessageBox.Show("RollNo not found!!!");
                throw new Exception();
            }
            if (dr.Read())
            {
                FullName = dr[0].ToString();
                ClassCode = dr[1].ToString();
            }
            MyConnection.Close();
        }

        public void TheSearch2(string PassedCommands)
        {

            SqlConnection MyConnection = new SqlConnection("Data Source=FAKSAM;Initial Catalog=Project_CNET;Integrated Security=True");
            SqlCommand MyCommand;
            MyConnection.Open();
            MyCommand = new SqlCommand(PassedCommands, MyConnection);
            var dr = MyCommand.ExecuteReader();

            if (dr.HasRows == false)
            {
                MessageBox.Show("RollNo not found!!!");
                //throw new Exception();
            }
            if (dr.Read())
            {
                SemesterName = dr[0].ToString();
                SemesterNo = dr[1].ToString();
                Status = dr[2].ToString();
            }
            MyConnection.Close();
        }

        public void TheSearch3(string PassedCommands)
        {
            SqlConnection MyConnection = new SqlConnection("Data Source=FAKSAM;Initial Catalog=Project_CNET;Integrated Security=True");
            SqlCommand MyCommand;
            MyConnection.Open();
            MyCommand = new SqlCommand(PassedCommands, MyConnection);
            var dr = MyCommand.ExecuteReader();

            if (dr.HasRows == false)
            {
                TheSave(PassedCommands);
                MessageBox.Show("Student Class Saved");
                //throw new Exception();
            }
            if (dr.Read())
            {
                string Value="";
                 Value = dr[0].ToString();
                MessageBox.Show(Value + " already Exists!!!");
            }
            MyConnection.Close();
        }

        public ExcSQL()
        { }
        public ExcSQL(int caseSwitch,string PassedCommands)
        {
            switch (caseSwitch)
            {
                case 1:
                    TheSave(PassedCommands);
                    break;
                case 2:
                    TheSearch1(PassedCommands);
                    break;
                case 3:
                    TheSearch2(PassedCommands);
                    break;
                case 4:
                    TheSearch3(PassedCommands);
                    break;

                default:
                    MessageBox.Show("No Action Performed");
                    break;
            }
        }
    }
}
