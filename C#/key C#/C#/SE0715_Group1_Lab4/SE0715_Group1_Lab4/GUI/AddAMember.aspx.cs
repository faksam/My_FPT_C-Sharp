using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE0715_Group1_Lab4.BLL;
using SE0715_Group1_Lab4.DTL;

namespace SE0715_Group1_Lab4.GUI
{
    public partial class AddAMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbBorrowerNum.Enabled = false;
                tbBorrowerNum.Text = (MemberBL.GetMaxBorrower() + 1).ToString();
            }
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            lbSex.Visible = false;
            if (tbName.Text != "")
            {
                lbName.Visible = false;

                if (tbSex.Text == "F" || tbSex.Text == "M")
                {
                    Borrower b = new Borrower(int.Parse(tbBorrowerNum.Text), tbName.Text, char.Parse(tbSex.Text), tbAddress.Text, tbTelephone.Text, tbEmail.Text);
                    MemberBL.Insert(b);
                    Response.Redirect("~/GUI/MemberUI.aspx");
                }
                else
                {
                    lbSex.Visible = true;
                }
            }
            else
            {
                lbName.Visible = true;
            }
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/MemberUI.aspx");
        }
    }
}