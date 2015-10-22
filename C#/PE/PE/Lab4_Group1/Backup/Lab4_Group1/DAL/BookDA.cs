using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using Lab4_Group3.DTL;

namespace Lab4_Group3.DAL
{
    
    public class BookDA
    {

        public static DataSet SelectDS()
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlDataAdapter da = new SqlDataAdapter("select * from Book", strConn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            
        }

        public static Book GetBook(int bookNumber)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("select * from Book where bookNumber = @bookNumber", cn);
                cmd.Parameters.AddWithValue("@bookNumber", bookNumber);
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    Book b = new Book(int.Parse(rd["bookNumber"].ToString()), rd["title"].ToString(), rd["authors"].ToString(), rd["publisher"].ToString());
                    return b;
                }
                else return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        
        }

        public static bool Insert(Book b)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("insert into book(bookNumber, title, authors, publisher)" +
                    "values (@bookNumber, @title, @authors, @publisher)", conn);
               
                cmd.Parameters.Add(new SqlParameter("@bookNumber", b.BookNumber));
                cmd.Parameters.Add(new SqlParameter("@title", b.Title));
                cmd.Parameters.Add(new SqlParameter("@authors", b.Authors));
                cmd.Parameters.Add(new SqlParameter("@publisher", b.Publisher));
      
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public static bool Update(Book b)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("update Book set title=@title, authors = @authors, publisher = @publisher where bookNumber=@bookNumber", conn);
                
                cmd.Parameters.Add(new SqlParameter("@bookNumber", b.BookNumber));
                cmd.Parameters.Add(new SqlParameter("@title", b.Title));

                cmd.Parameters.Add(new SqlParameter("@authors", b.Authors));
                cmd.Parameters.Add(new SqlParameter("@publisher", b.Publisher));
 
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        
        public static Boolean Delete(Book b)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("delete Book where bookNumber=@bookNumber", conn);
               
                cmd.Parameters.Add(new SqlParameter("@bookNumber", b.BookNumber));
  
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

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
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int countBook()
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Select count(*) as Count from Book", conn);

                conn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                int num = 0;
                if (rd.Read())
                    num = int.Parse(rd["Count"].ToString());
                rd.Close();

                conn.Close();
                return num;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
                 
    }
}
