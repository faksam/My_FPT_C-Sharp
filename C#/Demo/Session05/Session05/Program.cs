using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        this.x= x;
        this.y=y;

        }   
        public override string ToString()
        {
            return string.Format("[{0}, {1}]", x, y);

        }
        public void ResetPoint()
        {
            x = default(T);
            y = default(T);
        }

    }

    class Program
    {
       /* public void DoAdd(int x, int y)
        {
            Console.WriteLine("Do Add: {0}",  (x + y));
        }
        public void DoSub(int x, int y)
        {
            Console.WriteLine("Do Sub: {0}", (x - y));
        }
        public void DoMul(int x, int y)
        {
            Console.WriteLine("Do Mul: {0}", (x * y));
        }*/
        public void PrintEven(int x)
        {
            if (x % 2 == 0)
                Console.WriteLine(x);
        }
        public void PrintOdd(int x)
        {
            if (x %2 !=0)
            Console.WriteLine(x);
        }
        static void swap<T>(ref T x, ref T y)
        {
            Console.WriteLine("swap method a {0}", typeof(T));
            
            T tg = x;
            x = y;
            y = tg;
        }


        static void Main(string[] args)
        {/* 1
            Program p = new Program();
            //delegate named mm point to p.DoAdd
            MyMath mm = new MyMath(p.DoAdd);
            mm += p.DoSub;
            mm += p.DoMul;

          //  mm(5, 9);
            /*todo list
             * 1. visit all methods which are pointed by mm
             * 2. invoke each of item
             
            foreach (Delegate d in mm.GetInvocationList())
            {
                object[] param = new object[2] { 4, 5 };

                //if d is an instance of DoAdd
                if (d.Method.Name.Equals("DoAdd"))
                    d.DynamicInvoke(param);
            }*/


            /*MyList ml = new MyList(5);
            for (int i = 0; i < 7; i++)
                ml.AddItem(i);
            //print all even numbers
            Program p = new Program();
            MyPrint mp = new MyPrint(p.PrintEven);
            ml.VisitAll(mp);*/

            /*ArrayList a = new ArrayList();
            a.Add(100);
            a.Add("Hello");
            a.Add(new MyList(4));*/
            List<int> a = new List<int>();
            List<MyList> b = new List<MyList>();
            int x = 3, y = 5;
            swap(ref x, ref y);
            Console.WriteLine(" x= {0}, y = {1}\n", x, y);
            float f1 = 3.14f, f2 = 5.4f;
            swap<float>(ref f1, ref f2);
            Console.WriteLine("f1 = {0}, f2 = {1}\n", f1, f2);
            //points using int
            Point<int> pint = new Point<int>(0, 0);
            //points using float
            Point<float> pfloat = new Point<float>(1.0f, 1.0f);
            Console.WriteLine(pfloat);



        }
    }
}
