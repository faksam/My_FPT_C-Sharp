using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileQ1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader objstream = new StreamReader("C:\\Users\\Mr Ibrahim akoji\\Desktop\\C.NET\\FileQ1\\data.txt");

            String textBox1 = textBox2.Text = objstream.ReadToEnd();
           

        }
    }
}
