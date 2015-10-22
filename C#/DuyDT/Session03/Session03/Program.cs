using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session03
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] e = new Employee[2];
            e[0] = new Employee();
            e[1] = new Worker();
            e[0].Print();
            e[1].Print();
        }
    }
}
