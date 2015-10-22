using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSample
{
    class Program
    {
        static void Exchange<T>(ref T a, ref T b)
        {
           T temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args)
        {
            int a = 3, b = 5;
            Exchange<int>(ref a, ref b);
            Console.WriteLine("Now, a = {0}, b = {1}",a,b);
            double d1 = 3.2, d2 = 3.3;
            Exchange<double>(ref d1, ref d2);
            Console.WriteLine("Now, a = {0}, b = {1}", d1, d2);
            char c1 = 'A', c2 = 'B';
            Exchange<char>(ref c1, ref c2);
            Console.WriteLine("Now, a = {0}, b = {1}", c1, c2);
            Console.ReadKey();
        }
    }
}
