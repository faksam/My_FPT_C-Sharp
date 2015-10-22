using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.PreInit += Register_PreInit;
    }

    void Register_PreInit(object sender, EventArgs e)
    {
      //  throw new NotImplementedException();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = "";
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string s = TextBox5.Text;
        if (s.Length < 5) args.IsValid = false;
        bool valid = true;
        foreach (char c in s.ToCharArray())
        {
            if (char.IsDigit(c))
            {
                valid = true;
                break;
            }
        }
        args.IsValid = valid;
    }
}