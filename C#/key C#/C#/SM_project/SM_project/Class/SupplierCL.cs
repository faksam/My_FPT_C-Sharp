using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SM_project.Class
{
    class SupplierCL
    {
        private int supplierID;

        public int SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }

        private string comName;

        public string ComName
        {
            get { return comName; }
            set { comName = value; }
        }

        private string conName;

        public string ConName
        {
            get { return conName; }
            set { conName = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string fax;

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public SupplierCL() { }
        public SupplierCL(int SupID, string comName, string conName, string address, string phone, string fax) {
            this.supplierID = SupID;
            this.comName = comName;
            this.conName = conName;
            this.address = address;
            this.phone = phone;
            this.fax = fax;
        }
    }
}
