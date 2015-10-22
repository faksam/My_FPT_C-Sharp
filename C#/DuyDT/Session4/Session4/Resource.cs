using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session4
{
    abstract class Resource
    {
        private string name;
        public Resource(string name)
        {
            this.name = name;
        }
        public abstract double GetPrice();
    }
}
