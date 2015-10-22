using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session06
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCalculation.WholeNumber wm = new MyCalculation.WholeNumber();
            Console.WriteLine(wm.IsLetter("Hello 2014"));
        }
    }
}
