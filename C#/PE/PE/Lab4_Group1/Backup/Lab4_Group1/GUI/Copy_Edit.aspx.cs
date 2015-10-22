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
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["bookNumber"] != null && Session["copyNumber"] != null)
            {
                GridViewRow row = (GridViewRow)Session["copyNumber"];
                tbCopyNumber.Text = row.Cells[1].Text;
                tbBookNumber.Text = ((int)Session["bookNumber"]).ToString();
                tbPrice.Text = "0";
                tbSequenceNumber.Text = "0";

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            Copy c = new Copy();
            c.BookNumber = int.Parse(tbBookNumber.Text);
            c.CopyNumber = int.Parse(tbCopyNumber.Text);
            c.Type = Convert.ToChar(DropDownList1.Text);
            c.SequenceNumber = int.Parse(tbSequenceNumber.Text);
            c.Price = double.Parse(tbPrice.Text);

            if (CopyBL.Update(c))
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