using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Lap1
{
    class Doctor
    {
        private string code;
        private string name;
        private string special;
        public string Name 
        { 
            get { return this.name; } 
            set { name = value; } 
        }

        public string Code 
        { 
            get{ return this.code; }
            set { code = value; } 
        }


        public string Special 
        {
            get { return this.special; } 
            set { special = value; } 
        }
        public Doctor(string code,string name, string special)
        {
            Code = code;
            Name = name;
            Special = special;
            
        }
    }
}
