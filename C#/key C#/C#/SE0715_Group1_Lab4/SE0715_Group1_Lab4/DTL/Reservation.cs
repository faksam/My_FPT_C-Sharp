using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE0715_Group1_Lab4.DTL
{
    public class Reservation
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int borrowerNumber;

        public int BorrowerNumber
        {
            get { return borrowerNumber; }
            set { borrowerNumber = value; }
        }
        private int bookNumber;

        public int BookNumber
        {
            get { return bookNumber; }
            set { bookNumber = value; }
        }
        private char status;

        public char Status
        {
            get { return status; }
            set { status = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Reservation()
        {
        }

        public Reservation(int borrowerNumber, int bookNumber, DateTime date)
        {
            this.borrowerNumber = borrowerNumber;
            this.bookNumber = bookNumber;
            this.date = date;
            status = 'R';
        }

        public Reservation(int borrowerNumber, int bookNumber, DateTime date, char status)
        {
            this.borrowerNumber = borrowerNumber;
            this.bookNumber = bookNumber;
            this.date = date;
            this.status = status;
        }

        public override string ToString()
        {
            return (borrowerNumber.ToString() + '\t' + bookNumber.ToString() + '\t' + date.ToString("dd/MM/yy") + '\t' + status);
        }
    }
}
