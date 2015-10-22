﻿using System;
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
    public partial class SemesterDisplay : Form
    {
        public SemesterDisplay()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
             SqlDataAdapter sqlDA = new SqlDataAdapter("select distinct * from StudentStatus", App.ConnectionString);
            DataSet ds = new DataSet();
            //copy db to ds
            sqlDA.Fill(ds, "StudentStatus");
            
            string sqlselect = "select  Student.RollNo,Student.ClassCode,FullName,Nationality,Batch,Major,Name,SemesterNo,Status " +
                    "from StudentStatus,Student,Class,Semester where Student.RollNo = StudentStatus.RollNo and StudentStatus.SemesterId = Semester.Id and Class.ClassCode = Student.ClassCode";
            sqlDA = new SqlDataAdapter(sqlselect, App.ConnectionString);
            sqlDA.Fill(ds, "StudentStatus");
            // Copy records from ds.Tables["StudentStatus"] to dataview
            dv = new DataView(ds.Tables["StudentStatus"]);
            //Bind dv to datagridview
            dataGridView1.DataSource = dv;
            label4.Text = "Total = " + (dataGridView1.RowCount - 1) + " Number of Students."; 


        }
        DataView dv = null;
        int semesternum = 0;
        
        string sMajor = "";
        string studStatus = "";
        bool k;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0) comboBox1.SelectedIndex = 0;
            if (comboBox2.SelectedIndex < 0) comboBox2.SelectedIndex = 0;
            //if (radioButton1.Checked)
            //{
                sMajor = "ISE";
            //}
            //displayview();
            semesternum = int.Parse(comboBox1.SelectedItem.ToString());
            studStatus = comboBox2.SelectedItem.ToString();
            //filterRow
            dv.RowFilter = "Major like '%" + sMajor + "%' and SemesterNo = " + semesternum.ToString() + " and Status like '%" + studStatus + "%'";
            label4.Text = "Total = " + (dataGridView1.RowCount - 1) + " Number of Students.";
            k = true;
        }
        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0) comboBox1.SelectedIndex = 0;
            if (comboBox2.SelectedIndex < 0) comboBox2.SelectedIndex = 0;
            if (radioButton1.Checked)
            {
                sMajor = "IBA";
            }
           // displayview();
            semesternum = int.Parse(comboBox1.SelectedItem.ToString());
            studStatus = comboBox2.SelectedItem.ToString();
            //filterRow
            dv.RowFilter = "Major like '%" + sMajor + "%' and SemesterNo = " + semesternum.ToString() + " and Status like '%" + studStatus + "%'";
            label4.Text = "Total = " + (dataGridView1.RowCount - 1) + " Number of Students.";
            k = true;
        }

        
        //public void displayview()
        //{


        //    if (comboBox1.SelectedIndex < 0) comboBox1.SelectedIndex = 0;
        //    if (comboBox2.SelectedIndex < 0) comboBox2.SelectedIndex = 0;
        //    if (radioButton1.Checked)
        //    {
        //        sMajor = "ISE";
        //    }
        //    else if (radioButton2.Checked)
        //    {
        //        sMajor = "IBA";
        //    }
        //    semesternum = int.Parse(comboBox1.SelectedItem.ToString());
        //    studStatus = comboBox2.SelectedItem.ToString();
        //    filterRow = "Major like '%" + sMajor + "%' and SemesterNo = " + semesternum.ToString() + " and Status like '%" + studStatus + "%'";
           
        //}

        
    }
}
