using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;//read connectionstring from web.config
using System.Data;
public partial class Home : System.Web.UI.Page
{

    string connetionString = WebConfigurationManager.
        ConnectionStrings["StudentDBConnection"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if user has not yet signed in -> move to login.aspx
        if(Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Response.Write("<hi>Welcome, " + Session["user"] + "</hi>");
        if (IsPostBack == false)
        {
            SqlDataAdapter sda =
                new SqlDataAdapter("select * from semester order by name", connetionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //bind dt to dropdownlist1
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
        }
    }
}