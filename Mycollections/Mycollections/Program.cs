using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Mycollections
{
    class Program
    {
        static void Main(string[] args)
        {

            /*//make a new instance of ITransaction
            ITransaction it = new  MyTransaction();
            it.ShowTransaction();
            */
            
            
            
            /* // my small dictionary
            Hashtable ht = new Hashtable();
            // an item in ht as from key-value
            ht.Add("doc", "document");
            ht.Add("exe", "Executable");
            ht.Add("tcp", "Transmission control protocol");
            ht.Add("smatp", "Simple Mail Transfer Protocol");
            // look up a value which is given by key
            Console.Write("Enter a key: ");
            string key = Console.ReadLine();
           
            //if key exists
            if (ht.ContainsKey(key) == true)
                Console.WriteLine("Your value is: " + ht[key]);
            else
                Console.WriteLine("sorry, the key " + key + "does not exists");
            //print all value of ht
            IEnumerator keySet = ht.Keys.GetEnumerator();
            //visit all items of keySet
            while(keySet.MoveNext() == true)
            {
                //get current key
                string currentKey = keySet.Current.ToString();
                //get value at specific key
                Console.WriteLine(currentKey + " : " + ht[currentKey]);
            }
            Console.ReadKey();*/




            // create a new instance of arraylist
             ArrayList a = new ArrayList();
             //add an integer number
             a.Add(200);
             a.Add(3.14); // double vale
             a.Add(true);//boolean value
             a.Add("Good moring"); // a String value
             a.Add(300);
             Console.WriteLine("a count: " + a.Count);
             Console.WriteLine("a.cpacity: " + a.Capacity);
              // visit all item of a and print integer numbere only
             for (int i = 0; i < a.Count; i++)
             {
                 object obj = a[i];
                 // if obj is integer number, print obj
                 if (obj is int)
                 {
                     int k = (int)obj;//unboxing
                     Console.WriteLine(k);
                     //Console.WriteLine(obj);
                 }
             }
        }
    }
}
