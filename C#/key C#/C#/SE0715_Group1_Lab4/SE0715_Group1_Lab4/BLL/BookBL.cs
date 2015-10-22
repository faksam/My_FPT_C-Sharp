
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SE0715_Group1_Lab4.DTL;
using SE0715_Group1_Lab4.DAL;

namespace SE0715_Group1_Lab4.BLL
{
    class BookBL
    {
        //public static int bookNumberMax();

        public static DataSet SelectDS()
        {
            //SetBookNumberMax();
            return BookDA.SelectDS();
        }

        public static DataSet SelectFilter(string s)
        {
            return BookDA.SelectFilter(s);
        }

        public static Book SelectByID(string s)
        {
            return BookDA.SelectByID(s);
        }

        public static int GetBookNumberMax()
        {
             return BookDA.GetBookNumberMax();
        }

        public static bool Insert(Book b)
        {
            return BookDA.Insert(b);
        }

        public static bool Update(Book b)
        {
            return BookDA.Update(b);
        }

        public static bool Delete(Book b)
        {
            return BookDA.Delete(b);
        }

        public static bool DeleteAllCopy(Book b)
        {
            return BookDA.DeleteAllCopy(b);
        }
    }
}
