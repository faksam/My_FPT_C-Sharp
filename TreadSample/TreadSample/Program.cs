using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TreadSample
{
    class Program
    {
        //first job
        static void PrintTime()
        {
            Console.WriteLine("this is my first job, print current datetime");
            while(true)
            {
               //print current datetime
                Console.Write("\r{0}", DateTime.Now);
                //pause in a second
                Thread.Sleep(1000);
            }
        }
        //2nd job
        static void PrintMessage(object obj)
        {
            Console.WriteLine("this is 2nd job, print message");
            Thread.Sleep(1000);
            Console.WriteLine("Receive input parameter:" + obj);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("this is main function..");
            Console.WriteLine(" main function running..");
            //make a new thread t1, make t2 and main function
            //run together at the same time
            //1. use threadstart delegate point to printTime
           // ThreadStart ts = new ThreadStart(PrintTime);
            ParameterizedThreadStart ts = new ParameterizedThreadStart(PrintMessage);
            //2. make new thread from threadstaart
            Thread t = new Thread(ts);
            //starts t
            t.Start("the second thread"); 
            //it means that execute the body of printtime
            Console.ReadKey();
        }
    }
}
