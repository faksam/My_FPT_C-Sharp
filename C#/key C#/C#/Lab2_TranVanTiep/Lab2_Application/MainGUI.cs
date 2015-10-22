using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2_ClassLibrary;
namespace Lab2_Application {
    class Program {
        static void Main(string[] args) {

            BorrrowerGUI borrowerGui = new BorrrowerGUI();
            BookGUI bookGui = new BookGUI();
            BorrowGUI borrowGui = new BorrowGUI();
            ReservationList reserveList = new ReservationList();
            bool test = true;


            bookGui.bookList.q.Add(new Book(1, "How to learn  C#", "Trung tru tri", "Bao Pham"));
            bookGui.bookList.q.Add(new Book(2, "How to learn DSA", "Tran Van Tiep", "Trung"));
            bookGui.bookList.q.Add(new Book(3, "How to learn C++", "Doan Manh Tien", "Tien"));
            bookGui.bookList.q.Add(new Book(4, "How to learn ITC", "ABC", "XXX"));
            bookGui.bookList.q.Add(new Book(5, "How to learn Java", "XYZ", "CCC"));
            bookGui.bookList.q.Add(new Book(6, "How to learn  OS", "Cofd", "Bao Pham CCC"));

            //Copy(int cNumber, int bNumber, int seqNumber, char type, double price)
            bookGui.bookList.q[0].k.Add(new Copy(1, 1, 1, 'B', 12));
            bookGui.bookList.q[0].k.Add(new Copy(2, 1, 2, 'A', 12));
            bookGui.bookList.q[0].k.Add(new Copy(3, 1, 3, 'B', 12));
            bookGui.bookList.q[1].k.Add(new Copy(4, 2, 1, 'A', 12));
            bookGui.bookList.q[1].k.Add(new Copy(5, 2, 2, 'A', 12));
            bookGui.bookList.q[1].k.Add(new Copy(6, 2, 3, 'A', 12));
            bookGui.bookList.q[2].k.Add(new Copy(7, 3, 1, 'A', 12));
            bookGui.bookList.q[2].k.Add(new Copy(8, 3, 2, 'A', 12));
            bookGui.bookList.q[2].k.Add(new Copy(9, 3, 3, 'A', 12));
            bookGui.bookList.q[3].k.Add(new Copy(10, 4, 1, 'A', 12));
            bookGui.bookList.q[3].k.Add(new Copy(11, 4, 2, 'A', 12));
            bookGui.bookList.q[3].k.Add(new Copy(12, 4, 3, 'A', 12));
            bookGui.bookList.q[4].k.Add(new Copy(13, 5, 1, 'A', 12));
            bookGui.bookList.q[4].k.Add(new Copy(14, 5, 2, 'A', 12));
            bookGui.bookList.q[5].k.Add(new Copy(15, 6, 1, 'A', 12));
            bookGui.bookList.q[5].k.Add(new Copy(16, 6, 2, 'A', 12));
            //Borrower(int brNumber, string name, char sex, string address, string telephone, string email)
            borrowerGui.borrowerList.t.Add(new Borrower(1, "Trung", 'M', "Nghe An", "01693614416", "Trungvnse02967@fpt.edu.vn"));
            borrowerGui.borrowerList.t.Add(new Borrower(2, "Tiep", 'F', "XXX", "01693614416", "TiepTVse02967@fpt.edu.vn"));
            borrowerGui.borrowerList.t.Add(new Borrower(3, "Bao", 'F', "Nghe An", "01693614416", "BaoPDnse02967@fpt.edu.vn"));


            while(test) {
                Console.Clear();
                Console.WriteLine("Library system");
                Console.WriteLine("Author: SE0715, Group 1");
                Console.WriteLine("1. Nguyen Duc Trung : Register a member");
                Console.WriteLine("2. Tran Van Tiep : Register a book and copies");
                Console.WriteLine("3. Doan Manh Tien : Class Library, Program.cs");
                Console.WriteLine("4. Vu Ngoc Trung : Return a book");
                Console.WriteLine("5. Pham Duc Bao : Borrow a book, Reserve a book");
                Console.WriteLine("");
                Console.WriteLine("MENU");
                Console.WriteLine("1.   Register a member");
                Console.WriteLine("2.   Register a book and copies");
                Console.WriteLine("3.   Borrow a book");
                Console.WriteLine("4.   Return a book");
                Console.WriteLine("5.   Reserve a book");
                Console.WriteLine("6.   Exit");
                Console.Write("Please type 1, 2, 3, 4, 5 or 6: ");
                string a = Console.ReadLine();
                switch(a) {
                    case "1":

                        borrowerGui.register();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("\nRegister a book and copies");
                        bookGui.register();
                        Console.WriteLine("\n=============================\n");
                        bookGui.display();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("\nBorrow a book");
                        borrowGui.borrowBook(reserveList.reserveList, bookGui.bookList, borrowerGui.borrowerList);

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        Console.WriteLine("\nReturn a book");
                        ReturnGUI returnGUI = new ReturnGUI(borrowerGui.borrowerList, bookGui.bookList, borrowGui.borrowList);
                        returnGUI.Return();

                        Console.Clear();
                        break;
                    case "5":
                        Console.WriteLine("\nReserve a book");
                        reserveList.reserve(reserveList.reserveList, borrowerGui.borrowerList, bookGui.bookList);

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        test = false;
                        Console.WriteLine("Exit.");
                        break;
                    case "0":
                        break;
                    case "7":
                        bookGui.display();
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}