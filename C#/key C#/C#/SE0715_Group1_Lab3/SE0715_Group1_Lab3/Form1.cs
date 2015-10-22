using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SE0715_Group1_Lab3.DTL;
using SE0715_Group1_Lab3.BLL;

namespace SE0715_Group1_Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Controller.Initialize();
            
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            BookUI bookUI = new BookUI();
            bookUI.FormBorderStyle = FormBorderStyle.None;
            bookUI.TopLevel = false;
            bookUI.Visible = true;
            bookUI.Dock = DockStyle.Fill;
            panel1.Controls.Add(bookUI);
            panel1.Show();
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            MemberUI memberUI = new MemberUI();
            memberUI.FormBorderStyle = FormBorderStyle.None;
            memberUI.TopLevel = false;
            memberUI.Visible = true;
            memberUI.Dock = DockStyle.Fill;
            panel1.Controls.Add(memberUI);
            panel1.Show();
        }

        private void borrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrowUI borrowUI = new BorrowUI();
            panel1.Controls.Clear();
            borrowUI.FormBorderStyle = FormBorderStyle.None;
            borrowUI.TopLevel = false;
            borrowUI.Visible = true;
            borrowUI.Dock = DockStyle.Fill;
            panel1.Controls.Add(borrowUI);
            panel1.Show();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnUI returnUI = new ReturnUI();
            panel1.Controls.Clear();
            returnUI.FormBorderStyle = FormBorderStyle.None;
            returnUI.TopLevel = false;
            returnUI.Visible = true;
            returnUI.Dock = DockStyle.Fill;
            panel1.Controls.Add(returnUI);
            panel1.Show();
        }

        private void reserveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReserveUI reserveUI = new ReserveUI();
            panel1.Controls.Clear();
            reserveUI.FormBorderStyle = FormBorderStyle.None;
            reserveUI.TopLevel = false;
            reserveUI.Visible = true;
            reserveUI.Dock = DockStyle.Fill;
            panel1.Controls.Add(reserveUI);
            panel1.Show();
        }
    }
}
