using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if command is selected then redirect to page named Ordertail.aspx
        if (e.CommandName.Equals("Select"))
        {
            string id = e.CommandArgument.ToString();
            Response.Redirect("OrderDetail.aspx?OrderId=" + id);
        }
    }
}