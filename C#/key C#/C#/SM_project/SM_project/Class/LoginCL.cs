using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SM_project.Class
{
    public class LoginCL
    {
        private string user;

        public string User
        {
            get { return user; }
            set { user = value; }
        }
        private string pass;

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        private string lastname;

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public LoginCL()
        { }
        public LoginCL(string xuser, string xpass, string xlastname, string xtitle)
        {
            user = xuser;
            pass = xpass;
            lastname = xlastname;
            title = xtitle;
        }
    }
}
