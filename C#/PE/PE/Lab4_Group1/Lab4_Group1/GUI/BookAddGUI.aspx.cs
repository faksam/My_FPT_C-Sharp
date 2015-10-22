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
    public partial class BookAddGUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["bookNumber"] != null)
            {
                tb_bookNumber.Text = ((int) Session["bookNumber"]).ToString();
                tb_title.Text = "";
                tb_authors.Text = "";
                tb_publisher.Text = "";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.BookNumber = int.Parse(tb_bookNumber.Text);
            b.Title = tb_title.Text;
            b.Authors = tb_authors.Text;
            b.Publisher = tb_publisher.Text;

            if (BookBL.Insert(b)) BookBL.BookNumberMax++;

            Response.Redirect("BookGUI.aspx");

        }

        protected void txtCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookGUI.aspx");
        }
    }
}