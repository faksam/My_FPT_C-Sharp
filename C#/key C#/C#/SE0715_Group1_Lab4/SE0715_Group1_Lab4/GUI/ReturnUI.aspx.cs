using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SE0715_Group1_Lab4.DAL;
using SE0715_Group1_Lab4.BLL;
using SE0715_Group1_Lab4.DTL;

namespace SE0715_Group1_Lab4.GUI
{
    public partial class ReturnUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbError.Visible = false;
        }

        public void setStart()
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // assuming the first cell hols a date string
                e.Row.Cells[4].Text = DateTime.Parse(e.Row.Cells[4].Text).ToString("d/M/yyyy");
                e.Row.Cells[5].Text = DateTime.Parse(e.Row.Cells[5].Text).ToString("d/M/yyyy");
            }
        }

        protected void button1_Click(object sender, EventArgs e)
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
                lbError.Text = ex.Message;
                lbError.Visible = true;
                return;
            }


            bool test = a.checkMember(code);
            if (!test)
            {
                lbError.Text = ("Don't have this member in Database");
                lbError.Visible = true;
                return;
            }

            else
            {
                DataSet ds = b.SelectDS(code);
                DataView dv = new DataView(ds.Tables[0]);
                GridView1.DataSource = dv;


                GridView1.DataBind();
                Label4.Text = "" + ds.Tables[0].Rows.Count;
                textBox2.Text = b.getName(code);
                textBox3.Enabled = true;
                textBox3.Text = DateTime.Now.ToString("dd/M/yyyy");
                button3.Enabled = true;
                textBox1.Enabled = false;
                button1.Enabled = false;
            }
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            BorrowBL a = new BorrowBL();
            BorrowDA b = new BorrowDA();
            //DateTime returnDate = new DateTime();

            CirculatedCopy c = new CirculatedCopy();
            try
            {
                c.Id = int.Parse(GridView1.SelectedRow.Cells[1].Text);
                c.CopyNumber = int.Parse(GridView1.SelectedRow.Cells[2].Text);
                c.BorrowerNumber = int.Parse(GridView1.SelectedRow.Cells[3].Text);
                c.DueDate = DateTime.ParseExact(GridView1.SelectedRow.Cells[5].Text, "d/M/yyyy", null);
                c.BorrowedDate = DateTime.ParseExact(GridView1.SelectedRow.Cells[4].Text, "d/M/yyyy", null);
            }
            catch (Exception)
            {
                lbError.Text = "You must select a book !";
                lbError.Visible = true;

                return;
            }

            try
            {
                c.ReturnedDate = DateTime.ParseExact(textBox3.Text, "d/M/yyyy", null);
            }
            catch (Exception ex)
            {

                lbError.Text = (ex.Message);
                lbError.Visible = true;
                return;
            }
            if (c.ReturnedDate.Date < c.BorrowedDate)
            {
                lbError.Text = ("BorrowedDate must less than ReturnedDate !");
                lbError.Visible = true;
                return;
                //MessageBox.Show("BorrowedDate must less than ReturnedDate !");
            }
            TimeSpan dayLater = c.ReturnedDate.Date - c.DueDate;
            double ngay = dayLater.TotalDays;
            if (ngay > 0)
            {
                textBox4.Text = "" + ngay;
            }
            else textBox4.Text = "0";

            GridView1.Enabled = false;
            textBox3.Enabled = false;
            button3.Enabled = false;
            button2.Enabled = true;
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            ReturnDA k = new ReturnDA();

            CirculatedCopy c = new CirculatedCopy();
            try
            {
                c.Id = int.Parse(GridView1.SelectedRow.Cells[1].Text);
                c.CopyNumber = int.Parse(GridView1.SelectedRow.Cells[2].Text);
                c.BorrowerNumber = int.Parse(GridView1.SelectedRow.Cells[3].Text);
                c.DueDate = DateTime.ParseExact(GridView1.SelectedRow.Cells[5].Text, "d/M/yyyy", null);
                c.BorrowedDate = DateTime.ParseExact(GridView1.SelectedRow.Cells[4].Text, "d/M/yyyy", null);
            }
            catch (Exception)
            {
                lbError.Text = "You must select a book !";
                lbError.Visible = true;
                return;
            }

            try
            {
                c.ReturnedDate = DateTime.ParseExact(textBox3.Text, "d/M/yyyy", null);
            }
            catch (Exception ex)
            {
                lbError.Text = ex.Message;
                lbError.Visible = true;

                return;
            }
            if (c.ReturnedDate.Date < c.BorrowedDate)
            {
                lbError.Text = "BorrowedDate must less than ReturnedDate !";
                lbError.Visible = true;
                //MessageBox.Show("BorrowedDate must less than ReturnedDate !");
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
            GridView1.DataSource = dv;
            GridView1.DataBind();
            Label4.Text = "" + ds.Tables[0].Rows.Count;
            lbError.Text = ("Return Successfully !");
            lbError.Visible = true;
        }
    }
}