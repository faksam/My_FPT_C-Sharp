using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //if user is valid, save information of user on session
        string username = TextBox1.Text;
        string password = TextBox2.Text;
        if (username.Equals("admin") && password.Equals("admin"))
        {
            Session["user"] = username;
            //move to home.aspx
            Response.Redirect("Home.aspx");
        }
        else
            Response.Write("<p>Username or Password is not correct!!!");
    }
}