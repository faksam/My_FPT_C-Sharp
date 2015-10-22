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
        if (!IsPostBack)
        {
            string[] c = { "Blue", "Yellow", "Green" };
            foreach (string s in c)
                DropDownList1.Items.Add(s);
        }
    }
}