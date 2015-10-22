using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SM_project.Class
{
    public class OrderCL
    {
        private int orderID;

        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        private int customerID;

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        private int employeeID;

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        private int discount;

        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public OrderCL()
        {
                
        }

        public OrderCL(int or,int cus,int em,int dis)
        {
            orderID = or;
            customerID = cus;
            employeeID = em;
            discount = dis;
        }
    }
}
