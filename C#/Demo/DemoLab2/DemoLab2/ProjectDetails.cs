using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoLab2
{
    public partial class ProjectDetails : Form
    {
        public ProjectDetails()
        {
            InitializeComponent();
            
        }
        public ProjectDetails(string szName, string szClientName, DateTime date, DateTime date2, string soft, string hard)
        {
            InitializeComponent();

            textBox1.Text = szName;
            textBox2.Text = szClientName;
            comboBox2.Text = date.ToString();
            comboBox1.Text = date2.ToString();
            richTextBox1.Text = soft;
            richTextBox2.Text = hard;


        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
        }

       
        
    }
}
