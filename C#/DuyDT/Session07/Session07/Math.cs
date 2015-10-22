using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Session07
{
    class Math
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
        public Math()
        {
        }
        public void Run()
        {
            //lock current thread 
            //lock (this)
            Monitor.Enter(this);
            {
                Console.WriteLine("Entering run method");
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("{0}", i);
                    Random r = new Random();
                    Thread.Sleep(r.Next(100, 500));
                }
                Console.WriteLine("Finishing run method");
            }
            Monitor.Exit(this);
        }
    }
}
