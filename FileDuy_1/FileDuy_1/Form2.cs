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
    public partial class Form2 : Form
    { 
        //save life cycle of a for to text file
        public void log(String msg)
        {
            //open file cycle of a form to text file
            StreamWriter sw = new StreamWriter("log.txt", true);
            sw.WriteLine(msg);
            sw.Close();
        }
        public Form2()
        {
            InitializeComponent();
            Load += Form2_Load;
            Activated += Form2_Activated;
            Deactivate += Form2_Deactivate;
            FormClosing += Form2_FormClosing;
            FormClosed += Form2_FormClosed;
        }

        void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            log("Form CLosed");
            //throw new NotImplementedException();
        }

        void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            log("Form Closing");
            //throw new NotImplementedException();
        }

        void Form2_Deactivate(object sender, EventArgs e)
        {
            log("Form Deactivated");
            //throw new NotImplementedException();
        }

        void Form2_Activated(object sender, EventArgs e)
        {
            log("FormActivated");
            //throw new NotImplementedException();
        }

        void Form2_Load(object sender, EventArgs e)
        {
            log("Form Load");
            //throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("you have just Clicked Me!!");
        }
    }
}
