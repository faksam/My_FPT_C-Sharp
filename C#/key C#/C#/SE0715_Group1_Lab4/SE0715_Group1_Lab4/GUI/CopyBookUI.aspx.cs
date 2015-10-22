using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE0715_Group1_Lab4.DTL;
using SE0715_Group1_Lab4.BLL;
using System.Data;

namespace SE0715_Group1_Lab4.GUI
{
    public partial class CopyBookUI : System.Web.UI.Page
    {
        private void FillCopyBook()
        {
            if (Session["bookNumber"] != null)
            {
                tbBookNum.Enabled = false;
                tbTittle.Enabled = false;

                string s = (string)Session["bookNumber"];
                Book b = new Book();
                b = BookBL.SelectByID(s);
                tbBookNum.Text = b.BookNumber.ToString();
                tbTittle.Text = b.Title;

                string filter = "bookNumber =" + s;
                DataSet ds = new DataSet();
                ds = CopyBL.SelectDS();
                DataView dv = new DataView(ds.Tables[0]);
                dv.RowFilter = filter;
                string sortDirection = "", sortExpression = "";
                if (ViewState["SortDirection"] != null)
                    sortDirection = ViewState["SortDirection"].ToString();
                if (ViewState["SortExpression"] != null)
                {
                    sortExpression = ViewState["SortExpression"].ToString();
                    dv.Sort = sortExpression + " " + sortDirection;
                }
                gvCopyBook.DataSource = dv;
                gvCopyBook.DataBind();
                lbNum.Text = gvCopyBook.Rows.Count.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCopyBook();
            }
        }

        protected void gvCopyBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCopyBook.PageIndex = e.NewPageIndex;
            gvCopyBook.DataBind();
            FillCopyBook();
        }

        protected void gvCopyBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gvCopyBook.SelectedRow;
            if (row != null)
            {
                string s = gvCopyBook.Rows[e.RowIndex].Cells[1].Text;
                Copy c = new Copy();
                c.CopyNumber = int.Parse(s);
                CopyBL.Delete(c);
                FillCopyBook();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "wtf", "alert('Please select a copy!');", true);
            }
        }

        protected void gvCopyBook_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null || ViewState["SortExpression"].ToString() != e.SortExpression)
            {
                ViewState["SortDirection"] = "ASC";
                gvCopyBook.PageIndex = 0;
            }
            else if (ViewState["SortDirection"].ToString() == "ASC")
                ViewState["SortDirection"] = "DESC";
            else if (ViewState["SortDirection"].ToString() == "DESC")
                ViewState["SortDirection"] = "ASC";
            ViewState["SortExpression"] = e.SortExpression;
            FillCopyBook();
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/AddACopy.aspx");
        }

        protected void btEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = gvCopyBook.SelectedRow;
            if (row != null)
            {
                Session["copyNumber"] = row.Cells[1].Text;
                Response.Redirect("~/GUI/EditACopy.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "wtf", "alert('Please select a copy!');", true);
            }
        }
    }
}