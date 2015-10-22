using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3_Group1.DAL;
using Lab3_Group1.DTL;
using System.Data;

namespace Lab3_Group1.BLL
{
    class CirculatedCopyBL
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
        public static bool insert(CirculatedCopy c) {
            return CirculatedCopyDA.Insert(c);
        }
    }
}
