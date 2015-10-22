using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE0715_Group1_Lab3.DTL
{
    public class CirculatedCopy
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }



        private int copyNumber;

        public int CopyNumber
        {
            get { return copyNumber; }
            set { copyNumber = value; }
        }



        private int borrowerNumber;

        public int BorrowerNumber
        {
            get { return borrowerNumber; }
            set { borrowerNumber = value; }
        }

 

        private DateTime borrowedDate;

        public DateTime BorrowedDate
        {
            get { return borrowedDate; }
            set { borrowedDate = value; }
        }
        private DateTime dueDate;

        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        private DateTime returnedDate;

        public DateTime ReturnedDate
        {
            get { return returnedDate; }
            set { returnedDate = value; }
        }
        private double fineAmount;

        public double FineAmount
        {
            get { return fineAmount; }
            set { fineAmount = value; }
        }

        public CirculatedCopy()
        {
        }

        public CirculatedCopy(int copyNumber, int borrowerNumber)
        {
            this.copyNumber = copyNumber;
            this.borrowerNumber = borrowerNumber;
            this.BorrowedDate = DateTime.Now;
            this.dueDate = DateTime.Now.AddDays(14);
        }

        public CirculatedCopy(int copyNumber, int borrowerNumber, DateTime borrowedDate, DateTime dueDate)
        {
            this.copyNumber = copyNumber;
            this.borrowerNumber = borrowerNumber;
            this.BorrowedDate = borrowedDate;
            this.dueDate = dueDate;
        }

        public override string ToString()
        {
            return (copyNumber.ToString() + '\t' + borrowerNumber.ToString() + '\t' + borrowedDate.ToString("dd/MM/yy") + '\t' + dueDate.ToString("dd/MM/yy")
                + '\t' + returnedDate.ToString("dd/MM/yy") + '\t' + fineAmount.ToString());
        }
    }

}
