using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SM_project.Data.Access;
using SM_project.GUI;
using SM_project.Class;

namespace SM_project
{
    public partial class LoginGUI : Form
    {
        public LoginGUI()
        {
            InitializeComponent();
            label3.Parent = pictureBox2;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text;
            LoginCL login = SelectDA.getUser(username);
            if (login == null)
            {
                MessageBox.Show("Invalid user or password ! Please try again !");
            }
            else{
                if (password.Equals(login.Pass))
                {
                    HomeGUI home = new HomeGUI(this, login);
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid user or password ! Please try again !");
                }
            }
        }
    }
}
