using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateSample
    
{
    public delegate void MyPrint(string name);
    class Program
    {
        //parameter: 1
        //type of parameter:String
        //list of parameter:String name
        static void Morning(string name)
        {
            Console.WriteLine("Good Morning " + name.ToUpper());
        }
       
        static void Evening(string name)
        {
            Console.WriteLine("Good Evening " + name.ToUpper());
        }
        static void Main(string[] args)
        {
           //MyPrint point to function morning and evening
            MyPrint mp = new MyPrint(Morning);
            mp += Evening;
            mp -= Morning;
            //calling multicasting
            mp("Nam");
            //execute the body of all functions that are pointed by mp

        }

    }
}
