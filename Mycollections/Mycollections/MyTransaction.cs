using System;
using System.Collections.Generic;
using System.Text;

namespace Mycollections
{
    class MyTransaction : ITransaction
    {
        #region ITransaction Members

        public double getPrice()
        {
            return 0;
        }

        public void ShowTransaction()
        {
            Console.WriteLine("Transaction is being process...");
        }
        #endregion
    }
}