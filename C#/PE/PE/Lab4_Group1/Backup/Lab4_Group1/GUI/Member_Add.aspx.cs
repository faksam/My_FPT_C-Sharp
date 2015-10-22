using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab4_Group3.DTL;
using Lab4_Group3.BLL;

namespace Lab4_Group3
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["borrowerNumber"] != null)
            {
                tbBorrowerNum.Text = Session["borrowerNumber"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Borrower b = new Borrower();
            b.BorrowerNumber = int.Parse(tbBorrowerNum.Text);
            b.Name = tbName.Text;
            b.Sex = DropDownList1.Text;
            b.Address = tbAddress.Text;
            b.Telephone = tbTelephone.Text;
            b.Email = tbEmail.Text;
            if (BorrowerBL.Insert(b))
            {
                Response.Redirect("Member.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member.aspx");
        }
    }
}