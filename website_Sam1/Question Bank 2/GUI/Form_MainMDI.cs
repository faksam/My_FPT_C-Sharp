using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_MainMDI : Form
    {
        public Form_MainMDI()
        {
            InitializeComponent();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void topicManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_TopicManagement tm = new Form_TopicManagement();
            tm.MdiParent = this;
            tm.Show();
        }

        private void menuQuestionManagement_Click(object sender, EventArgs e)
        {
            Form_QuestionManagement qm = new Form_QuestionManagement();
            qm.MdiParent = this;
            qm.Show();
        }

        private void menuCreateTest_Click(object sender, EventArgs e)
        {
            Form_CreateTest ct = new Form_CreateTest();
            ct.MdiParent = this;
            ct.Show();
        }
    }
}
