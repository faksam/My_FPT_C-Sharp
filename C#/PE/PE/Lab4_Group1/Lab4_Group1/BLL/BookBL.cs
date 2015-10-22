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
    public class BookBL
    {
        private static int bookNumberMax;

        public BookBL()
        {
        }
        public static int BookNumberMax
        {
            get { return bookNumberMax; }
            set { bookNumberMax = value; }
        }

        public static DataSet SelectDS()
        {
            DataSet ds = BookDA.SelectDS();
            if (ds == null) bookNumberMax = 0;
            else bookNumberMax = BookDA.getBookNumberMax();
            return ds;
        }

        public static Book GetBook(int bookNumber)
        {
            return BookDA.GetBook(bookNumber);
        }


        public static List<Book> SelectList()
        {
            DataSet ds = BookDA.SelectDS();
            if (ds == null) return null;
            DataTable dt = ds.Tables[0];
            bookNumberMax = getBookNumberMax();
            List<Book> lb = new List<Book>();
            foreach (DataRow dr in dt.Rows)
            {
                lb.Add(new Book((int)dr["bookNumber"], (String)dr["title"], (String)dr["authors"], (String)dr["publisher"]));
            }
            return lb;
        }

        public static int getBookNumberMax()
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Select Max(bookNumber) as bookNumberMax from Book", conn);

                conn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                int bookNumberMax = 0;
                if (rd.Read())
                    bookNumberMax = int.Parse(rd["bookNumberMax"].ToString());
                rd.Close();

                conn.Close();
                return bookNumberMax;
            }
            catch (Exception ex)
            {
               
                return 0;
            }
        }
        public static int countBook()
        {
            return BookDA.countBook();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static bool Insert(Book b)
        {
            return BookDA.Insert(b);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static bool Update(Book b)
        {
            return BookDA.Update(b);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Book b)
        {
            return BookDA.Delete(b);
        }

    }
}