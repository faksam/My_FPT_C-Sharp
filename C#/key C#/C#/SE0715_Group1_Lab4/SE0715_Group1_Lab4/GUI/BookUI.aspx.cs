using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SE0715_Group1_Lab4.BLL;
using SE0715_Group1_Lab4.DTL;
using System.Windows.Forms;

namespace SE0715_Group1_Lab4.GUI
{
    public partial class BookUI : System.Web.UI.Page
    {
        private void FillBook()
        {
            DataSet ds = new DataSet();
            ds = BookBL.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            string sortDirection = "", sortExpression = "";
            if (ViewState["SortDirection"] != null)
                sortDirection = ViewState["SortDirection"].ToString();
            if (ViewState["SortExpression"] != null)
            {
                sortExpression = ViewState["SortExpression"].ToString();
                dv.Sort = sortExpression + " " + sortDirection;
            }
            gvBook.DataSource = dv;
            gvBook.DataBind();
            lbNum.Text = gvBook.Rows.Count.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillBook();
            }
        }

        protected void gvBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBook.PageIndex = e.NewPageIndex;
            gvBook.DataBind();
            FillBook();
        }

        protected void gvBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gvBook.SelectedRow;
            if (row != null)
            {
                {
                    string s = gvBook.Rows[e.RowIndex].Cells[1].Text;
                    Book b = new Book();
                    b.BookNumber = int.Parse(s);
                    BookBL.DeleteAllCopy(b);
                    BookBL.Delete(b);
                    FillBook();
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "wtf", "alert('Please select a book!');", true);
            }
        }

        protected void gvBook_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null || ViewState["SortExpression"].ToString() != e.SortExpression)
            {
                ViewState["SortDirection"] = "ASC";
                gvBook.PageIndex = 0;
            }
            else if (ViewState["SortDirection"].ToString() == "ASC")
                ViewState["SortDirection"] = "DESC";
            else if (ViewState["SortDirection"].ToString() == "DESC")
                ViewState["SortDirection"] = "ASC";
            ViewState["SortExpression"] = e.SortExpression;
            FillBook();
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/AddABook.aspx");
        }

        protected void btEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = gvBook.SelectedRow;
            if (row != null)
            {
                Session["bookNumber"] = row.Cells[1].Text;
                //Session["book"] = gvBook.SelectedRow;
                Response.Redirect("~/GUI/EditABook.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "wtf", "alert('Please select a book!');", true);
            }
        }

        protected void btCopies_Click(object sender, EventArgs e)
        {
            GridViewRow row = gvBook.SelectedRow;
            if (row != null)
            {
                Session["bookNumber"] = row.Cells[1].Text;
                Response.Redirect("~/GUI/CopyBookUI.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "wtf", "alert('Please select a book!');", true);
            }
        }

        protected void btFilter_Click(object sender, EventArgs e)
        {
            string s = tbBookNum.Text;
            int a;
            bool test = true;
            try
            {
                if (s != "")
                    a = int.Parse(s);
            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "wtf1", "alert('Book number must be a number!');", true);
                test = false;
            }

            if (s == "")
            {
                FillBook();
            }
            else if (test == true)
            {
                DataSet ds = new DataSet();
                ds = BookBL.SelectFilter(s);
                DataView dv = new DataView(ds.Tables[0]);
                gvBook.DataSource = dv;
                gvBook.DataBind();
                lbNum.Text = gvBook.Rows.Count.ToString();
            }
        }
    }
}