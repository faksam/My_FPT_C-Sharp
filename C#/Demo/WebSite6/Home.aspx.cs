using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if user has not logged in yet
        if (Session["login"] == null)
        {
            Session["loginerror"] = "You have not logged in yet, pls log in";
            Response.Redirect("Login.aspx");
        }
        else
        {
            //print welcomr message
            Response.Write("<h1>" + Session["Login"] + "</h1>");
        }
    }
}