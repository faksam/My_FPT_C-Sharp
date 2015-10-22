using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2_ClassLibrary;

namespace Lab2_Application
{
    class BookGUI
    {
        public BookList bookList;
        public CopyList copyList;
        public int bn = 7;//so quyen sach
        public int seq = 1;//
        public int cn = 17;//so copy

        public BookGUI()
        {
            copyList = new CopyList();
            bookList = new BookList();
        }

        public void register()
        {

            Random rand = new Random();
            Console.WriteLine("\nRegister a book");
            Console.WriteLine("Enter information to registry:");

            Console.Write("Title: ");
            String tit = Console.ReadLine();
            Console.Write("Publisher: ");
            String pub = Console.ReadLine();
            Console.Write("Authors: ");
            String au = Console.ReadLine();
            Book abc = new Book(bn, tit, au, pub);
            foreach (Book k in bookList.q)
            {
                if (k.bNumber.Equals(abc.bNumber))
                {
                    Console.WriteLine("Can't Register this book (bookNumber is unique)");
                    Console.ReadKey();
                    return;
                }
            }

            bookList.q.Add(abc);

            Console.WriteLine("Add completed !");
            bool kq = true;
            char ab1;
            while (true)
            {
                Console.Write("Do you want to create copy of this book ? (Y/N) : ");
                try
                {
                    ab1 = char.Parse(Console.ReadLine());
                    if (ab1 == 'n' || ab1 == 'N')
                    {
                        bn = bn + 1;
                        kq = false;
                        break;
                    }
                    else if (ab1 == 'y' || ab1 == 'Y')
                    {
                        kq = true;
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("You must enter Y or N!");
                }
            }
            
            while (kq)
            {
                bool test = true;
                Console.WriteLine("\nEnter information of its copies");
                Console.WriteLine("Enter information to registry:");

                char ty;
                while (true)
                {
                    Console.Write("Type ( A: Available or R: Referenced ): ");
                    try
                    {
                        ty = char.Parse(Console.ReadLine());
                        //string s1 = ty.ToString();
                        //s1 = s1.ToLower();
                        if (ty == 'a' || ty == 'r' || ty == 'A' || ty == 'R')
                        {
                            break;
                        }
                        else
                            Console.WriteLine("You must enter A or R!");
                    }
                    catch
                    {
                        Console.WriteLine("You must enter A or R!");
                    }
                }
                
                double pr = 0;
                Boolean t = false;
                while (t == false)
                {
                    Console.Write("Price: ");
                    try
                    {
                        pr = double.Parse(Console.ReadLine());
                        t = true;
                    }
                    catch
                    {
                        Console.WriteLine("Price must be a number!");
                        t = false;
                    }
                }

                Copy z = new Copy(cn, bn, seq, ty, pr);
                foreach (Copy k in copyList.q)
                {
                    if (k.cNumber.Equals(z.cNumber))
                    {
                        Console.WriteLine("Can't Register this Copy (copyNumber is unique)");
                        test = false;
                    }
                }
                if (test)
                {
                    cn = cn + 1;
                    seq = seq + 1;
                    abc.k.Add(z);
                    copyList.q.Add(z);
                }

                Console.Write("Continue to create copy of this book ? (Y/N) : ");
                string ab = Console.ReadLine();
                if (!ab.Equals("Y") && !ab.Equals("y"))
                {
                    bn = bn + 1;
                    break;
                }
            
            }

        }

        public void display()
        {
            int i = 1;
            Console.WriteLine("\nRegistered Book information and Its copies information :\n\n");

            //bNumber.ToString() + "\t" + title + "\t" + publisher + "\t" + authors;
            Console.WriteLine("Book \tTitle \t\t\tPublisher \tAuthors\n");
            foreach (Book f in bookList.q)
            {
                Console.WriteLine(f.ToString());
                Console.WriteLine("-------------------------------------------------");
                if (f.k.Count == 0)
                    Console.WriteLine("\nIts has no copy !");
                else
                {
                    Console.WriteLine("\tCopy\tBook\tSeque\tType\tPrice");
                    foreach (Copy e in f.k)
                    {
                        Console.WriteLine("\t" + e.ToString());
                    }
                }
                Console.WriteLine("-------------------------------------------------");
                i++;
            }
        }
    }
}
