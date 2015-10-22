using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
   
    class Register
    {
        public void AddDoctor(string code, string name, string spe)
        {
            Console.Write("Enter code: ");
           code = Console.ReadLine();
           Console.Write("Enter name: ");
            name = Console.ReadLine();
            Console.Write("Enter specialization: ");
            spe = Console.ReadLine();
         Console.WriteLine("Do Add Doctor: {0} {1} {2}",  code, name, spe);

        }
    }
}
