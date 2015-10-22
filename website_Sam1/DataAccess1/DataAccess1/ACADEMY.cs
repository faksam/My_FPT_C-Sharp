using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataAccess1
{
    public partial class ACADEMY : Form
    {
        public ACADEMY()
        {
            InitializeComponent();
        }

        private void addClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addclass ad = new Addclass();
            ad.MdiParent = this;
            ad.Show();
            
        }

        private void addStudentClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentClass asc = new AddStudentClass();
            asc.MdiParent = this;
            asc.Show();
        }

        private void displaySemesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent adds = new AddStudent();
            adds.MdiParent = this;
            adds.Show();

        }

        private void updateStudentStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SemesterDisplay sd = new SemesterDisplay();
            sd.MdiParent = this;
            sd.Show();
            
        }

        private void updateStudentStatusToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateStudent upd = new UpdateStudent();
            upd.MdiParent = this;
            upd.Show();
        }

        private void dataFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataFilter df = new DataFilter();
            df.MdiParent = this;
            df.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ACADEMY dc = new ACADEMY();
           
            dc.Show();
        }
    }
}
