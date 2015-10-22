using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace workship_one
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str1 = textBox1.Text;
            String str2 = textBox2.Text;
            String str3 = textBox3.Text;
            String str4 = textBox4.Text;

            if (String.IsNullOrEmpty(str1) || String.IsNullOrEmpty(str2) || String.IsNullOrEmpty(str3) 
                || String.IsNullOrEmpty(str4))
            {
                MessageBox.Show("your Boxs are Empty"); 
                return;
            }
           
            
            int st = 0;
            if (int.TryParse(str1, out st) == false)
            {
                MessageBox.Show("it's must be an integer Number ");
                return;
            }
            if(st < 1990 || st > 2015) {
                MessageBox.Show(" the range of (1990-2015) BUT You're out of Range");
                return;
                
            }
            double st2=0;
            if (double.TryParse(str2, out st2) == false)
            {
                MessageBox.Show("Please a numberic");
                return; 
            }
            if (st2 < 0) {
                MessageBox.Show("must be greater than or equals to zero");
                return;
            }
            double st3=0;
            if (double.TryParse(str3, out st3) == false)
            {
                
                    MessageBox.Show("Have to be a  numberic");
                    return;
                
            }
            if (st3 <= 0) {
                MessageBox.Show("Have to be a positive number");
                return;
            }
            double st4 = 0;
            if (double.TryParse(str4, out st4) == false)
            {
                
                    MessageBox.Show("Have to be a numberic");
                    return;
                
            }
            if (st4 <= 0)
            {
                MessageBox.Show("Have to be a positive number");
                return;
            }
            MessageBox.Show("Manufacetured year:" + str1 + "\nAlcohol:" 
                + str2 + "\nCapacity:" + str3 + "\nPrice :" + str4);
            return;


            
        }

        }
    }

