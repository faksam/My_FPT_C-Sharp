using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SM_project.Class
{
    class EmployeeCL
    {
        private int employeeID;

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public EmployeeCL(string last, string first, string phone, string add, string tit)
        {
            this.LastName = last;
            this.FirstName = first;
            this.Phone = phone;
            this.Address = add;
            this.Title = tit;
        }

        public EmployeeCL()
        {
        }
    }
}
