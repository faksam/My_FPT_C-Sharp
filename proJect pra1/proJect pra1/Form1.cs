using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace proJect_pra1
{
    public partial class Form1 : Form
    {
        public static string strconn = "server=localhost;tieu;inntegered security=true";
        public Form1()
        {
            InitializeComponent();
            
        }
        ArrayList list = new ArrayList();
       
        private void button2_Click(object sender, EventArgs e)
        {
            
                var closeMsg = MessageBox.Show("Do you really want to close?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (closeMsg == DialogResult.Yes)
                {
                    Application.Exit(); //close addFile form
                }
                else
                {
                    //ignore closing event
                }
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
             string items = textBox1.Text;
             string items2 = textBox2.Text;
             string items3 = comboBox1.Text; 
            list.Add(items);
            if (string.IsNullOrEmpty(items) || string.IsNullOrEmpty(items2) || string.IsNullOrEmpty(items3)) ;
            {
                MessageBox.Show("the boxs are Empty!!");
                return;

            }
     
        }
    }
}
