using System;
using System.Collections.Generic;
using System.Text;

namespace com.sample

{
    class worker : Human
    {
        // working hours
        private int hours;
        // class properties
        public int Hours
        {
            get { return hours; }
            set{hours = value;}
        }
        public void print()
        {
            // call the function named ToString from base class
            Console.WriteLine(base.ToString());
            Console.WriteLine("working hours:" + Hours);
        }
        //constructor
        public worker()
            :base() // call the constructor from base class
        {
            Hours = 0;
        }
        //destructor
           ~worker()
        {
               // automatically call when the object is out of scope
            Console.WriteLine("Removing worker named " + base.Name);
        }
    }
}
