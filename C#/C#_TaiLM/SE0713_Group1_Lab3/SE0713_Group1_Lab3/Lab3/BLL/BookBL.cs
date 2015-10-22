using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Lab3_Group1.DTL;
using Lab3_Group1.DAL;

namespace Lab3_Group1.BLL
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


        public static int borrowerNumberMax { get; set; }
    }
}
