using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session05
{
    public delegate void MyMath(int x, int y);
    class Program
    {
        public void DoAdd(int x, int y)
        {
            Console.WriteLine("DoAdd: {0}", (x + y));
        }

        public void DoSub(int x, int y)
        {
            Console.WriteLine("DoSub: {0}", (x - y));
        }

        public void DoMul(int x, int y)
        {
            Console.WriteLine("DoMul: {0}", (x * y));
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            //delegate named mm point to p.DoAdd
            MyMath mm = new MyMath(p.DoAdd);
            //mm point o p.DoSub and p.DoMul
            mm += p.DoSub;
            mm += p.DoMul;
            //call all methods which are pointed by mm
            mm(5, 9);
        }
    }
}
