using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Lab4_Group1.DTL;
using Lab4_Group1.DAL;


namespace Lab4_Group1.BLL
{
    class ReturnBL
    {
        //public static int bookNumberMax;

        public static DataSet SelectDS()
        {
            return CirculatedCopyDA.SelectDS();
        }

        public static bool Insert(CirculatedCopy b)
        {
            return CirculatedCopyDA.Insert(b);
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
