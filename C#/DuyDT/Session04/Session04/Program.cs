using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session04
{
    class Program
    {
        //throw ArgumentException if parameter is null or empty
        static void PrintStrint(string s)             
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentException("");
        }
        static void Main(string[] args)
        {
            MyWord mw = new MyWord();
            /*to do list
             * 1. build myword
             * 2. get a key from the user and look for stand for the key
             * 3. stop if key is empty
             */
            mw.AddItem("doc", "Document");
            mw.AddItem("exe", "Executable");
            mw.AddItem("txt", "Text");
            mw.AddItem("bmp", "Bitmap image");
            string key = "start";
            while(!string.IsNullOrEmpty(key))
            {
                Console.Write("Enter a key (empty to stop) : ");
                key = Console.ReadLine();
                if (!string.IsNullOrEmpty(key))
                    mw.LookUp(key);
            }

        }
    }
}
