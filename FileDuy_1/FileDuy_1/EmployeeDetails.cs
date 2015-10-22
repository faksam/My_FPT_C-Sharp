using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace FileDuy_1
{
    public partial class EmployeeDetails : Form
    {
        public EmployeeDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String En = textBox1.Text.ToUpper();
            String Ea = textBox2.Text;
            String Dj = maskedTextBox1.Text;
            String Lb = listBox1.Text;
            String Cb = comboBox1.Text;

           

            if (String.IsNullOrEmpty(En) || String.IsNullOrEmpty(Ea) || String.IsNullOrEmpty(Dj)
                )
                 
            {
                MessageBox.Show("your Boxs are Empty");
                return;
            }

           
            MessageBox.Show("Employee Name: " + En + "\nEmployee Address: "
               + Ea + "\nDate Of Joining: " + Dj + "\nEducation: " + Lb + "\nDepartment: " + Cb);
            return;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            listBox1.Text = "";
            comboBox1.Text = "";
            {
                MessageBox.Show("All your Text has been Clear!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();

;

            
        }
    }
}
