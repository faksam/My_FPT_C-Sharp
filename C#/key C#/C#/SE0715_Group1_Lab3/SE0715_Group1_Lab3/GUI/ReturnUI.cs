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
    public partial class ReturnUI : Form
    {
        public ReturnUI()
        {
            InitializeComponent();
            setStart();
        }

        public void setStart()
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ReturnDA b = new ReturnDA();

            ReturnBL a = new ReturnBL();
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
                label5.Text = "" + ds.Tables[0].Rows.Count;
                textBox2.Text = b.getName(code);
                textBox3.Enabled = true;
                textBox3.Text = DateTime.Now.ToString("dd/M/yyyy");
                button3.Enabled = true;
                textBox1.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BorrowBL a = new BorrowBL();
            BorrowDA b = new BorrowDA();
            //DateTime returnDate = new DateTime();

            CirculatedCopy c = new CirculatedCopy();
            try
            {
                c.Id = int.Parse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
                c.CopyNumber = int.Parse(dataGridView1.SelectedRows[0].Cells["copyNumber"].Value.ToString());
                c.BorrowerNumber = int.Parse(dataGridView1.SelectedRows[0].Cells["borrowerNumber"].Value.ToString());
                c.DueDate = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["dueDate"].Value.ToString());
                c.BorrowedDate = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["borrowedDate"].Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("You must select a book !");
                return;
            }
            
            try
            {
                c.ReturnedDate = DateTime.ParseExact(textBox3.Text, "d/M/yyyy", null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (c.ReturnedDate.Date < c.BorrowedDate)
            {
                MessageBox.Show("BorrowedDate must less than ReturnedDate !");
                return;
            }
            TimeSpan dayLater = c.ReturnedDate.Date - c.DueDate;
            double ngay = dayLater.TotalDays;
            if (ngay > 0)
            {
                textBox4.Text = "" + ngay;
            }
            else textBox4.Text = "0";

            dataGridView1.Enabled = false;
            textBox3.Enabled = false;
            button3.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReturnDA k = new ReturnDA();
            if (MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CirculatedCopy c = new CirculatedCopy();
                try
                {
                    c.Id = int.Parse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
                    c.CopyNumber = int.Parse(dataGridView1.SelectedRows[0].Cells["copyNumber"].Value.ToString());
                    c.BorrowerNumber = int.Parse(dataGridView1.SelectedRows[0].Cells["borrowerNumber"].Value.ToString());
                    c.DueDate = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["dueDate"].Value.ToString());
                    c.BorrowedDate = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["borrowedDate"].Value.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("You must select a book !");
                    return;
                }

                try
                {
                    c.ReturnedDate = DateTime.ParseExact(textBox3.Text, "d/M/yyyy", null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (c.ReturnedDate.Date < c.BorrowedDate)
                {
                    MessageBox.Show("BorrowedDate must less than ReturnedDate !");
                    return;
                }
                TimeSpan dayLater = c.ReturnedDate.Date - c.DueDate;
                double ngay = dayLater.TotalDays;
                if (ngay > 0)
                {
                    c.FineAmount = (int)ngay;
                }
                else c.FineAmount = 0;
                k.returnUpdate(c.CopyNumber);
                k.cirUpdate(c);
                button2.Enabled = false;
                DataSet ds = k.SelectDS(c.CopyNumber);
                DataView dv = new DataView(ds.Tables[0]);
                dataGridView1.DataSource = dv;
                label5.Text = "" + ds.Tables[0].Rows.Count;
                //MessageBox.Show("Return Successfully !");
            }
            else
            {
                return;
                //MessageBox.Show("No clicked");
            }
        }
    }
}
