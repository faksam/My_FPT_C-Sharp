using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using Lab4_Group3.DAL;
using Lab4_Group3.DTL;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Group3.BLL
{
    public class CirculatedCopyBL
    {

        public static int IDMax;
        public static DataSet SelectDS()
        {
            SetIDNumberMax();
            return CirculatedCopyDA.SelectDS();
        }
        public static void SetIDNumberMax()
        {
            IDMax = CirculatedCopyDA.GetIDNumberMax();
        }


        public static bool Insert(CirculatedCopy cir)
        {
            return CirculatedCopyDA.Insert(cir);
        }

        public static bool Update(CirculatedCopy cir)
        {
            return CirculatedCopyDA.Update(cir);
        }

        public static bool Delete(CirculatedCopy cir)
        {
            return CirculatedCopyDA.Delete(cir);
        }
    }
}