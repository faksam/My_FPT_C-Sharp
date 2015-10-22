using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{

    class Program
    {
        private bool CheckValue(string p)
        {
            if (String.IsNullOrEmpty(p)) return false;
            bool test = true;

            foreach (char c in p.ToCharArray())
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
            Publish k = new Publish();
            string Code, Name, Special;
            bool mode = true;
            do
            {
                int iChoice;
                Console.WriteLine("");
                Console.WriteLine("Enter your choice: ");
                Console.WriteLine("1. Register Doctor");
                Console.WriteLine("2. Search and display the Doctor details");
                Console.WriteLine("3. Publish the entire list");
                Console.WriteLine("4. Exit");
                iChoice = int.Parse(Console.ReadLine());
                Console.Clear();
                bool isDone = false;
                switch (iChoice)
                {
                    case 1:
                        Register doc = new Register();
                        doc.AddDoctor("SE09", "Kh", "JI");
                            break;
                    case 2:
                       Console.Write("Enter Code: ");
                        string temp = Console.ReadLine();
                        search Dtemp = k.SearchByCode(temp);

                        if (Dtemp != null)
                        {
                            Console.WriteLine("{0}, {1}, {2}", Dtemp.Code, Dtemp.Name, Dtemp.Special);
                        }
                        else
                        {
                            Console.WriteLine("The doctor {0} does not exit", temp);
                        }
                       
                        break;

                    case 3:
                        k.PrintAll();
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
