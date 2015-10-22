using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return string.Format("{0, -20}{1, -10}", name, price);
        }


        #region Icomparable Members
        public int CompareTo(object obj)
        {
            //take compare between this and obj
            Book b = (Book)obj;
            if (this.price > b.price) return GREAT;
            else if (this.price == b.price) return EQUAL;
            else return LESS;
        }
        #endregion

        //integer constant for compareTo method
        private const int EQUAL = 0;
        private const int LESS = -1;
        private const int GREAT = 1;
    }
}
