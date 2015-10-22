using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanakTransact
{
    class Program
    {
        static void Main(string[] args)
        {
            ItTransaction it = new ItInplement();
            
            
            Console.WriteLine("Customer Info:");
            it.openTransaction();
            it.amount();
        }
    }
}
