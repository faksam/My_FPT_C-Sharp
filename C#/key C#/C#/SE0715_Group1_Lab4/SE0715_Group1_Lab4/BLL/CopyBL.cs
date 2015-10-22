using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SE0715_Group1_Lab4.DTL;
using SE0715_Group1_Lab4.DAL;
using System.Data;

namespace SE0715_Group1_Lab4.BLL
{
    class CopyBL
    {
        public static DataSet SelectDS()
        {
            return CopyDA.SelectDS();
        }
        public static bool Insert(Copy c)
        {
            return CopyDA.Insert(c);
        }
        public static bool Update(Copy c)
        {
            return CopyDA.Update(c);
        }
        public static bool Delete(Copy c)
        {
            return CopyDA.Delete(c);
        }
        public static int getSequenceMax(String s)
        {
            return CopyDA.getSequenceMax(s);
        }
        public static int GetCopyNumberMax()
        {
            return CopyDA.GetCopyNumberMax();
        }
        public static Copy SelectByID(string s)
        {
            return CopyDA.SelectByID(s);
        }
    }
}
