using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Read the value usid which is sent from Home.aspx
        string username = Request.QueryString["usid"];
        //read the information of the web browser that the users are using
        string browserversion = Request.Browser.Version;
        string browserplatform = Request.Browser.Platform;
        string browserName = Request.Browser.Browser;
       //print the output to the browser
        
        Response.Write("<h1>Information of the web browser </h1>");
        Response.Write("<p>Received userName =" + username + "</p>");
        Response.Write("<p>Version: " + browserversion + "</p>");
        Response.Write("<p>Platform: " + browserplatform + "</p>");
        Response.Write("<p>Name: " + browserName + "</p>");
    }
}