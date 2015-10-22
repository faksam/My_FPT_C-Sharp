using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2_ClassLibrary
{

    public class Copy
    {
        public int cNumber;
        public int bNumber;
        public int seqNumber;
        public char type;
        public double price;
        public Copy()
        {
        }
        public Copy(int cNumber, int bNumber, int seqNumber, char type, double price)
        {
            this.cNumber = cNumber;
            this.bNumber = bNumber;
            this.seqNumber = seqNumber;
            this.type = type;
            this.price = price;
        }
        public override String ToString()
        {
            return cNumber + "\t" + bNumber + "\t" + seqNumber + "\t" + type + "\t" + price;
        }
    }

    public class CopyList
    {
        public List<Copy> q;

        public CopyList()
        {
            q = new List<Copy>();
        }

    }
}
