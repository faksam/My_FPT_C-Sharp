using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE0715_Group1_Lab4.BLL;
using System.Data;
using SE0715_Group1_Lab4.DTL;
using SE0715_Group1_Lab4.DAL;

namespace SE0715_Group1_Lab4.GUI
{
    public partial class ReserveUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        int memcode;
        int bookcode;

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                memcode = int.Parse(TextBox1.Text);
                BorrowBL b = new BorrowBL();
                if (b.checkMember(memcode))
                {
                    TextBox2.Text = b.showMemberName(memcode);

                }
                else
                {
                    lbError.Text = ("doesn't match with any member ! Please try again.");
                    lbError.Visible = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is OverflowException || ex is ArgumentNullException)
                {
                    lbError.Text = ("Wrong input");
                    lbError.Visible = true;
                    return;
                }
                else
                {
                    lbError.Text = ("somethings wrong in checkmember funtion" + ex);
                    lbError.Visible = true;
                }
            }
            TextBox1.Enabled = false;
            TextBox3.Enabled = true;
            Button1.Enabled = true;
            DataSet ds = ReserveBL.selectTableReservation(memcode);
            DataView dv = new DataView(ds.Tables[0]);
            GridViewReserved.DataSource = dv;
            GridViewReserved.DataBind();
            Label8.Text = "" + ds.Tables[0].Rows.Count;
            Button2.Enabled = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            memcode = int.Parse(TextBox1.Text);
            try
            {
                BorrowBL b = new BorrowBL();
                bookcode = int.Parse(TextBox3.Text);
                TextBox4.Text = ReserveBL.getBooktitle(bookcode);
                if (ReserveBL.checkReservation(bookcode, memcode))
                {
                    TextBox5.Enabled = true;
                    Button3.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is OverflowException || ex is ArgumentNullException)
                {
                    lbError.Text = ("Wrong book number!");
                    lbError.Visible = true;
                    return;
                }
                else
                {
                    lbError.Text = ("somethings wrong in checkReservation funtion");
                    lbError.Visible = true;
                }
            }
            TextBox5.Text = DateTime.Now.ToString("d/M/yyyy");
            Button2.Enabled = false;
            Button1.Enabled = false;
            TextBox3.Enabled = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            memcode = int.Parse(TextBox1.Text);
            bookcode = int.Parse(TextBox3.Text);
            ReserveBL.getBooktitle(bookcode);
            DateTime reserveDate = new DateTime();
            bool test = true;
            try
            {
                reserveDate = GetDate(TextBox5.Text.Trim());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Date ! Please try again !");
                test = false;
            }
            Reservation re = new Reservation(memcode, bookcode, reserveDate);
            re.Id = ReserveBL.IDMax() + 1;
            ReserveDA.Insert(re);

            DataSet ds = ReserveBL.selectTableReservation(memcode);
            DataView dv = new DataView(ds.Tables[0]);
            GridViewReserved.DataSource = dv;
            GridViewReserved.DataBind();
            Label8.Text = "" + ds.Tables[0].Rows.Count;
            Button2.Enabled = false;
            if (test == true)
            {
                Button3.Enabled = false;
                TextBox5.Enabled = false;
            }
        }

        public static DateTime GetDate(String s)
        {
            DateTime date;
            String[] time1 = s.Split('/');
            int[] time2 = new int[3];
            for (int i = 0; i < time1.Length; i++)
            {
                time2[i] = int.Parse(time1[i]);
            }
            date = new DateTime(time2[2], time2[1], time2[0]);
            return date;
        }
    }
}