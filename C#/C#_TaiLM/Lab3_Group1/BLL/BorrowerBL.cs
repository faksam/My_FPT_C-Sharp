using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3_Group1.DTL;
using Lab3_Group1.DAL;
using System.Data;

namespace Lab3_Group1.BLL
{
    class BorrowerBL
    {
        public static int borrowerNumberMax;

        public static DataSet SelectDS()
        {
            SetBorrowerNumberMax();
            return BorrowerDA.SelectDS();
        }

        public static void SetBorrowerNumberMax()
        {
            borrowerNumberMax = BorrowerDA.GetBorrowerNumberMax();
        }

        public static bool Insert(Borrower b)
        {
            return BorrowerDA.Insert(b);
        }

        public static bool Update(Borrower b)
        {
            return BorrowerDA.Update(b);
        }

        public static bool Delete(Borrower b)
        {
            return BorrowerDA.Delete(b);
        }
    }
}
