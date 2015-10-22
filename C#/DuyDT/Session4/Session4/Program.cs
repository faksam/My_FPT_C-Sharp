using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session4
{
    class Program
    {
        static void Main(string[] args)
        {
             /*to do list
              * 1. enter an integer number
              * 2. repeat until we get a whole number
              * 3. print out the value of whole number
              */
            bool isDone = false;
            while (!isDone)
            {
                try
                {
                    Console.Write("Enter an integer number: ");
                    string s = Console.ReadLine();
                    if (string.IsNullOrEmpty(s))
                        throw new MyException("input cannot be empty");
                    //convert s to an integer number
                    int i = int.Parse(s);
                    //i = Convert.ToInt32(s);
                    Console.WriteLine("Thank you,the whole number is {0}",i);
                    isDone = true;
                }
                catch (MyException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
