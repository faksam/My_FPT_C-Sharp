using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Delegatessample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click); 
            button1.Click +=new EventHandler(button1_Click);
            button1.Click += new EventHandler(button1_Click);
            button1.Click -= button1_Click;
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get selected value
            string major = comboBox1.SelectedItem.ToString();
            MessageBox.Show("your selected major is: " + major);
        }
        int cnt = 0;

        void button1_Click(object sender, EventArgs e)
        {
            cnt++;
            MessageBox.Show("you have click me" + cnt + "time(s)");
            if (cnt == 10)
            {
                MessageBox.Show("tai is stupid man");
            }
        }
    }
}
