using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Session09
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //save total forms
        int cnt = 0;
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*to do list
             * 1. make a new form
             * 2. make new form as MdiChilForm
             * 3.show a new form
             * */
            Form f = new Form();
            f.Text = "Form" + cnt++;
            f.MdiParent = this;
            f.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ActiveForm != null)
                ActiveForm.Close();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
                f.Close();
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);

        }

               
    }
}
