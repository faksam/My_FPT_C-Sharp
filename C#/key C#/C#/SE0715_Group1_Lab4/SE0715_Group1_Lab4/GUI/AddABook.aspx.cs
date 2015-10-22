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
    public partial class AddABook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbBookNum.Enabled = false;
                tbBookNum.Text = (BookBL.GetBookNumberMax() + 1).ToString();
            }
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            if (tbTitle.Text != "")
            {
                Book b = new Book(int.Parse(tbBookNum.Text), tbTitle.Text, tbAuthor.Text, tbPulisher.Text);
                BookBL.Insert(b);
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