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
    public partial class FilterStudent : Form
    {
        public FilterStudent()
        {
            InitializeComponent();
        }

        private void studentStatusBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentStatusBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void FilterStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.StudentStatus' table. You can move, or remove it, as needed.
            this.studentStatusTableAdapter.Fill(this.dataSet1.StudentStatus);

        }
    }
}
