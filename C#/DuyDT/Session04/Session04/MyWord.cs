using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Session04
{
    class MyWord
    {
        private Hashtable ht;
        public MyWord()
        {
            ht = new Hashtable();
        }
        //add an item to ht 
        public void AddItem(string key, string value)
        {
            ht.Add(key.ToLower(), value.Normalize());
        }
        //look up a word by key
        public void LookUp(string key)
        {
            //if key is found in ht
            if (ht.ContainsKey(key))
                Console.WriteLine("{0} stand for {1}", key, ht[key]);
            else
                Console.WriteLine("{0} does not exsist",key);
        }
        //print all words
        public void PrintAll()
        {
            
        }
    }
}
