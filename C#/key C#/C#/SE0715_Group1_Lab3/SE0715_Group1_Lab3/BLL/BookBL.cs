
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SE0715_Group1_Lab3.DTL;
using SE0715_Group1_Lab3.DAL;

namespace SE0715_Group1_Lab3.BLL
{
    class BookBL
    {
        public static int bookNumberMax;

        public static DataSet SelectDS()
        {
            SetBookNumberMax();
            return BookDA.SelectDS();
        }

        public static void SetBookNumberMax()
        {
            bookNumberMax = BookDA.GetBookNumberMax();
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

    }
}
