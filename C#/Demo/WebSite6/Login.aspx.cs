using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginerror"] != null)
            Label1.Text = Session["loginerror"].ToString();
        //read cookie named login
        HttpCookie ck = Request.Cookies["login"];
        //if ck exist
        if (ck != null)
        {
            string uid = ck["username"];
            string pwd = ck["password"];
            //put uid and pwd to textboxs
            TextBox1.Text = uid;
            TextBox2.Attributes.Add("Value", pwd);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string uid = TextBox1.Text;
        string pwd = TextBox2.Text;
        //if remember me is checked
        if (CheckBox1.Checked)
        {
            //create a new cookies
            HttpCookie ck = new HttpCookie("login");
            ck["username"] = uid;
            ck["password"] = pwd;
            //time to live of ck
            ck.Expires = DateTime.Now.AddMinutes(30);
            //save ck to browser
            Response.Cookies.Add(ck);
        }
        if (uid.Equals("admin") && pwd.Equals("admin"))
        {
            Session["login"] = "Welcome " + uid;
            Response.Redirect("Home.aspx");
        }
        else Label1.Text = "Username or password is incorrect";
    }
}