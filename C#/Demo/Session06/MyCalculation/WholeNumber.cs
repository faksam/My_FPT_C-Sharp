using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculation
{
    public class WholeNumber
    {
        //return true if x is an even number
        public bool IsEven(int x)
        {
            return (x % 2 == 0);

        }
        //return true if x is an odd number
        public bool IsOdd(int x)
        {
            return (x % 2 != 0);

        }
        //return true if s contains letter characters only 
        public bool IsLetter(string s)
        {
            foreach (char c in s.ToArray())
            {
                if (!char.IsLetter(c)) return false;
            }
            return true;
        }
    }
}
