using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageThreadQ3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*
             * To Do list
             * 1. create form2 and open form2
             * 2. show /display form2 as a doalog
             */
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}
