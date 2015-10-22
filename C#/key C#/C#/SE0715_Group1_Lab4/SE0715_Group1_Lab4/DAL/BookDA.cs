using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SE0715_Group1_Lab4.DTL;
using System.Configuration;

namespace SE0715_Group1_Lab4.DAL
{
    class BookDA
    {
        public static DataSet SelectDS()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlDataAdapter da = new SqlDataAdapter("select * from Book", conn);
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

        public static DataSet SelectFilter(string s)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlDataAdapter da = new SqlDataAdapter("select * from Book where bookNumber = " + s, conn);
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

        public static Book SelectByID(string s)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                string sql = "SELECT * FROM Book where bookNumber = " + s;
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Book b = new Book();
                b.BookNumber = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                b.Title = ds.Tables[0].Rows[0][1].ToString();
                b.Authors = ds.Tables[0].Rows[0][2].ToString();
                b.Publisher = ds.Tables[0].Rows[0][3].ToString();
                return b;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Book();
            }
        }

        public static DataSet Filter(String s)
        {
            String cmd="Select * from Book where bookNumber = "+s;
            string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            SqlDataAdapter da=new SqlDataAdapter(cmd, conn);
            DataSet ds=new DataSet();
            da.Fill(ds);
            return ds;
        }

        public static bool Insert(Book b)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("Insert into Book(bookNumber, title, authors, publisher) " +
                "values(@bookNumber, @title, @authors, @publisher)", cn);
                cmd.Parameters.AddWithValue("@bookNumber", b.BookNumber);
                cmd.Parameters.AddWithValue("@title", b.Title);
                cmd.Parameters.AddWithValue("@authors", b.Authors);
                cmd.Parameters.AddWithValue("@publisher", b.Publisher);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

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
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("Update Book set title = @title, "
                + "authors = @authors, publisher = @publisher where bookNumber = @bookNumber", cn);
                cmd.Parameters.AddWithValue("@bookNumber", b.BookNumber);
                cmd.Parameters.AddWithValue("@title", b.Title);
                cmd.Parameters.AddWithValue("@authors", b.Authors);
                cmd.Parameters.AddWithValue("@publisher", b.Publisher);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool Delete(Book b)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("Delete Book where bookNumber = @bookNumber", cn);
                cmd.Parameters.AddWithValue("@bookNumber", b.BookNumber);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //public static void DeleteAllCopy(Book b) {
        //    try {
        //        SqlConnection cn = new SqlConnection("Data Source=TRUNGND\\SQL;Initial Catalog=Library;Integrated Security=True");
        //        SqlCommand cmd=new SqlCommand("Delete Copy where bookNumber = @bookNumber",cn);
        //        cmd.Parameters.AddWithValue("@bookNumber",b.BookNumber);

        //        cn.Open();
        //        cmd.ExecuteNonQuery();
        //        cn.Close();
        //    } catch(Exception ex) {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        public static bool DeleteAllCopy(Book b)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("Delete Copy where bookNumber = @bookNumber", cn);
                cmd.Parameters.AddWithValue("@bookNumber", b.BookNumber);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public static int GetBookNumberMax()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("Select Max(bookNumber) as bookNumberMax from Book", cn);

                cn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                int bookNumberMax = 0;
                if (rd.Read())
                    bookNumberMax = int.Parse(rd["bookNumberMax"].ToString());
                rd.Close();

                cn.Close();
                return bookNumberMax;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        
    }
}

