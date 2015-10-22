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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbNumberofBorrower.Text = "The number of Borrower : " + BorrowerBL.countBorrower();
        }

        //Add
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["borrowerNumber"] = BorrowerBL.getBorrowerNumberMax() + 1;
            Response.Redirect("Member_Add.aspx");
        }

        //Edit
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                lbError.Text = "You must choose a row to Edit!";
                return;
            }
            Session["borrowerNumber"] = GridView1.SelectedRow;
            Response.Redirect("Member_Edit.aspx");
        }
    }
}