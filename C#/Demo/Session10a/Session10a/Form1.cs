using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Session10a
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*to do list
            * 1. make sure entered text not empty
            * 2. put/append entered text to list box
                         * 
            * */
            string v = textBox1.Text;
            if (string.IsNullOrEmpty(v))
            {
                MessageBox.Show("Entered text can not be empty");
                textBox1.Focus();
                return;
            }
            listBox1.Items.Add(v);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 0)
            {
                MessageBox.Show("ListBox1 can not be empty");
                textBox1.Focus();
                return;

            }
            int i = listBox1.SelectedIndex;
            if (i >= 0)
            {
                string v = listBox1.Items[i].ToString();
                listBox2.Items.Add(v);
                listBox1.Items.RemoveAt(i);
            }
            else
            {
                MessageBox.Show("You must select at least an item");
                listBox1.SelectedIndex = 0;
                return;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                button1_Click(null, null);
        }

        
    }
}
