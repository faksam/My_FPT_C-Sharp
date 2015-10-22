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

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string uid = TextBox1.Text;
        string pwd = TextBox2.Text;
        //send to Default page
        //Default.aspx?uid="Adam"&pwd="123"
        Response.Redirect("Default.aspx?uid="+uid+"&pwd="+pwd);
    }
   
}