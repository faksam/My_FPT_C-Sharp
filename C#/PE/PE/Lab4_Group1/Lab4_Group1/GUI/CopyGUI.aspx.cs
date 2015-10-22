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
    public partial class CopyGUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["book"] != null)
            {
                GridViewRow row = (GridViewRow) Session["book"];
                txtBookNumber.Text = row.Cells[1].Text;
                txtTitle.Text = row.Cells[2].Text;
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            lblNo.Text = GridView1.Rows.Count.ToString();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["bookNumber"] = int.Parse(txtBookNumber.Text);
            Session["copyNumber"] = CopyBL.getCopyNumberMAX()+1;
            Response.Redirect("Copy_Add.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                lbError.Text = "Error: You must select a Copy!";
                return;
            }
            Session["copyNumber"] = GridView1.SelectedRow ;
            Session["bookNumber"] = int.Parse(txtBookNumber.Text);
            Response.Redirect("Copy_Edit.aspx");
        }
    }
}