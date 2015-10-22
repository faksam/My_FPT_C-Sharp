using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session02
{
    class Program
    {
        static void PrintString(params string [] s)
        {
            //1. visit all items of s
            //2. print each visited item
            foreach (string item in s)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string []args)
        {
                        
        }
    }
}
