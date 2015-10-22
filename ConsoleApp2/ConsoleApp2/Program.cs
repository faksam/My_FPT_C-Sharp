using System;
using System.Collections.Generic;
using System.Text;
using com.sample;
using cs = com.sample;
namespace ConsoleApp2

{
    class Program
    {
        static void Main(string[] args)
        {
           /* // fully qualified namespace
            com.sample.Human h = new com.sample.Human();
           // Human h = new Human();
            h.Name = "your name willl be put here";
            Console.WriteLine(h.Name); // call reader class properties
            Console.WriteLine(h); // call the function name ToString () of Hamen
            //alies namespace
            cs.Human h1 = new cs.Human(); */


            worker an = new worker();
            an.Name = "An";
            an.Hours = 120;
            an.print();
            Console.WriteLine("End of program");

        }
    }
}
