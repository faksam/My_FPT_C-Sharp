using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session03
{
    class Employee
    {
        //attribute
        private string fullname;
        private string id;
        //default constructor
        public Employee()
        {
            Console.WriteLine("Employee constructor...");
        }
        //class properties for id
        public string Id { get { return id; } set { id = value; } }
        //class properties for fullname
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        public virtual void Print()
        {
            Console.WriteLine("fullname: {0}, id: {1}",FullName,Id);
        }
    }
}
