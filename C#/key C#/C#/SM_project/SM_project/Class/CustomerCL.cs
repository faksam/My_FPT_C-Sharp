using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SM_project.Class {
    class CustomerCL {
        private int customerID;
        public int CustomerID{
            get {
                return customerID;
            }
            set {
                customerID = value;
            }
        }
        private string lastname;
        public string Lastname {
            get {
                return lastname;
            }
            set {
                lastname = value;
            }
        }
        private string firstname;
        public string Firstname {
            get {
                return firstname;
            }
            set {
                firstname = value;
            }
        }
        private string companyname;
        public string Companyname {
            get {
                return companyname;
            }
            set {
                companyname = value;
            }
        }
        private string phone;
        public string Phone {
            get {
                return phone;
            }
            set {
                phone = value;
            }
        }
        private string address;
        public string Address {
            get {
                return address;
            }
            set {
                address = value;
            }
        }
        private int discount;
        public int Discount{
        get {
                return discount;
            }
            set {
                discount = value;
            }
        }
        public CustomerCL() {}
        public CustomerCL(int ID,string last, string first,string companyname,string phone,string address) {
            customerID = ID;
            lastname = last;
            firstname = first;
            this.companyname = companyname;
            this.phone = phone;
            this.address = address;
        }





    }
}
