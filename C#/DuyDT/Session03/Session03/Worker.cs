using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session03
{
    class Worker : Employee
    {
        private int hrs;
        //default constructor
        public Worker()
            :base()
        {
            Console.WriteLine("Worker constructor..");
        }
        //calculate and return salary based on hrs
        public double GetSalary()
        {
            return hrs * 210;
        }
        public override void Print()
        {
            Console.WriteLine("Worker.salary: " + GetSalary());
        }
    }
}
