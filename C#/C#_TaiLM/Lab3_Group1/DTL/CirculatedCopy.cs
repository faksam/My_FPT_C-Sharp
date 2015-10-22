using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3_Group1.DTL
{
    class CirculatedCopy
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        int copyNumber;

        public int CopyNumber
        {
            get { return copyNumber; }
            set { copyNumber = value; }
        }
        int borrowerNumber;

        public int BorrowerNumber
        {
            get { return borrowerNumber; }
            set { borrowerNumber = value; }
        }
        DateTime borrowedDate;

        public DateTime BorrowedDate
        {
            get { return borrowedDate; }
            set { borrowedDate = value; }
        }
        DateTime dueDate;

        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        DateTime returnedDate;

        public DateTime ReturnedDate
        {
            get { return returnedDate; }
            set { returnedDate = value; }
        }
        float fineAmount;

        public float FineAmount
        {
            get { return fineAmount; }
            set { fineAmount = value; }
        }
        public CirculatedCopy()
        {
        }
        public CirculatedCopy(int copyN, int brN, DateTime dueD)
        {
            copyNumber = copyN;
            borrowerNumber = brN;
            borrowedDate = dueD.AddDays(-14);
            dueDate = dueD;
            returnedDate = DateTime.Today.AddDays(-1);
            fineAmount = 0;
        }
        public void display()
        {
            Console.Write("     {0,-15} {1,-15} {2,-15}", copyNumber, borrowedDate.ToShortDateString(), dueDate.ToShortDateString());
        }
    }
}
