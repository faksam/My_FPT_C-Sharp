using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectSample
{
    public partial class AddSemester : Form
    {
        public AddSemester()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //AddSemester.ActiveForm.Close();
            (sender as Button).Parent.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string TheCommand = "";
            if(textBox1.Text=="" || this.dateTimePicker1.ToString().Equals(this.dateTimePicker2.ToString()))
            {
                MessageBox.Show("Please enter valid details");
            }
            else
            {
                TheCommand = " IF EXISTS (SELECT * FROM Class WHERE Semester='" + textBox1.Text + "') "
                            + "SELECT SemesterId From Class where SemesterId='" + textBox1.Text + "'"
                    +" ELSE INSERT INTO Semester(SemesterId,Name,StartDate,EndDate) VALUES('" + textBox1.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + Convert.ToDateTime(this.dateTimePicker1.Text) + "','" + Convert.ToDateTime(this.dateTimePicker2.Text) + "')";

                ExcSQL pv = new ExcSQL(1,TheCommand);
            }
        }
    }
}
