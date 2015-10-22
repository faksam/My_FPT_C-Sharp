using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2_ClassLibrary
{
    public class CirculatedCopy
    {
        public int borroNumber;
        public int copyNumber;
        public DateTime borrowDate;
        public DateTime dueDate;
        public DateTime returnDate;
        public int overDate;//fine amount

        public CirculatedCopy()
        { }

        public CirculatedCopy(int xborroNumber, int xcopyNumber, DateTime xborrowDate, DateTime xdueDate)
        {
            borroNumber = xborroNumber;
            copyNumber = xcopyNumber;
            borrowDate = xborrowDate;
            dueDate = xdueDate;
            overDate = 0;
        }

        public CirculatedCopy(int xborroNumber, int xcopyNumber, DateTime xborrowDate, DateTime xdueDateDateTime, DateTime xreturnDate, int xoverdate)
        {
            borroNumber = xborroNumber;
            copyNumber = xcopyNumber;
            borrowDate = xborrowDate;
            dueDate = xdueDateDateTime;
            returnDate = xreturnDate;
            overDate = xoverdate;
        }
        public String toString()
        {
            return borroNumber + "\t\t" + copyNumber + "\t\t" + borrowDate.ToString("d")+ "\t" + dueDate.ToString("d"); 
        }
        public override String ToString()
        {
            return borroNumber + "\t\t" + copyNumber + "\t\t" + borrowDate.ToString("d") + "\t" + returnDate.ToString("d");
        }
    }
    public class BorrowList
    {
        public List<CirculatedCopy> borrowlist;
        public BorrowList()
        {
            borrowlist = new List<CirculatedCopy>();
        }
        public CirculatedCopy searchCirByCopyNumber(String s)
        {
            foreach (CirculatedCopy cir in borrowlist)
            {
                if (cir.copyNumber.ToString().Equals(s.Trim()))
                {
                    return cir;
                }
            };
            return null;
        }
    }
}
