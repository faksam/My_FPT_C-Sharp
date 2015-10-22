using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Session09
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        //return true if Username is valid, otherwise return false
        bool IsValidUsername()
        {
            string username = textBox1.Text;
            if(string.IsNullOrEmpty(username))
                return false;
            foreach(char c in username.ToCharArray())                           //duyet tat ca cac chu cai cua username
            {
                if (!char.IsLetter(c)) return false;
            }
            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsValidUsername())
            {
                MessageBox.Show("Username is not valid!");                      //hien thi thong bao loi
                textBox1.Focus();                                               //dua tro chuot vao o bi loi
                return;
            }

            string password = textBox2.Text;
            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                errorProvider1.SetError(textBox2, "Password must have at least 6 characters!");
                textBox2.Focus();
                return;
            }
            errorProvider1.Clear();

            if (checkBox1.Checked == false && checkBox2.Checked == false)
            {
                label6.Text = "Hobby must be choosen!";
                checkBox1.Focus();
                return;
            }
            label6.Text = "";
            MessageBox.Show("Your information has been sent.");
        }
    }
}
