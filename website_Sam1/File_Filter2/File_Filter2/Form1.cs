using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace File_Filter2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog op = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            op.Title = "Open File";
            op.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                StreamReader re = new StreamReader( File.OpenRead(op.FileName));
                textBox1.Text = re.ReadToEnd();
                textBox2.Text = op.SafeFileName + "   \n"+op.FileName;
                re.Dispose();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sa = new SaveFileDialog();
            sa.Title = "Save File";
            op.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            if(sa.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {

                StreamWriter stw = new StreamWriter(File.Create(sa.FileName));
                stw.Write(textBox1.Text);
                stw.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }
    }
}
