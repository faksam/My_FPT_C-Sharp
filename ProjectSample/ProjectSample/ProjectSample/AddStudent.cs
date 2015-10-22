using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectSample
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //AddStudent.ActiveForm.Close();
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
                TheCommand = " IF EXISTS (SELECT * FROM Class WHERE Student='" + textBox1.Text+"') "  
	                        +"SELECT RollNo From Class where RollNo='" + textBox1.Text+"'"
                    +" ELSE INSERT INTO Student(RollNo,ClassCode,FullName,Nationality) Values " +
                   "('" + textBox1.Text +  "','" + comboBox2.SelectedItem.ToString() +
                    "'," + "'" + textBox2.Text + "','" + comboBox1.SelectedItem.ToString() + "')";

                ExcSQL pv = new ExcSQL(4,TheCommand);
            }
        }
    }
}
