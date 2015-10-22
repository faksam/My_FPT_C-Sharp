using System;
using System.Collections.Generic;
using System.Text;

namespace console_2.Dom
{
    class Program
    {
        
       /* static void Increment(out int v)
        {
            v = 20;
            v = v + 10;
            Console.WriteLine("Increment.v.value = " + v);

        }
        static void Main(string[] args)
        {

            int v = 20;
            Console.WriteLine("Main.v.value = " + v);
            // increment v by 10
            Increment(out v);
            Console.WriteLine("After increment v by 10, v.value = " + v);
            Console.ReadKey();
        }*/
        static void Main(string[] args)
        {
            //create a new instance of coffe
            coffee c = new coffee();
            coffee d = new coffee();
            // call write property
            c.BrandName = "G7";
            c.Price = 4.7;
            //display c
            // call read property
            Console.WriteLine("coffee.BrandName: " + c.BrandName);
            Console.WriteLine("coffee.Price: " + c.Price);
            Console.ReadKey();

        }
    }
}
