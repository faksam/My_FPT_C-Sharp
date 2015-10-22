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
    public partial class EditABook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["bookNumber"] != null)
            {
                tbBookNum.Enabled = false;
                
                string s = (string)Session["bookNumber"];
                Book b = new Book();
                b = BookBL.SelectByID(s);
                tbBookNum.Text = b.BookNumber.ToString();

                tbAuthor.Text = b.Authors;
                tbPulisher.Text = b.Publisher;
                tbTitle.Text = b.Title;

                //GridViewRow row = (GridViewRow)Session["book"];
                //tbBookNum.Text = row.Cells[1].Text;
                //tbTitle.Text = row.Cells[2].Text;
                //tbAuthor.Text = row.Cells[3].Text;
                //tbPulisher.Text = row.Cells[4].Text;
            }
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            if (tbTitle.Text != "")
            {
                Book b = new Book(int.Parse(tbBookNum.Text), tbTitle.Text, tbAuthor.Text, tbPulisher.Text);
                BookBL.Update(b);
                Response.Redirect("~/GUI/BookUI.aspx");
            }
            else
            {
                lbTitle.Visible = true;
            }
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/BookUI.aspx");
        }
    }
}