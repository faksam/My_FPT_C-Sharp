using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lap1
{
    class Program
    {
        private bool CheckValue(string pw)
        {
            if (String.IsNullOrEmpty(pw)) return false;
            bool test = true;

            foreach (char c in pw.ToCharArray())
            {
                if (char.IsNumber(c))
                {
                    test = false;
                }
            }
            return test;

        }
        static void Main(string[] args)
        {
            DoctorList d = new DoctorList();
            string CODE, NAME, SPECIAL;
            bool mode = true;
            do
            {
                int iChoice;
                Console.WriteLine("");
                Console.WriteLine("Your choice: ");
                Console.WriteLine("1.   Register Doctor");
                Console.WriteLine("2.   Search and display the Doctor details");
                Console.WriteLine("3.   Publish the entire list");
                Console.WriteLine("4.   Exit");
                iChoice = int.Parse(Console.ReadLine());
                Console.Clear();
                bool isDone = false;
                switch (iChoice)
                {
                    case 1:
                        Console.Write("Enter Code: ");
                        CODE = Console.ReadLine();
                        while (!isDone)
                        {
                            try
                            {
                                Console.Write("Enter Name: ");
                                NAME = Console.ReadLine();
                                if (string.IsNullOrEmpty(NAME))
                                    throw new ArgumentException("input cannot be empty");
                                Program p =new Program();
                                if (!p.CheckValue(NAME))
                                    throw new FormatException("Wrong format");
                                Console.Write("Enter Specialization: ");
                                SPECIAL = Console.ReadLine();
                                d.add(new Doctor(CODE, NAME, SPECIAL));
                                isDone = true;
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 2:
                        Console.Write("Enter Code: ");
                        string temp = Console.ReadLine();
                        Doctor Dtemp = d.SearchByCode(temp);

                        if (Dtemp != null)
                        {
                            Console.WriteLine("{0}, {1:-20}, {2:-20}", Dtemp.Code, Dtemp.Name, Dtemp.Special);
                        }
                        else
                        {
                            Console.WriteLine("The doctor ID {0} does not exit", temp);
                        }
                        break;

                    case 3:
                        d.PrintAll();
                        break;
                    case 4:
                        mode = false;
                        break;
                }
            }
            while (mode);
        }
    }
}
