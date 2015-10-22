using System;
using System.Collections.Generic;
using System.Text;

namespace console_2.Dom
{
    class coffee
    {
        // data members
        private String brandName;
        private double price;
        // member functions 
        //properties
        public String BrandName
        {
            //read property
            get { return brandName; }
            //write property
            set { brandName = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
