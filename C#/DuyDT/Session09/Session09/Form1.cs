using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Session09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.Activated += new EventHandler(Form1_Activated);
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            this.Deactivate += new EventHandler(Form1_Deactivate);
        }

        void Form1_Deactivate(object sender, EventArgs e)
        {
            log("Form Deactived");
        }

        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            log("Form closed");
        }

        void Form1_Activated(object sender, EventArgs e)
        {
            log("Form activated");
        }
        void log(string s)
        {
            //save s to log.txt file
            StreamWriter sw = new StreamWriter("log.txt", true);
            sw.WriteLine(s);
            sw.Close();
        }
        void Form1_Load(object sender, EventArgs e)
        {
            log("Form load");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            log("Form closing");
            //confirm before closing form
            if (MessageBox.Show("Close application?",
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*to do list
             * 1. Open the OpenFileDialog 
             * 2. load the content of selected file into richtextbox
             * 3. write down file name of selected to status bar
             */
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All file(*.*)|*.*|CS file (*.cs)|*.cs";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selected = ofd.FileName;
                StreamReader sr = new StreamReader(selected);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                toolStripStatusLabel1.Text = selected;
            }
        }
    }
}
