using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISE091_Wind_1_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            /* To Do List
             * make sure that textbox
             * 1. can not be empty
             * 2. must be an integer number
             * 3. must be > 0
             */
            String v = textbox1.Text;
            // make that v is not empty 
            if (String.IsNullOrEmpty(v) == true)
            {
                MessageBox.Show("Sorry your box is Empty");
                return;
            }
            // make sure that v is an integer number 
            int batchNo = 0;
            if (int.TryParse(v, out batchNo) == false)
            {
                MessageBox.Show("the Batch Number must be an integer number ");
                return;
            }
            // make sure that batchNo > 0
            if(batchNo <= 0)
            {
                MessageBox.Show("Batch Number must be > 0");
                return;
            }
            MessageBox.Show("Welcome to FPT, your Batch Number is correct");
        }
    }
}
