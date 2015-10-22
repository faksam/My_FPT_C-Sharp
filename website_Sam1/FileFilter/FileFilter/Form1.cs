using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileFilter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog od = new OpenFileDialog();
        SaveFileDialog sv = new SaveFileDialog();
       
        private void button1_Click(object sender, EventArgs e)
        {
            try{
            //od.ShowDialog();
            //od.Filter = "txt|*.txt";
            if(od.ShowDialog()== DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(od.FileName);
                //textBox2.Text = od.SafeFileName;
              label1.Text = od.FileName;
                }
            }
            catch(Exception ex){
                    MessageBox.Show(ex.Message,"INfo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(sv.FileName);
                    sw.Write(textBox1.Text);
                   
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "INfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
