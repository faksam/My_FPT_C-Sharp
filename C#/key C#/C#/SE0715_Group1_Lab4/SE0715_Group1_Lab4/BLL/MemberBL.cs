﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SE0715_Group1_Lab4.DTL;
using SE0715_Group1_Lab4.DAL;
using System.Data;

namespace SE0715_Group1_Lab4.BLL
{
    class MemberBL
    {
        public static DataSet SelectDS()
        {
            return MemberDA.SelectDS();
        }

        public static bool Insert(Borrower b)
        {
            return MemberDA.Insert(b);
        }
        public static bool Update(Borrower b)
        {
            return MemberDA.Update(b);
        }
        public static bool Delete(Borrower b)
        {
            return MemberDA.Delete(b);
        }
        public static int GetMaxBorrower()
        {
            return MemberDA.GetMaxBorrower();
        }
        public static Borrower SelectByID(string s)
        {
            return MemberDA.SelectByID(s);
        }
    }
}
