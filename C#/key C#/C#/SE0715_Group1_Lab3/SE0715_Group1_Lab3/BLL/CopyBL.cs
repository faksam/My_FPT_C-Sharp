using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SE0715_Group1_Lab3.DTL;
using SE0715_Group1_Lab3.DAL;
using System.Data;

namespace SE0715_Group1_Lab3.BLL
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
    }
}
