using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session04
{
    abstract class Resource
    {
        protected string name;
        public Resource(string name)
        {
            this.name = name;
        }
        public Resource()
        {
            name = "";
        }
        public abstract double GetPrice();
    }
}
