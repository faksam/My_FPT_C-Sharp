using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3_Group1.DTL;
using Lab3_Group1.DAL;
using System.Data;

namespace Lab3_Group1.BLL
{
    class CopyBL
    {
        public static int copyNumberMax;
        public static int sequenceNumberMax;

        public static DataSet SelectDS()
        {
            SetCopyNumberMax();
            return CopyDA.SelectDS();
        }

        public static void SetCopyNumberMax()
        {
            copyNumberMax = CopyDA.GetCopyNumberMax();
        }
        public static void SetSequenceNumberMax(int bookNumber)
        {
            sequenceNumberMax = CopyDA.GetSequenceNumberMax(bookNumber);
        }
        public static bool Insert(Copy b)
        {
            return CopyDA.Insert(b);
        }

        public static bool Update(Copy b)
        {
            return CopyDA.Update(b);
        }

        public static bool Delete(Copy b)
        {
            return CopyDA.Delete(b);
        }
        public static bool isContainCopyNumber(int copyNumber)
        {
            return CopyDA.isContainCopyNumber(copyNumber);
        }
        public static char getTypeOfCopyNumber(int copyNumber)
        {
            return CopyDA.getTypeOfCopyNumber(copyNumber);
        }
        public static int getBookNumber(int copyNumber)
        {
            return CopyDA.getBookNumber(copyNumber);
        }
        public static void setTypeOfCopyNumber(int copyNumber, char ch)
        {
            CopyDA.setTypeOfCopyNumber(copyNumber, ch);
        }
    }
}
