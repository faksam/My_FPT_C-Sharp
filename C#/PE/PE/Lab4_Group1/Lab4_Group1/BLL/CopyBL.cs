using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using Lab4_Group3.DAL;
using Lab4_Group3.DTL;

namespace Lab4_Group3.BLL
{
    public class CopyBL
    {
        private static int copyNumberMax;

        public static int CopyNumberMax
        {
            get { return copyNumberMax; }
            set { copyNumberMax = value; }
        }

        private static int sequenceNumberMax;

        public static int SequenceNumberMax
        {
            get { return sequenceNumberMax; }
            set { sequenceNumberMax = value; }
        }
        public static int getCopyNumberMAX()
        {
            return CopyDA.getBookNumberMax();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static DataSet SelectDS()
        {
            DataSet ds = CopyDA.SelectDS();
            if (ds == null) copyNumberMax = 0;
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0) copyNumberMax = 0;
            else copyNumberMax = CopyDA.getBookNumberMax();
            return ds;
        }

        public static Copy GetCopy(int copyNumber)
        {
            return CopyDA.GetCopy(copyNumber);

        }

        //--------------
        public static bool UpdateType(int x, char ch)
        {
            return CopyDA.updateType(x, ch);
        }

        public static DataSet SelectDS(int bookNumber)
        {
            DataSet ds = CopyDA.SelectDS();
            if (ds == null) { copyNumberMax = 0; sequenceNumberMax = 0; return null; }
            DataTable dt = ds.Tables[0];
  
            DataRow[] result = dt.Select("", "copyNumber");
            if (result.Count() == 0) copyNumberMax = 0;
            else copyNumberMax = int.Parse(result[result.Count()-1]["copyNumber"].ToString());
                
            result = dt.Select("bookNumber = " + bookNumber.ToString(), "sequenceNumber");
                
            if(result.Count() == 0) sequenceNumberMax = 0;
            else
                    sequenceNumberMax = int.Parse(result[result.Count()-1]["sequenceNumber"].ToString()); 
            
            return ds;
        }


        public static List<Copy> SelectList()
        {
            DataSet ds = CopyDA.SelectDS();
            if (ds == null) return null;
            DataTable dt = ds.Tables[0];
            copyNumberMax = CopyDA.getBookNumberMax();
            List<Copy> lc = new List<Copy>();
            foreach (DataRow dr in dt.Rows)
            {
                lc.Add(new Copy((int)dr["bookNumber"], (int)dr["copyNumber"], (int)dr["sequenceNumber"], (Char)dr["type"], (Double)dr["price"]));
            }
            return lc;
        }


        [DataObjectMethod(DataObjectMethodType.Insert, true)]

        public static bool Insert(Copy c)
        {
            return CopyDA.Insert(c);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]

        public static bool Update(Copy c)
        {
            return CopyDA.Update(c);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]

        public static bool Delete(int copyNumber)
        {
            return CopyDA.Delete(copyNumber);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]

        public static bool Delete(Copy c)
        {
            return CopyDA.Delete(c.CopyNumber);
        }
    }
}