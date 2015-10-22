using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2_ClassLibrary;
using System.Text.RegularExpressions;

namespace Lab2_Application
{
    class BorrrowerGUI
    {
        public BorrowerList borrowerList;
        int bn = 4;

        public BorrrowerGUI()
        {
            borrowerList = new BorrowerList();
        }

        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public void register()
        {

            Console.WriteLine("\nRegister a member");
            Console.WriteLine("Enter information to registry:");

            Console.Write("Name: ");
            String na = Console.ReadLine();
            char se = 'x';
            while (true)
            {
                Console.Write("Gender: ");
                try
                {
                    se = char.Parse(Console.ReadLine());
                    //string s = se.ToString();
                    //s = s.ToLower();
                    if (se == 'm' || se == 'f' || se == 'M' || se == 'F')
                    {
                        break;
                    }
                    else
                        Console.WriteLine("You must enter M for Male and F for Female!");
                }
                catch
                {
                    Console.WriteLine("You must enter M for Male and F for Female!");
                }
            }
            Console.Write("Address: ");
            String ad = Console.ReadLine();
            String te = null;
            while (true)
            {
                Console.Write("Telephone: ");
                te = Console.ReadLine();
                if (IsNumber(te))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Telephone must be a number!");
                }
            }
            String em;
            do
            {
                Console.Write("Email: ");
                em = Console.ReadLine();
                if (emailIsValid(em))
                    break;
                else
                    Console.WriteLine("Wrong type of email! Please try again!");
            } while (true);

            Borrower abc = new Borrower(bn, na, se, ad, te, em);
            foreach (Borrower k in borrowerList.t)
            {
                if (k.brNumber.Equals(abc.brNumber))
                {
                    Console.WriteLine("Can't Register this member (brNumber is unique)");
                    Console.ReadKey();
                    return;
                }
            }

            borrowerList.t.Add(abc);
            bn = bn + 1;

            Console.WriteLine("\n=============================\n");
            display();
        }

        public static bool emailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public void display()
        {
            Console.WriteLine("Registered Member information \n ");
            Console.WriteLine("Borrower\tName\tGender\tAddress\tTelephone\tEmail\n");
            foreach (Borrower k in borrowerList.t)
            {
                Console.WriteLine(k.ToString());
            }
        }
    }
}
