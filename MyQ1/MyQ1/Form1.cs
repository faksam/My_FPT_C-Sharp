using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MyQ1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sw1 = textBox1.Text;
            String sw2 = textBox2.Text;
            String sw3 = textBox3.Text;
            String sw4 = textBox4.Text;
            String sw5 = textBox5.Text;
            try
            {
                using (StreamWriter writer = new StreamWriter("C:\\data.txt", true))
                {
                    writer.Write(sw1 + "" + sw2 + "" + sw3 + "" + sw4 + "" + sw5);


                }
            }

        }
    }
}