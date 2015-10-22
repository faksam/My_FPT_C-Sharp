using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session4
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
        {/*
            try
            {
                int[] a = new int[2];
                a[0] = 1;
                a[1] = 2;
                a[2] = 3;
            }
            catch (MyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch
            {
                Console.WriteLine("there is something wrong...");
            }
            finally
            {
                //clean up
            
            }
            */

            /*
             * to do list;
             * 1. enter an integer number
             * 2. repeat until u get whole number
             * 3. print out the whole number
            */
            bool isDone = false;
            while (!isDone)
            {
                try
                {
                    Console.Write("Enter a whole number: ");
                    string s = Console.ReadLine();
                    if (string.IsNullOrEmpty(s))
                        throw new MyException("input cannot be empty");
                    //convert s to a whole number
                    int i = int.Parse(s);
                    //i = convert.ToInt32(s);
                    Console.WriteLine("thank you, whole number is {0}", i);
                    isDone = true;
                }
                catch (MyException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            bookList b1 = new bookList();
            //add some new items
            b1.AddBook(new Book("C ", 34.2));
            b1.AddBook(new Book("Java", 40.8));
            b1.AddBook(new Book("Pascal", 3.7));
            b1.DoSort();
           
            MyWord mw = new MyWord();
            /*to do list
             * 1. build my word
             * 2. get a key from the user and look for stand for stand for the key
             * 3. stop if key is empty
             * */
            mw.AddItem("doc", "Document");
            mw.AddItem("exe", "Executable");
            mw.AddItem("txt", "Text");
            mw.AddItem("bmp", "Bitmap Image");
            mw.AddItem("khj", "Khanh Huyen KHJ");
            string key = "start";
            while (!string.IsNullOrEmpty(key))
            {
                Console.Write("Enter a key (empty to stop) : ");
                    key = Console.ReadLine();
                if (!string.IsNullOrEmpty(key))
                    mw.LookUp(key);
            }

        }
    }
}
