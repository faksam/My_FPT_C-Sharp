using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //get the password
        string password = args.Value;
        //calculate length of password
        int len = password.Length;
        //assume that there is no number in password
        bool foundNumber = false;
        //convert password to an array of character
        char[] c = password.ToCharArray();
        //visit all character of c, if number is found -> exit
        foreach(char cc in c)
        {
            if(Char.IsDigit(cc))
            {
                foundNumber = true;
                break;

            }
        }
        bool isStrong = len >= 6 && foundNumber == true;
        //stay at current page if isStrong = false
        args.IsValid = isStrong;
    }
}