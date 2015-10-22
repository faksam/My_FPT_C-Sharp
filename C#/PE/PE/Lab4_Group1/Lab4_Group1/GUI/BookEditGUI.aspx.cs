using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab4_Group3.DTL;
using Lab4_Group3.BLL;

namespace Lab4_Group3.GUI
{
    public partial class BookEditGUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["book"] != null)
            {
                GridViewRow row = (GridViewRow) Session["book"];
                txtBookNumber.Text = row.Cells[1].Text;
                txtTitle.Text = row.Cells[2].Text;
                txtAuthors.Text = row.Cells[3].Text;
                txtPublisher.Text = row.Cells[4].Text;

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.BookNumber = int.Parse(txtBookNumber.Text);
            b.Title = txtTitle.Text;
            b.Authors = txtAuthors.Text;
            b.Publisher = txtPublisher.Text;

            BookBL.Update(b);

            Response.Redirect("BookGUI.aspx");
        }

        protected void txtCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookGUI.aspx");
        }
    }
}