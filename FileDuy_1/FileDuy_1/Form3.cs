using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileDuy_1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if user and password are admin then show employeeDetail from
            String user = textBox1.Text;
            String password = textBox2.Text;
            user = user.ToLower();
            user = char.ToUpper(user[0])+ user.Substring(1);
            if(user.Equals("Admin") && password.Equals("Admin"))
            {
                EmployeeDetails ed = new EmployeeDetails();
                ed.Show();
            }
            else
            {
                MessageBox.Show("UserName or Password is not correct");
            }
        }
    }
}
