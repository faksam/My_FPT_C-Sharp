using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4_Group1.DTL
{
    class Copy
    {
        private int copyNumber;

        public int CopyNumber
        {
            get { return copyNumber; }
            set { copyNumber = value; }
        }
        private int bookNumber;

        public int BookNumber
        {
            get { return bookNumber; }
            set { bookNumber = value; }
        }


        private int sequenceNumber;

        public int SequenceNumber
        {
            get { return sequenceNumber; }
            set { sequenceNumber = value; }
        }
        char type;

        public char Type
        {
            get { return type; }
            set { type = value; }
        }
        float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        public Copy() { }
        public Copy(int copyN, int bkN, int sqN, char ty, float pri)
        {
            copyNumber = copyN;
            bookNumber = bkN;
            sequenceNumber = sqN;
            type = ty;
            price = pri;

        }
        public void display()
        {
            Console.WriteLine("     {0,-5} {1,-10} {2,-5} {3,-5} ", sequenceNumber, copyNumber, type, price);
        }
    }
}
