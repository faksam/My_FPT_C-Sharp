using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Session07
{
    class Program
    {
        static void PrintTime()
        {
            while(true)
            {
                Console.Write("\r{0}", DateTime.Now.ToLongTimeString());
                Thread.Sleep(1000);
            }
        }
        static void DisplayMath(object o)
        {
            if (o is Math)
            {
                Math m = (Math)o;
                m.Run();
            }
        }
        //concurrency demo
        static void Con()
        {
            Math m = new Math();
            for (int i = 1; i <= 3; i++)
            {
                ThreadStart ts = new ThreadStart(m.Run);
                Thread t = new Thread(ts);
                t.Start();
            }
        }

        static void DisplayTime(object o)
        {
            Console.WriteLine("Display Time");
            Console.WriteLine("\r{0}, parameters {1}", DateTime.Now.ToLongTimeString(), o.ToString());
        }


        static void Main(string[] args)
        {
            //            Con();
            Console.WriteLine("Main starts and so something");
            TimerCallback callback = new TimerCallback(DisplayTime);
            Timer t = new Timer(callback, "Param.value", 0, 1000);
            Thread.Sleep(1000);
            Console.WriteLine("Main exist");


            /*
            Console.WriteLine("Main starts do something...");
           // PrintTime();
            ThreadStart ts = new ThreadStart(PrintTime);
            //create a new thread reference by t
            Thread t = new Thread(ts);
            t.Priority = ThreadPriority.BelowNormal;
            t.Name = "Threat 1";
            //started
            t.Start();

            //create an another thread
            Math m = new Math();
            ParameterizedThreadStart pts = new ParameterizedThreadStart(DisplayMath);
            Thread t2 = new Thread(pts);
            t2.Priority = ThreadPriority.Highest;
            t2.Name = "Thread 2";
            t2.Start(m);


            Console.WriteLine("Main exist");




            */
        }
    }
}
