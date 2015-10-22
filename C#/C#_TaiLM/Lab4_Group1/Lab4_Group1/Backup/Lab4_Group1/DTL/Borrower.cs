using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4_Group1.DTL
{
    public class Borrower
    {
        private int borrowerNumber;

        public int BorrowerNumber
        {
            get { return borrowerNumber; }
            set { borrowerNumber = value; }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private char sex;

        public char Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string telephone;

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Borrower(int borrowerNumber, string name, char sex, string address, string telephone, string email)
        {
            this.borrowerNumber = borrowerNumber;
            this.name = name;
            this.sex = sex;
            this.telephone = telephone;
            this.address = address;
            this.email = email;

        }

        public Borrower()
        {
            // TODO: Complete member initialization
        }

        public override string ToString()
        {
            return (borrowerNumber.ToString() + '\t' + name + '\t' + sex + '\t' + address + '\t' + telephone + '\t' + email);
        }
    }
}
