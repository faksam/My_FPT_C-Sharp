using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2_ClassLibrary;

namespace Lab2_Application
{
    public class ReservationList
    {
        public List<Reservation> reserveList;

        public ReservationList()
        {
            reserveList = new List<Reservation>();
        }

        public void reserve(List<Reservation> xreserveList, BorrowerList bl, BookList booklist)
        {
            Console.WriteLine("---- Reserve a Book ----");
            Queue<int> BorrowerQueue = new Queue<int>();
            int BorNum = 0;
            bool found2 = false;
            while (true)
            {
                Console.Write("Borrower Number (0 to quit) : ");
                try
                {
                    //kiem tra xem Borrower number co dung khong
                    BorNum = int.Parse(Console.ReadLine());
                    if ( BorNum == 0) { return; }
                    for (int i = 0; i < bl.t.Count; i++)
                    {
                        if (bl.t[i].brNumber != BorNum)
                        {
                            found2 = false;
                        }
                        else
                        {
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
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Borrower Number ! Please try again");
                }
            }

            DateTime date;
            while (true)
            {
                Console.Write("Enter borrow date (Format : dd/mm/yyyy) : ");
                String s = Console.ReadLine();
                try
                {
                    date = BorrowGUI.GetDate(s);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Date ! Please try again !");
                }
            }

            int BookNum = 0;
            Book book = new Book();
            bool found1 = false;
            while (true)
            {
                Console.Write("Book Number (0 to quit) : ");
                try
                {
                    BookNum = int.Parse(Console.ReadLine());
                    if (BookNum == 0) {
                        Console.WriteLine("Enter to continue !");
                        return; }
                    for (int i = 0; i < booklist.q.Count; i++)
                    {
                        if (booklist.q[i].bNumber != BookNum)
                        {
                            found1 = false;//khong tim thay
                        }
                        else
                        {
                            book = booklist.q[i];
                            found1 = true;//tim that la break
                            break;
                        }

                    }
                    bool thoat = false;
                    if (found1 == false)
                    {
                        Console.WriteLine("{0} doesn't match with any book ! Please try again.", BookNum);
                    }
                    else
                    {
                        for (int i = 0; i < book.k.Count; i++)
                        {
                            if (book.k[i].type == 'A')
                            {
                                Console.WriteLine("This book still has available copy book ! You cannot reserve this book !");
                                return;
                                thoat = false;
                                break;
                            }
                            else
                            {
                                thoat = true;
                            }
                        }
                    }
                    if (thoat == true)
                        break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Copy Book Number ! Please try again");
                }
            }
            bool add = true;
            for (int i = 0; i < xreserveList.Count; i++)
            {
                if (xreserveList[i].booknumber == BookNum && xreserveList[i].borrowNum.Count >= 0)
                {
                    Console.Write("This book was reserved by " + xreserveList[i].borrowNum.Count + " people. Do you wanna become the next one ! (Y/N):");
                    char chon = char.Parse(Console.ReadLine());
                    if (chon == 'Y' || chon == 'y')
                    {
                        add = false;
                        xreserveList[i].borrowNum.Enqueue(BookNum);
                        Console.WriteLine("Added Successfull ! Enter to continue !");
                    }
                    else
                    {
                        return; // neu khong muon reserve tiep
                        Console.WriteLine("Enter to continue !");
                    }
                    break;
                }
                else
                {
                    add = true;
                }
            }
            if (add == true)
            {
                Queue<int> nguoi_muon = new Queue<int>();
                nguoi_muon.Enqueue(BorNum);
                Reservation re = new Reservation(nguoi_muon, BookNum, date, 'A');
                xreserveList.Add(re);
                Console.WriteLine("Reserve successfull ! Enter to continue !");

            }
        }
        
    }
}
