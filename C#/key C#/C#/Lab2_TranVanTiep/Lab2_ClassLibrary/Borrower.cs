using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2_ClassLibrary
{
    public class Borrower
    {
        public int brNumber;
        public string name;
        public char sex;
        public string address;
        public string telephone;
        public string email;
        public List<Copy> borrowing;

        public Borrower()
        {

        }
        public Borrower(int brNumber, string name, char sex, string address, string telephone, string email)
        {
            this.brNumber = brNumber;
            this.name = name;
            this.sex = sex;
            this.address = address;
            this.telephone = telephone;
            this.email = email;
            borrowing = new List<Copy>();
        }
        public override String ToString()
        {
            return brNumber + "\t\t" + name + "\t" + sex + "\t" + address + "\t" + telephone + "\t" + email;
        }
    }

    public class BorrowerList
    {
        public List<Borrower> t;

        public BorrowerList()
        {
            t = new List<Borrower>();
        }

        public Borrower searchBorrowerByNumber(String s)
        {
            foreach (Borrower b in t)
            {
                if (s.Trim().Equals(b.brNumber.ToString().Trim()))
                {
                    return b;
                }
            }
            return null;
        }
        public Borrower setStatusWhenReturn()
        {

            return null;
        }
    }
}
