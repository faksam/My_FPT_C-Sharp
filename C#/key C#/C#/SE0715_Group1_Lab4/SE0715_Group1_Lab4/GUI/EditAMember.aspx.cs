using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE0715_Group1_Lab4.DTL;
using SE0715_Group1_Lab4.BLL;

namespace SE0715_Group1_Lab4.GUI
{
    public partial class EditAMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["borrowerNumber"] != null && !IsPostBack)
            {
                tbBorrowerNum.Enabled = false;
                string s = (string)Session["borrowerNumber"];
                Borrower b = new Borrower();
                b = MemberBL.SelectByID(s);
                tbBorrowerNum.Text = b.BorrowerNumber.ToString();
                tbName.Text = b.Name.ToString();
                tbSex.Text = b.Sex.ToString();
                tbAddress.Text = b.Address;
                tbTelephone.Text = b.Telephone;
                tbEmail.Text = b.Email;

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
                    MemberBL.Update(b);
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