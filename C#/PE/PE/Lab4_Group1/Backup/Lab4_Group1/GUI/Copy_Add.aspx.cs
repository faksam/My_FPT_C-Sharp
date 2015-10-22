using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab4_Group3.DTL;
using Lab4_Group3.BLL;


namespace Lab4_Group3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["bookNumber"] != null && Session["copyNumber"] != null)
            {
                tbBookNumner.Text = ((int)Session["bookNumber"]).ToString();
                tbCopyNumber.Text = ((int)Session["copyNumber"]).ToString();
                tbPrice.Text = "0";
                tbSequeceNum.Text = "0";
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Copy c = new Copy();
            c.CopyNumber = int.Parse(tbCopyNumber.Text);
            c.BookNumber = int.Parse(tbBookNumner.Text);
            c.Type = Convert.ToChar(DropDownList1.Text);
            c.SequenceNumber = int.Parse(tbSequeceNum.Text);
            c.Price = double.Parse(tbPrice.Text);
            if (CopyBL.Insert(c))
            {
                Response.Redirect("CopyGUI.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CopyGUI.aspx");
        }
    }
}