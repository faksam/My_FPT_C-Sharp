using System;
using System.Collections.Generic;
using System.Text;

namespace ISE0901_dom_1.consoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Console.WriteLine("Enter your name: ");
             String name = Console.ReadLine();
             Console.WriteLine("hello "  +  name);
             Console.WriteLine("hello {0, -5}{1, -10}" ,20, name);
             Console.WriteLine("hello {0, 5}{1, 10}", 20, name );
             Console.WriteLine("Hello, this is a message from c# program");
             Console.ReadLine();*/


           /* bool keepgoing = true;
            while (keepgoing == true)
            {
                Console.WriteLine("Enter your age:");
                String sage = Console.ReadLine();
                // convert sage to an integer number
                try
                {
                    int iage = int.Parse(sage);
                    iage = Convert.ToInt32(sage);
                    // print the result
                    Console.WriteLine("your age is " + iage);
                    // if you are here, it means that sage is correct
                    keepgoing = false;

                }
                catch (FormatException e)
                {
                    Console.WriteLine("input string is not correct format...");
                }
            }*/

            Console.WriteLine("Enter your age:");
            String sage = Console.ReadLine();
            int age = 0;
            // try to convert sage to an integer number
            // tryparse return true if convertion is ok otherwise return false
            if(int.TryParse(sage, out age ) == true)
            {
                Console.WriteLine("your age is " + age);

            }
            else
            {
                Console.WriteLine("your input string is not correct!!");
            }

        }
    }
}
