using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoLab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
        private void projectDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectDetails f = new ProjectDetails("Human Resource", "MicroSoft", new DateTime(2008, 8, 27), new DateTime(2008, 12, 27), "Vista Business", "CentrinoDualCore");
            f.Text = "ProjectDetails";
            f.MdiParent = this;
            f.Show();
            
           
            
        }

       


       
    }
}
