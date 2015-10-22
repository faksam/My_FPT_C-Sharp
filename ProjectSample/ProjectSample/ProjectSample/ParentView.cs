using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectSample
{
    public partial class ParentView : Form
    {
        public ParentView()
        {
            InitializeComponent();
            ArrayList ListStatus = new ArrayList();

            ArrayList ListSemesterName = new ArrayList();

            ArrayList ListSemesterNo = new ArrayList();

            ArrayList ListClassCode = new ArrayList();

            ArrayList ListMajor = new ArrayList();

        }

            

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form AClass = new AddClass();
            AClass.MdiParent = this;
            AClass.Show();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form AStudent = new AddStudent();
            AStudent.MdiParent = this;
            AStudent.Show();
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FilterStu = new FilterStudent();
            FilterStu.MdiParent = this;
            FilterStu.Show();
        }

        private void updateStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Upstudent = new UpdateStudentStatus();
            Upstudent.MdiParent = this;
            Upstudent.Show();
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form AddSem = new AddSemester();
            AddSem.MdiParent = this;
            AddSem.Show();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form AddStuClass = new AddStudentClass();
            AddStuClass.MdiParent = this;
            AddStuClass.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newParent = new ParentView();
            newParent.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentView.ActiveForm.Close();
        }
        public void formCloser(Form fr)
        {
            //fr.ActiveMdiChild.Close();

        }
    }
}
