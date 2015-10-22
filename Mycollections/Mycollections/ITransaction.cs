using System;
using System.Collections.Generic;
using System.Text;

namespace Mycollections
{
    interface ITransaction
    {
        //only accept abstract method/functions
        double getPrice();
        void ShowTransaction();
    }
}
