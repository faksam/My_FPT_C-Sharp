using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //read the value of uid which is sent from Home.aspx
        string username = Request.QueryString["uid"];
        //read the information of web brower that users are using
        string bversion = Request.Browser.Version;
        string bplatform = Request.Browser.Platform;
        string bname = Request.Browser.Browser;
        //print output to browser
        Response.Write("<p>Receiveed username = "+username +"</p>");
        Response.Write("<h1>Information of web browser </h1>");
        Response.Write("<p>Version:"+bversion+"</p>");
        Response.Write("<p>Version:" + bplatform + "</p>");
        Response.Write("<p>Name"+bname+"</p>");
    }
}