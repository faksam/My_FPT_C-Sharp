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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
             * to do list
             * open file dialog
             * set v = selected file
             * insect the name of v to textbox1
             * insect the content of v to textbox2
             */
            OpenFileDialog ofd = new OpenFileDialog();
            //disble multiselection
            ofd.Multiselect = false;
            ///set filter for ofd, only accept txt file
            ofd.Filter = "Text file(*.txt)|*.txt|CS file(*.CS) | *.CS";
            // show openfiledialog and if user select open button
            if (ofd.ShowDialog () == System.Windows.Forms.DialogResult.OK)
            {
                //2 get select file
                String v = ofd.FileName;
                //3
                textBox1.Text = v;
                //4
                StreamReader sr = new StreamReader(v);
                //get all the content of v and insect to textbox2
                textBox2.Text = sr.ReadToEnd();
                sr.Close();//close stream





            }
        }
    }
}
