using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Assignment2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
            string flower = TextBox1.Text;
            if (string.IsNullOrEmpty(flower))
            {
                changed_text.InnerHtml = "Please Enter a name of a Flower";
               

            }

            string price = TextBox2.Text;
            double p = 0;

            if ((Double.TryParse(price, out p)) == false || p < 0)
            {
                Span1_text.InnerHtml = "Please Enter a unit price";

            }
        else
        {
            changed_text.InnerHtml = "";
            Span1_text.InnerHtml = "";
            Span2_text.InnerHtml = "okay";
        }
    }
}