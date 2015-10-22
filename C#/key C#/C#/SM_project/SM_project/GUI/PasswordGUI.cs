using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SM_project.Class;
using SM_project.Data.Access;

namespace SM_project.GUI
{
    public partial class PasswordGUI : Form
    {
        LoginCL login;
        public PasswordGUI()
        {
            InitializeComponent();
        }

        public PasswordGUI(LoginCL login) : this()
        {
            this.login = login;
            txtAccount.Text = login.User;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string acc = txtAccount.Text.Trim();
            string curpass = txtCurPass.Text;
            if (SelectDA.rightPass(acc, curpass))
            {
                errorProvider1.Clear();
                string pass1 = txtNewPas1.Text;
                string pass2 = txtNewPas2.Text;
                if (pass1.Equals(pass2))
                {
                    errorProvider1.Clear();
                    UpdateDA.updatePassword(acc, pass1);
                    MessageBox.Show("Your password was changed successfull !");
                    this.Close();
                }
                else
                {
                    errorProvider1.SetError(txtNewPas2,"Re-typed password isn't match with new password ! Check your input");
                }
            }
            else
            {
                txtCurPass.Text = "";
                errorProvider1.SetError(txtCurPass,"Your have entered a wrong password ! Please try again");
            }
        }
    }
}
