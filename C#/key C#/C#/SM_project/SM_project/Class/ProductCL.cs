using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SM_project.Class
{
    class ProductCL
    {
        private int productID;

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        private int supplierId;

        public int SupplierId
        {
            get { return supplierId; }
            set { supplierId = value; }
        }
        private string supplierName;

        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public ProductCL()
        {

        }

        public ProductCL(int ID,string name,int supID,string supName,double pri)
        {
            productID = ID;
            productName = name;
            supplierId = supID;
            supplierName = supName;
            price = pri;
        }

        public ProductCL(int ID, string name, string supName, double pri)
        {
            productID = ID;
            productName = name;
            supplierName = supName;
            price = pri;
        }

    }
}
