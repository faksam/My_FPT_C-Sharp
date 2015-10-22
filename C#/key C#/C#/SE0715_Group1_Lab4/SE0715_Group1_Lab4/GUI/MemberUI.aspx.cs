using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SE0715_Group1_Lab4.BLL;
using SE0715_Group1_Lab4.DTL;

namespace SE0715_Group1_Lab4.GUI
{
    public partial class MemberUI : System.Web.UI.Page
    {
        private void FillMember()
        {
            DataSet ds = new DataSet();
            ds = MemberBL.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            string sortDirection = "", sortExpression = "";
            if (ViewState["SortDirection"] != null)
                sortDirection = ViewState["SortDirection"].ToString();
            if (ViewState["SortExpression"] != null)
            {
                sortExpression = ViewState["SortExpression"].ToString();
                dv.Sort = sortExpression + " " + sortDirection;
            }
            gvMember.DataSource = dv;
            gvMember.DataBind();
            lbNum.Text = gvMember.Rows.Count.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillMember();
            }
        }

        protected void gvBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMember.PageIndex = e.NewPageIndex;
            gvMember.DataBind();
            FillMember();
        }

        protected void gvBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gvMember.SelectedRow;
            if (row != null)
            {
                {
                    string s = gvMember.Rows[e.RowIndex].Cells[1].Text;
                    Borrower b = new Borrower();
                    b.BorrowerNumber = int.Parse(s);
                    MemberBL.Delete(b);
                    FillMember();
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "wtf", "alert('Please select a member!');", true);
            }
        }

        protected void gvBook_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null || ViewState["SortExpression"].ToString() != e.SortExpression)
            {
                ViewState["SortDirection"] = "ASC";
                gvMember.PageIndex = 0;
            }
            else if (ViewState["SortDirection"].ToString() == "ASC")
                ViewState["SortDirection"] = "DESC";
            else if (ViewState["SortDirection"].ToString() == "DESC")
                ViewState["SortDirection"] = "ASC";
            ViewState["SortExpression"] = e.SortExpression;
            FillMember();
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/AddAMember.aspx");
        }

        protected void btEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = gvMember.SelectedRow;
            if (row != null)
            {
                Session["borrowerNumber"] = row.Cells[1].Text;
                Response.Redirect("~/GUI/EditAMember.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "wtf", "alert('Please select a member!');", true);
            }
        }
    }
}