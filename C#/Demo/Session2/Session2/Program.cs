using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs =  com.sample;

namespace Session2
{
    class Program
    {
       //const int MAX = 100;

        //static void swap(out int x, out int y)
        //{
         //   x = 3;
         //   y = 5;
           // int tg = x;
            //x = y;
            //y = tg;

        //}
        static void PrintString(params string[] s)
        {
            foreach (string item in s)
            {
                Console.WriteLine(item);
            }
        
        }

        static void Main(string[] args)
        {
            //int x, y;
            //swap(out x, out y);
            //Console.WriteLine("x= {0}, y = {1}", x, y);
            
            /*
            DateTime today = DateTime.Now;
            Console.WriteLine("hello, today is: ");
            Console.WriteLine(string.Format("{0:dd MM yyyy}", today));
            PrintString(new string[]{"Hello", "xin chao", "chao"});
            PrintString("Good bye", "bye", "Tam biet");
            */

            /*Console.Write("Enter a string: ");
            string s = Console.ReadLine();
            foreach (char c in s.ToCharArray())
            {
                if (char.IsLetter(c))
                    Console.WriteLine(c);
            }
            */

           // int x = 10;
            //object obj = x; //boxing
            //int y = (int)obj; //unboxing

            com.sample.MyClass mc = new com.sample.MyClass();
            cs.MyClass mc1 = new cs.MyClass();
        }
    }
}
