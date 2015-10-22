using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyProject_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            AddClass newfor = new AddClass();
            newfor.MdiParent = this;
            newfor.Show();
           
           
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addSemesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSemester newSemester = new AddSemester();
            newSemester.MdiParent = this;
            newSemester.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent newStudent = new AddStudent();
            newStudent.MdiParent = this;
            newStudent.Show();
        }

        private void addStudentClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentClass newStudentClass = new AddStudentClass();
            newStudentClass.MdiParent = this;
            newStudentClass.Show();
        }

        private void updateStudentStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStudentStatus newStudentStatus = new UpdateStudentStatus();
            newStudentStatus.MdiParent = this;
            newStudentStatus.Show();
        }

        private void filterStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterStudent newFilter = new FilterStudent();
            newFilter.MdiParent = this;
            newFilter.Show();
        }
    }
}
