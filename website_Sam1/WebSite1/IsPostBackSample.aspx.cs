using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IPostBackSample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this code will show you how to user IsPostBack property
        if (IsPostBack == false)
        {
            Response.Write("Wellcome,first time to see you");
        }
        else
        {
            Response.Write("Wellcome back user!!");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}