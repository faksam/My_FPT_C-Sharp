using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SE0715_Group1_Lab3.BLL;
using SE0715_Group1_Lab3.DAL;
using SE0715_Group1_Lab3.DTL;

namespace SE0715_Group1_Lab3
{
    public partial class BorrowUI : Form
    {
        public BorrowUI()
        {
            InitializeComponent();
            setStart();
        }

        public void setStart()
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BorrowDA b = new BorrowDA();

            BorrowBL a = new BorrowBL();
            int code = 0;
            try
            {
                code = int.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


            bool test = a.checkMember(code);
            if (!test)
            {
                MessageBox.Show("Don't have this member in Database");
                return;
            }

            else
            {
                DataSet ds = b.SelectDS(code);
                DataView dv = new DataView(ds.Tables[0]);
                dataGridView1.DataSource = dv;
                textBox2.Text = b.getName(code);
                textBox3.Enabled = true;
                button2.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button1.Enabled = false;
            }

        }



        private void button2_Click(object sender, EventArgs e)
        {
            BorrowBL a = new BorrowBL();
            BorrowDA b = new BorrowDA();

            int code = 0;
            try
            {
                code = int.Parse(textBox3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            bool test = a.checkCopy(code);
            if (!test)
            {
                MessageBox.Show("You can't borrow this copy !");
                return;
            }


            bool test1 = a.checkFive(int.Parse(textBox1.Text));
            if (!test1)
            {
                MessageBox.Show("You have borrowed 5 copies !");
                return;
            }
            bool test2 = a.checkReserve1(code);
            if (!test2)
            {
                textBox4.Text = DateTime.Now.ToString("d/M/yyyy");
                textBox3.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = true;
                textBox4.Enabled = true;
            }
            else
            {
                bool test3 = a.checkReserve(code, b.getBoNum(code), int.Parse(textBox1.Text));
                //MessageBox.Show("" + a.checkReserve1(code));
                if (!test3)
                {
                    MessageBox.Show("This book have resserved by other person !");
                    
                    return;
                }
                else
                {
                    
                    textBox3.Enabled = false;
                    textBox4.Text = DateTime.Now.ToString("d/M/yyyy");
                    button2.Enabled = false;
                    textBox4.Enabled = true;
                    button3.Enabled = true;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BorrowBL a = new BorrowBL();
            BorrowDA b = new BorrowDA();
            DateTime brDate = new DateTime();
            try
            {
                brDate = DateTime.ParseExact(textBox4.Text, "d/M/yyyy", null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            DateTime dueDate = brDate.AddDays(14);
            textBox5.Text = dueDate.ToShortDateString();
            int copyNum = int.Parse(textBox3.Text);
            int brNum = int.Parse(textBox1.Text);
            CirculatedCopy h = new CirculatedCopy();
            a.SetIdMax();
            h.Id = ++a.idMax;
            h.CopyNumber = copyNum;
            h.BorrowerNumber = brNum;
            h.BorrowedDate = brDate;
            h.DueDate = dueDate;
            b.insertBorrow(h);
            b.borrowUpdate(copyNum);
            DataSet ds = b.SelectDS(brNum);
            DataView dv = new DataView(ds.Tables[0]);
            dataGridView1.DataSource = dv;
            bool test2 = a.checkReserve1(copyNum);
            bool test3 = a.checkReserve(copyNum, b.getBoNum(copyNum), int.Parse(textBox1.Text));
            if (test2 && test3)
            {
                b.borrowReUpdate(b.getBoNum(copyNum), int.Parse(textBox1.Text));
            }
            button3.Enabled = false;
        }

    }
}
