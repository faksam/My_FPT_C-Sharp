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
    public partial class AddStudentClass : Form
    {
        public AddStudentClass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //AddStudentClass.ActiveForm.Close();
            (sender as Button).Parent.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string TheCommand = "";
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedIndex < 0 || comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("All fields must be filled!!!");
            }
            else
            {
                TheCommand = " IF EXISTS (SELECT * FROM StudentStatus WHERE RollNo='" + textBox1.Text+"') "  
	                        +"SELECT RollNo From StudentStatus where RollNo='" + textBox1.Text+"'"
                            +" ELSE INSERT INTO StudentStatus(RollNo,SemesterId,SemesterNo,Status_) Values ('"
                            + textBox1.Text +"','" + comboBox1.SelectedItem.ToString() +"','"+ textBox2.Text + "','" + comboBox2.SelectedItem.ToString() + "')";


                ExcSQL pv = new ExcSQL(4,TheCommand);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string TheCommand = "";
            if (textBox1.Text == "")
            {
                MessageBox.Show("Roll No cannot be Empty!!!");
            }
            else
            {
                TheCommand = "SELECT SemesterId,SemesterNo,Status_ FROM StudentStatus WHERE RollNo = '" + textBox1.Text + "'";
                ExcSQL pv = new ExcSQL(3, TheCommand);
                comboBox1.Text = pv.SemesterName;
                textBox2.Text = pv.SemesterNo;
                comboBox2.Text = pv.Status;
                
            }
        }
    }
}
