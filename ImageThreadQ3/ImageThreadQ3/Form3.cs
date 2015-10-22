using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageThreadQ3
{
    public partial class Form3 : Form
    {
        //display current time
        void PrintTime(object obj)
        {
            DateTime today = DateTime.Now;
            int hours = today.Hour;
            int minute = today.Minute;
            int second = today.Second;
            //format time
            String time = "" + hours + ":" + minute + ":" + second;
            //display time to labell
            label1.Text = time;
        }
        Timer t = null;
        public Form3()
        {
            InitializeComponent();
            t = new Timer();
            t.Interval = 1000;
            //call the function t_Tick after every second
            t.Tick += new EventHandler(t_Tick);
        }
        void t_Tick(object sender, EventArgs e)
        {
            PrintTime(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t.Stop();
        }
    }
}
