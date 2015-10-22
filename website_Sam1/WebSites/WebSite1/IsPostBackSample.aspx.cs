using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IsPostBackSample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this code will show you how to use IsPostBack Property
        if (IsPostBack == false)
        {
            Response.Write("Welcome,First time to see you");
        }
        else
        {
            Response.Write("Welcome Back User!!");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}