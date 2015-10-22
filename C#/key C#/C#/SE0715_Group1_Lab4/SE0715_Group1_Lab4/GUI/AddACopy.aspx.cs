using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE0715_Group1_Lab4.BLL;
using SE0715_Group1_Lab4.DTL;

namespace SE0715_Group1_Lab4.GUI
{
    public partial class AddACopy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbBookNum.Enabled = false;
                tbCopyNum.Enabled = false;
                tbSequence.Enabled = false;

                tbCopyNum.Text = (CopyBL.GetCopyNumberMax() + 1).ToString();

                string s = (string)Session["bookNumber"];
                Book b = new Book();
                b = BookBL.SelectByID(s);
                tbBookNum.Text = b.BookNumber.ToString();

                int Seq;
                try
                {
                    Seq = CopyBL.getSequenceMax(tbBookNum.Text) + 1;
                }
                catch (Exception)
                {
                    Seq = 1;
                }
                tbSequence.Text = Seq.ToString();
            }
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            lbPrice.Visible = false;
            if (tbType.Text == "A" || tbType.Text == "R")
            {
                lbType.Visible = false;
                bool test = true;

                double price = 0;
                try
                {
                    price = double.Parse(tbPrice.Text);
                }
                catch (Exception)
                {
                    lbPrice.Visible = true;
                    test = false;
                }

                if (test == true && price >= 0)
                {
                    Copy c = new Copy(int.Parse(tbBookNum.Text), int.Parse(tbCopyNum.Text), int.Parse(tbSequence.Text), char.Parse(tbType.Text), price);
                    CopyBL.Insert(c);
                    Response.Redirect("~/GUI/CopyBookUI.aspx");
                }
                else
                {
                    lbPrice.Visible = true;
                }
            }
            else
            {
                lbType.Visible = true;
            }
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/CopyBookUI.aspx");
        }
    }
}