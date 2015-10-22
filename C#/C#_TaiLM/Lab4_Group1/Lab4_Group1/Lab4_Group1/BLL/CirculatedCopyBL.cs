using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab4_Group1.DAL;
using Lab4_Group1.DTL;
using System.Data;
using System.ComponentModel;

namespace Lab4_Group1.BLL
{
    [DataObject]
    public class CirculatedCopyBL
    {
        public static bool isContainBorrowerCode(int memberCode) {
            if (BorrowerDA.getNameMember(memberCode) == null) return false;
            else return true;            
        }
        public static string getNameBorrower(int memberCode) {
            return BorrowerDA.getNameMember(memberCode);
        }
        public static DataSet selectDs() {
            return CirculatedCopyDA.SelectDS();
        }

        public static bool Insert(CirculatedCopy c) {
            return CirculatedCopyDA.Insert(c);
        }

        public static bool Update(CirculatedCopy b)
        {
            return CirculatedCopyDA.Update(b);
        }

        public static bool Delete(CirculatedCopy b)
        {
            return CirculatedCopyDA.Delete(b);
        }
    }
}
