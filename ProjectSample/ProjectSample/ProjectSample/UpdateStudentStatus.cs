using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectSample
{
    public partial class UpdateStudentStatus : Form
    {
        
        public UpdateStudentStatus()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (sender as Button).Parent.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string TheCommand = "";
            if (textBox1.Text == "" )
            {
                MessageBox.Show("You must Enter a rollno!!!");
            }
            else
            {
                TheCommand = "update StudentStatus set " 
                +"SemesterId = '"+comboBox2.Text+"', SemesterNo = "
                +textBox3.Text+ ", Status_ = '"+comboBox3.Text+ "' WHERE ROllNo = '"
                +textBox1.Text+"'";

                ExcSQL pv = new ExcSQL(1,TheCommand);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string TheCommand = "";
            if (textBox1.Text == "" )
            {
                MessageBox.Show("Roll No cannot be Empty!!!");
            }
            else
            {
                TheCommand = "SELECT FullName,ClassCode FROM Student WHERE RollNo = '" + textBox1.Text+"'";
                ExcSQL pv = new ExcSQL(2, TheCommand);
                textBox2.Text = pv.FullName;
                comboBox1.Text = pv.ClassCode;
            }
        }
    }
}
