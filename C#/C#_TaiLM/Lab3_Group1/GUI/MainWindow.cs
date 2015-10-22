using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lab3_Group1.DAL;
using Lab3_Group1.GUI;

namespace Lab3_Group1.GUI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookGUI f = new BookGUI();
            Utility.Embed(panel1, f);
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrowerGUI f = new BorrowerGUI();
            Utility.Embed(panel1, f);
        }

        private void borrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrowGUI f = new BorrowGUI();
            Utility.Embed(panel1, f);
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnGUI f = new ReturnGUI();
            Utility.Embed(panel1, f);
        }

        private void reserveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReserveGUI f = new ReserveGUI();
            Utility.Embed(panel1, f);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        
    }
}
