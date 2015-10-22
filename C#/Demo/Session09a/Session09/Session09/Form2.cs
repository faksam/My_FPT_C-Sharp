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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void horizolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* To do list
             * 1. Make a new form
             * 2. Make a new form as MdiChilForm
             * 3. Show a new form
             */
            Form f = new Form();
            f.Text = "Form " + cnt++;
            f.MdiParent = this;
            f.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        

    }
}
