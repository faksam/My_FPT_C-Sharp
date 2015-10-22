using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE0715_Group1_Lab4.DTL;
using SE0715_Group1_Lab4.BLL;

namespace SE0715_Group1_Lab4.GUI
{
    public partial class EditACopy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["copyNumber"] != null && !IsPostBack)
            {
                string s = (string)Session["copyNumber"];
                Copy c = new Copy();
                c = CopyBL.SelectByID(s);
                tbBookNum.Text = c.BookNumber.ToString();
                tbBookNum.Enabled = false;
                tbCopyNum.Text = c.CopyNumber.ToString();
                tbCopyNum.Enabled = false;
                tbSequence.Text = c.SequenceNumber.ToString();
                tbSequence.Enabled = false;
                tbType.Text = c.Type.ToString();
                tbPrice.Text = c.Price.ToString();
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
                    CopyBL.Update(c);
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