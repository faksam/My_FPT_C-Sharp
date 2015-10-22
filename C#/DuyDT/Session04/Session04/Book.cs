using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session04
{
    class Book : Resource, IComparable
    {
        private double price;
        public Book(string name, double price)
            : base(name)
        {
            this.price = price;
        }

        public override double GetPrice()
        {
            return this.price;
        }

        public override string ToString()
        {
            return string.Format("{0,-20}{1,-10}",name,price);
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            //take compare between this and obj by price
            Book b = (Book)obj;
            if (this.price > b.price) return GREAT;
            else if (this.price == b.price) return EQUAL;
            else return LESS;
        }

        #endregion

        //integer constant for compareto method
        private const int EQUAL = 0;
        private const int LESS = -1;
        private const int GREAT = 1;
    }
}
