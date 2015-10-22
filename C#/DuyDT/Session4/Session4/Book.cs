using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session4
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
            return price;
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            //compare between this and obj by price
            Book b = (Book)obj;
            if (this.price > b.price) return GREATE;
            else if (this.price == b.price) return EQUAL;
            else return LESS;
        }

        #endregion
        //constant for CompareTo method
        private const int LESS = -1;
        private const int EQUAL = 0;
        private const int GREATE = 1;
    }
}
