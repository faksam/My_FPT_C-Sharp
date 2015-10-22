using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<h1>This is out come of Page_load function</h1>");
        //get data from Login.aspx by GET method
        //string uid = Request.QueryString["uid"];
        //get data from Login.aspx by POST method
        string uid = Request.Form["TextBox1"];
        Response.Write("<h2>Welcome " + uid + "</h2>");
    }
}