using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4_Group3.DTL
{
    public class Copy
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

        private char type;

        public char Type1
        {
            get { return type; }
            set { type = value; }
        }

        public char Type
        {
            get { return type; }
            set { type = value; }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }


        public Copy()
        {
        }

        public Copy(int bookNumber, int copyNumber, int sequenceNumber, char type, double price)
        {
            this.copyNumber = copyNumber;
            this.bookNumber = bookNumber;
            this.sequenceNumber = sequenceNumber;
            this.type = type;
            this.price = price;
        }

        public override string ToString()
        {
            return (copyNumber.ToString() + '\t' + bookNumber.ToString() + '\t' + sequenceNumber + '\t' + type + '\t' + price.ToString() + "USD");
        }
    }
}
