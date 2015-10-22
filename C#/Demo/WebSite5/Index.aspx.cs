using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //if application["hit"] does not exist
        if (Application["hit"] == null)
            Application["hit"] = 0;
        else
        {
            Application.Lock();
            //get current value of Application ["hit"]
            int v = int.Parse(Application["hit"].ToString());
            //increment v by 1
            v++;
            //update Application["hit"]
            Application["hit"] = v;
            Application.UnLock();
            //update label
            Label1.Text = "Total visitor(s): " + v;
        }

        //session level
        if(Session["cnt"] == null)
            Session["cnt"] = 0;
        int u = int.Parse(Session["cnt"].ToString());
            u++;
            Session["cnt"] = u;
            Label2.Text = string.Format("You have click me {0}, time(s)", u);
        
    }
}