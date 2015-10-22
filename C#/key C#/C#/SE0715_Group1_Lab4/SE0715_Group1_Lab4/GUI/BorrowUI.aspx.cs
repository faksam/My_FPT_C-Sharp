using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE0715_Group1_Lab4.DAL;
using System.Data;
using SE0715_Group1_Lab4.BLL;
using SE0715_Group1_Lab4.DTL;

namespace SE0715_Group1_Lab4.GUI
{
    public partial class BorrowUI : System.Web.UI.Page
    {
        private void FillBorrow(int a)
        {
            BorrowDA b = new BorrowDA();
            DataSet ds = b.SelectDS(a);
            DataView dv = new DataView(ds.Tables[0]);
            gvBorrow.DataSource = dv;
            gvBorrow.DataBind();
            totalBr.Text = gvBorrow.Rows.Count.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button1_Click(object sender, EventArgs e)
        {
            BorrowBL a = new BorrowBL();
            BorrowDA b = new BorrowDA();
            int code = 0;
            try
            {
                code = int.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {

                Label1.Text = "Please enter a corect book number!";
                Label1.Visible = true;
                return;
            }


            bool test = a.checkMember(code);
            if (!test)
            {
                Label1.Text = "Don't have this member in Database!";
                Label1.Visible = true;
                return;
            }

            else
            {
                DataSet ds = b.SelectDS(code);
                DataView dv = new DataView(ds.Tables[0]);
                textBox2.Text = b.getName(code);
                textBox1.Enabled = false;
                button1.Enabled = false;
                textBox3.Enabled = true;
                button2.Enabled = true;
                Label1.Visible = false;
                FillBorrow(code);
            }
        }

        protected void button2_Click(object sender, EventArgs e)
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
                Label1.Text = "Please enter a corect copy number!";
                Label1.Visible = true;
                return;
            }

            bool test = a.checkCopy(code);
            if (!test)
            {
                Label1.Text = "You can't borrow this copy!";
                Label1.Visible = true;
                return;
            }


            bool test1 = a.checkFive(int.Parse(textBox1.Text));
            if (!test1)
            {
                Label1.Text = "You have borrowed 5 copies!";
                Label1.Visible = true;
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
                Label1.Visible = false;
            }
            else
            {
                bool test3 = a.checkReserve(code, b.getBoNum(code), int.Parse(textBox1.Text));
                if (!test3)
                {
                    Label1.Text = "This book have resserved by other person!";
                    Label1.Visible = true;
                    return;
                }
                else
                {

                    textBox3.Enabled = false;
                    textBox4.Text = DateTime.Now.ToString("d/M/yyyy");
                    button2.Enabled = false;
                    textBox4.Enabled = true;
                    button3.Enabled = true;
                    Label1.Visible = false;
                }
            }
        }

        protected void button3_Click(object sender, EventArgs e)
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
                Label1.Text = "Please enter a corect date!";
                Label1.Visible = true;
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
            FillBorrow(brNum);
            bool test2 = a.checkReserve1(copyNum);
            bool test3 = a.checkReserve(copyNum, b.getBoNum(copyNum), int.Parse(textBox1.Text));
            if (test2 && test3)
            {
                b.borrowReUpdate(b.getBoNum(copyNum), int.Parse(textBox1.Text));
            }
            button3.Enabled = false;
            textBox4.Enabled = false;
        }
    }
}