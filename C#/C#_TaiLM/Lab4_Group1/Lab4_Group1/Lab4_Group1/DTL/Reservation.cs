using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4_Group1.DTL
{
    class Reservation
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        int borrowerNumber;

        public int BorrowerNumber
        {
            get { return borrowerNumber; }
            set { borrowerNumber = value; }
        }
        int bookNumber;

        public int BookNumber
        {
            get { return bookNumber; }
            set { bookNumber = value; }
        }
        DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        char status;

        public char Status
        {
            get { return status; }
            set { status = value; }
        }
        public Reservation()
        {
        }
        public Reservation(int brN, int bkN, DateTime d, char s)
        {
            borrowerNumber = brN;
            bookNumber = bkN;
            date = d;
            status = s;
        }
        public void display()
        {
            Console.WriteLine("     {0,-10} {1,10} {2,5}", bookNumber, DateTime.Today.ToShortDateString(), status);
        }
    }
}
