using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SM_project.Class
{
    class AccountCL
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private int employeeID;

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public AccountCL(string user, string pass, int empID)
        {
            this.Username = user;
            this.Password = pass;
            this.EmployeeID = empID;
        }

        public AccountCL()
        {
        }
    }
}
