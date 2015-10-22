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
    public partial class BookGUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNo.Text = BookBL.countBook().ToString();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            lblNo.Text = GridView1.Rows.Count.ToString();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
           
            Session["bookNumber"] = BookBL.getBookNumberMax() + 1;
            Response.Redirect("BookAddGUI.aspx");
            
            
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                lblError.Text = "Error: You must select a book!";
                return;
            }
            Session["book"] = GridView1.SelectedRow;
            Response.Redirect("BookEditGUI.aspx");
        }

        protected void btnCopies_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                lblError.Text = "Error: You must select a book!";
                return;
            }
            Session["book"] = GridView1.SelectedRow;
            Response.Redirect("CopyGUI.aspx");
            
        }

       

       
    }
}