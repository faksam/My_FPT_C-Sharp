using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Session05
{
    public delegate void MyMath(int x, int y);
    public delegate void MyPrint(int x);
    //generic for struct
    public struct Point<T>
    {
        private T x, y;
        public Point(T x, T y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return string.Format("[{0},{1}]",x,y);
        }
        public void ResetPoint()
        {
            x = default(T);
            y = default(T);
        }
    }
    class Program
    {
        public void PrintEven(int x)
        {
            if (x % 2 == 0)
                Console.WriteLine(x);
        }
        public void PrintOdd(int x)
        {
            if (x % 2 != 0)
                Console.WriteLine(x);
        }

        static void swap<T>(ref T x, ref T y)
        {
            Console.WriteLine("swap method a {0}",typeof(T));
            T tg = x;
            x = y;
            y = tg;
        }
        static void Main(string[] args)
        {
            List<int> a = new List<int>();
            List<MyList> b = new List<MyList>();
            int x = 3, y = 5;
            swap<int>(ref x, ref y);
            Console.WriteLine("x = {0}, y = {1}\n",x,y);
            float f1 = 3.14f, f2 = 5.4f;
            swap<float>(ref f1, ref f2);
            Console.WriteLine("f1 = {0}, f2 = {1}\n", f1, f2);
            //points using int
            Point<int> pint = new Point<int>(0, 0);
            //points using float
            Point<float> pfloat = new Point<float>(1.0f, 1.0f);
            Console.WriteLine(pint);
        }
    }
}
