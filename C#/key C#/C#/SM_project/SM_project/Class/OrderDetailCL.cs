using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SM_project.Class
{
    public class OrderDetailCL
    {
        private int orderID;

        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        private int productID;

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        
        public OrderDetailCL()
        {

        }

        public OrderDetailCL(int or,int pro,int quan,double pri)
        {
            orderID = or;
            productID = pro;
            quantity = quan;
            price = pri;
        }
    }
}
