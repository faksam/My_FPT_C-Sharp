using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SM_project.GUI;

namespace SM_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label3.Parent = pictureBox2;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
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
        }
    }
}
