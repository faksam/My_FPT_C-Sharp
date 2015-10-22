using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please your name:");
            String name1 = Console.ReadLine();

            Console.WriteLine("please your name:");
            String name2 = Console.ReadLine();

            Console.WriteLine("my name is " + name1 + "\n my name is" + name2);
            Console.ReadKey();
        }
    }
}
