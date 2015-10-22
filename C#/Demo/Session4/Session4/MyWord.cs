using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Session4
{
    class MyWord
    {
        private Hashtable ht;
        public MyWord()
        {
            ht = new Hashtable();

        }
        //add an iten to ht
        public void AddItem(string key, string value)
        {
            ht.Add(key.ToLower(), value.Normalize());
        }
        //look up a qord by key
        public void LookUp(string key)
        {
            //if key is found indexer ht
            if (ht.ContainsKey(key))
                Console.WriteLine("{0} stand for {1}", key, ht[key]);
            else Console.WriteLine("{0} does not exsist", key);
        }
        //print all words
        public void PrintAll()
        {
            
        }

    }
}