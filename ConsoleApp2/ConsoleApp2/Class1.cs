using System;
using System.Collections.Generic;
using System.Text;

namespace com.sample


{
    class Human

    {
       // data members
        private String name;
        // class properties
        public String Name
    {
        get {return name;}
         set {name = value;}
    }
        // the ToString function is needed whenever you print an object
        public override string ToString()

    {
        return Name;
    }

    }
}
