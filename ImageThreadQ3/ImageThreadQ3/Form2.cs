using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ImageThreadQ3
{
    public partial class Form2 : Form
    {
        int i = 0;
        Thread t = null;
        //thread schedule
        public void Run()
        {
            while (true)
        {
            Image img = imageList1.Images[i];
            pictureBox1.Image = img;
            i++;
            if(i >= imageList1.Images.Count) i = 0;
            Thread.Sleep(1000);
        }

        }
        public Form2()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(t == null)
            {
                //make and start a new thread
                ThreadStart ts = new ThreadStart(Run);
                t = new Thread(ts);
                t.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(t != null)
            {
                t.Abort();
                t = null;
            }
        }
    }
}
