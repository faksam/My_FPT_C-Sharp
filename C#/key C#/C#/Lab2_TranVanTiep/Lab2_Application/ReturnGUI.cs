using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2_ClassLibrary;

namespace Lab2_Application
{
    class ReturnGUI
    {
        public BorrowerList borrowerList;
        public BookList bookList;
        public BorrowList borrowList;
        CirculatedCopy cir;

        public ReturnGUI(BorrowerList brl, BookList bol, BorrowList brl1)
        {
            this.bookList = bol;
            this.borrowerList = brl;
            this.borrowList = brl1;
        }

        public ReturnGUI()
        {
            // TODO: Complete member initialization
        }
        public void Return()
        {
            String ac, bc, returnDateString;
            DateTime returnDate;

            while (true)
            {
                Console.Write("Enter copy number(0 to cancel): ");
                bc = Console.ReadLine();
                if (bc.Equals("0")) { return; }
                if (borrowList.searchCirByCopyNumber(bc) != null)
                {
                    cir = borrowList.searchCirByCopyNumber(bc);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid copy! try again!");
                }
            }
            while (true)
            {
                Console.Write("Enter return date: ");
                returnDateString = Console.ReadLine();
                try
                {
                    cir.returnDate = BorrowGUI.GetDate(returnDateString);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Date ! Please try again !");
                }
            }
            if (cir.returnDate.Date > cir.dueDate)
            {
                TimeSpan dayLater = cir.returnDate.Date - cir.dueDate;
                double ngay = dayLater.TotalDays;
                if (ngay > 0)
                {
                    Console.WriteLine("You need to pay ${0} for your book because your return it's late!", ngay);
                    while (true)
                    {
                        Console.Write("Do you agree? (Y/N): ");
                        String s = Console.ReadLine();
                        if (s.Trim().Equals("N") || s.Trim().Equals("n"))
                        {
                            return;
                        }
                        if (!s.Trim().Equals("N") && !s.Trim().Equals("n") && !s.Trim().Equals("y") && !s.Trim().Equals("Y"))
                        {
                            Console.WriteLine("please Y/N! Try again");
                        }
                        else { break; }
                    }
                }
            }
            bool thoat = false;
            for (int i = 0; i < bookList.q.Count; i++)
            {
                for (int j = 0; j < bookList.q[i].k.Count; j++)
                {
                    if (bookList.q[i].k[j].cNumber == cir.copyNumber)
                    {
                        bookList.q[i].k[j].type = 'A';
                        thoat = true;
                        break;
                    }
                    else
                    {
                        thoat = false;
                    }
                }
                if (thoat == true)
                    break;
            }


            foreach (Borrower b in borrowerList.t)
            {
                if (b.brNumber==cir.borroNumber)
                {
                    for (int i = 0; i < b.borrowing.Count; i++)
                    {
                        if (b.borrowing[i].cNumber == cir.copyNumber)
                        {
                            b.borrowing.Remove(b.borrowing[i]);
                            break;
                        }
                    }
                }

            }


            Console.WriteLine("Borrower\tCopy\t\tBorrow date\tReturn date");
            foreach (CirculatedCopy cir1 in borrowList.borrowlist)
            {
                if (cir1.returnDate.Year!=0001 && cir1.borroNumber == cir.borroNumber)
                {
                    Console.WriteLine(cir1.ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
