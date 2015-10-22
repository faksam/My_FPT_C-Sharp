using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectSample
{
    public partial class AddClass : Form
    {
        public AddClass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //(sender as Button).Parent.Dispose();
            this.Close();
        }

        private void AddClass_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string TheCommand="";
            if(textBox1.Text=="" || textBox2.Text=="" || comboBox1.SelectedIndex<0 )
            {
                MessageBox.Show("All fields must be filled!!!");
            }
            else
            {   
                TheCommand = " IF EXISTS (SELECT * FROM Class WHERE ClassCode='" + textBox1.Text+"') "  
	                        +"SELECT ClassCode From Class where ClassCode='" + textBox1.Text+"'"
                            +" ELSE INSERT INTO Class(ClassCode,Batch,Major) Values "+
                   "('" + textBox1.Text +
                    "'," + "'" + textBox2.Text + "','" + comboBox1.SelectedItem.ToString()+"')";
                 
                ExcSQL pv = new ExcSQL(4,TheCommand);
            }
            
        }
    }
}
