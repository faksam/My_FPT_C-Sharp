using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace MycollecetionsCaseStudy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ArrayList lists = new ArrayList();
        object obj;
        private void button1_Click(object sender, EventArgs e)
        {
             string items = textBox1.Text;
            lists.Add(items);

        }
       

        private void button2_Click(object sender, EventArgs e)
        {
           int m;
            textBox1.Text = " ";
            for(int i = 0; i < lists.Count; i++)
            {
                if(int.TryParse(lists[i].ToString(), out m) == true)
                {
                    obj = lists[i];
                    string oldValue = textBox1.Text;
                    string newValue = obj.ToString();
                    textBox1.Text = " "+ oldValue + " " + newValue;
                }
                MessageBox.Show(m + " ");
            }
           
             
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text =" ";
         for(int i = 0; i < lists.Count; i++)
            {
                object obj = lists[i];
                string oldvalue = textBox1.Text;
                string newvalue = obj.ToString();
                textBox1.Text = oldvalue + " " + newvalue;

            }
        }
            
        }
    }
}
