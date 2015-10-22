using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2_ClassLibrary;

namespace Lab2_Application
{
    class BorrowGUI
    {
        public CirculatedCopy circulatedCopy;
        public BorrowList borrowList;
        public BorrowGUI()
        {
            circulatedCopy = new CirculatedCopy();
            borrowList = new BorrowList();
        }

        public static DateTime GetDate(String s)
        {
            DateTime date;
            String[] time1 = s.Split('/');
            int[] time2 = new int[3];
            for (int i = 0; i < time1.Length; i++)
            {
                time2[i] = int.Parse(time1[i]);
            }
            date = new DateTime(time2[2], time2[1], time2[0]);
            return date;
        }

        public void borrowBook(List<Reservation> xreserveList, BookList booklist, BorrowerList borrowerlist)
        {
            //sua cac bien o BookList va BorrowerList thanh public
            Console.WriteLine("---- Borrow a Book ----");

            int BorNum = 0;
            bool found2 = false;
            int damuon = 0;
            Borrower br = new Borrower();
            while (true)
            {
                Console.Write("Enter Borrower Number ( 0 to quit ) : ");
                try
                {
                    //kiem tra xem Borrower number co dung khong
                    BorNum = int.Parse(Console.ReadLine());
                    if (BorNum == 0)
                    {
                        Console.WriteLine("Enter to continue !");
                        return;
                    }

                    for (int i = 0; i < borrowerlist.t.Count; i++)
                    {
                        if (borrowerlist.t[i].brNumber != BorNum)
                        {
                            found2 = false;
                        }
                        else
                        {
                            br = borrowerlist.t[i];
                            damuon = br.borrowing.Count;
                            found2 = true;
                            break;
                        }
                    }

                    if (found2 == false)
                    {
                        Console.WriteLine("{0} doesn't match with any borrower ! Please try again.", BorNum);
                    }
                    else
                    {
                        if (damuon >= 5)
                        {
                            Console.WriteLine(BorNum + "has borrowed 5 books ! Please try again.");
                            found2 = false;
                        }
                        else
                        {
                            break;
                        }
                        //else
                        //{
                        //    br.borrowing.Add(copbook);
                        //    break;
                        //}
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Borrower Number ! Please try again");
                }
            }

            int CopNum = 0;
            bool found1 = false;
            Copy copbook = new Copy();
            Book book = new Book();

            while (true)
            {
                Console.Write("Enter Copy Number ( 0 to quit ): ");
                try
                {
                    CopNum = int.Parse(Console.ReadLine());
                    if (CopNum == 0)
                    {
                        Console.WriteLine("Enter to continue !");
                        return;
                    }
                    for (int i = 0; i < booklist.q.Count; i++)
                    {
                        for (int j = 0; j < booklist.q[i].k.Count; j++)
                        {
                            if (booklist.q[i].k[j].cNumber == CopNum)
                            {
                                book = booklist.q[i];
                                copbook = booklist.q[i].k[j];
                                found1 = true;
                                break;
                            }
                            else
                            {
                                found1 = false;
                            }
                        }
                        if (found1 == true) break;
                    }
                    if (found1 == false)
                    {
                        Console.WriteLine("{0} doesn't match with any copy book ! Please try again.", CopNum);
                    }
                    else
                    {
                        if (copbook.type != 'A')
                        {
                            Console.WriteLine("This copy book is not available ! Please try with another copy book !");
                        }
                        else
                        {
                            bool canBorrow = false ;
                            if (xreserveList.Count == 0)
                            {
                                br.borrowing.Add(copbook);
                                for (int n = 0; n < booklist.q.Count; n++)
                                {
                                    for (int j = 0; j < booklist.q[n].k.Count; j++)
                                    {
                                        if (booklist.q[n].k[j].cNumber == CopNum)
                                        {
                                            booklist.q[n].k[j].type = 'B';//set lai la da muon B = borrowed
                                            break;
                                        }
                                    }
                                }
                                canBorrow = true;
                            }
                            else
                            {
                                //xet xem no co reserve quen sach nay khong
                                for (int i = 0; i < xreserveList.Count; i++)
                                {
                                    if (xreserveList[i].borrowNum.Peek() == BorNum)
                                    {
                                        br.borrowing.Add(copbook);
                                        xreserveList[i].borrowNum.Dequeue();
                                        for (int n = 0; n < booklist.q.Count; n++)
                                        {
                                            for (int j = 0; j < booklist.q[n].k.Count; j++)
                                            {
                                                if (booklist.q[n].k[j].cNumber == CopNum)
                                                {
                                                    booklist.q[n].k[j].type = 'B';//set lai la da muon B = borrowed
                                                    break;
                                                }
                                            }
                                        }
                                        canBorrow = true;
                                        break;
                                    }
                                    else
                                    {
                                        canBorrow = false;
                                    }
                                }
                            }
                            if (canBorrow == false)
                            {
                                Console.WriteLine("This book was reserved by another people !");
                                return;
                            }
                            //them 
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Copy Book Number ! Please try again");
                }
            }


            DateTime xborrowDate;
            while (true)
            {
                Console.Write("Enter borrow date (Format : dd/mm/yyyy) : ");
                String s = Console.ReadLine();
                try
                {
                    xborrowDate = GetDate(s);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Date ! Please try again !");
                }
            }

            DateTime xdueDate;
            while (true)
            {
                Console.Write("Due date (Format : dd/mm/yyyy) : ");
                String s = Console.ReadLine();
                try
                {
                    xdueDate = GetDate(s);
                    TimeSpan day = xdueDate - xborrowDate;
                    double ngay = day.TotalDays;
                    if (ngay > 0)
                    { break; }
                    else
                    {
                        Console.WriteLine("Due date must after borrow date !");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Date ! Please try again !");
                }
            }
            CirculatedCopy cc = new CirculatedCopy(BorNum, CopNum, xborrowDate, xdueDate);
            borrowList.borrowlist.Add(cc);

            display(br);
        }

        public void display(Borrower x)
        {
            Console.WriteLine("Borrowed Book information\n");
            Console.WriteLine("BorrowerNumber\tCopyNumber\tBorrowDate\tDueDate\n ");
            foreach (CirculatedCopy k in borrowList.borrowlist)
            {
                if (k.borroNumber == x.brNumber && k.returnDate.Year ==1)
                {
                    Console.WriteLine(k.toString());
                }
            }
        }
    }
}
