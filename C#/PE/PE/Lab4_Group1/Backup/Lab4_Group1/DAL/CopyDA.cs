using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Lab4_Group3.DTL;

namespace Lab4_Group3.DAL
{
   public class CopyDA
    {
        public static DataSet SelectDS()
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlDataAdapter da = new SqlDataAdapter("select * from Copy", strConn);
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

        public static DataSet SelectDS(int bookNumber)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlDataAdapter da = new SqlDataAdapter("select * from Copy where bookNumber = " + bookNumber.ToString(), strConn);
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

        public static bool Insert(Copy c)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("insert into copy(copyNumber, bookNumber, sequenceNumber, type, price)" +
                    "values (@copyNumber, @bookNumber, @sequenceNumber, @type, @price)", conn);

                cmd.Parameters.Add(new SqlParameter("@bookNumber", c.BookNumber));
                cmd.Parameters.Add(new SqlParameter("@copyNumber", c.CopyNumber));
                cmd.Parameters.Add(new SqlParameter("@sequenceNumber", c.SequenceNumber));
                cmd.Parameters.Add(new SqlParameter("@type", c.Type));
                cmd.Parameters.Add(new SqlParameter("@price", c.Price));
                
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

        public static bool Update(Copy c)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("update Copy set bookNumber = @bookNumber"
                        + ", sequenceNumber=@sequenceNumber, type = @type, price = @price where copyNumber = @copyNumber", conn);
                
                cmd.Parameters.Add(new SqlParameter("@copyNumber", c.CopyNumber));
                cmd.Parameters.Add(new SqlParameter("@bookNumber", c.BookNumber));
                cmd.Parameters.Add(new SqlParameter("@sequenceNumber", c.SequenceNumber));
                cmd.Parameters.Add(new SqlParameter("@type", c.Type));
                cmd.Parameters.Add(new SqlParameter("@price", c.Price));
                
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

        public static Boolean Delete(Copy c)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("delete Copy where copyNumber = @copyNumber", conn);

                cmd.Parameters.Add(new SqlParameter("@copyNumber", c.CopyNumber));

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
        public static Boolean Delete(int copyNumber)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("delete Copy where copyNumber = @copyNumber", conn);

                cmd.Parameters.Add(new SqlParameter("@copyNumber", copyNumber));

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


        public static Copy GetCopy(int copyNumber)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("select * from Copy where copyNumber = @copyNumber", cn);
                cmd.Parameters.AddWithValue("@copyNumber", copyNumber);
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    Copy b = new Copy(int.Parse(rd["bookNumber"].ToString()), int.Parse(rd["copyNumber"].ToString()), int.Parse(rd["sequenceNumber"].ToString()),
                        rd["type"].ToString()[0], double.Parse(rd["price"].ToString()));
                    rd.Close();
                    cn.Close();
                    return b;
                }
                else
                {
                    rd.Close();
                    cn.Close();

                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
       //update Type
        public static bool updateType(int x, char ch)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Update Copy set type = @type "
                + " where copyNumber = @copyNumber", cn);
                cmd.Parameters.AddWithValue("@copyNumber", x);

                cmd.Parameters.AddWithValue("@type", ch);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       //get copy Number MAX
        public static int getBookNumberMax()
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Select Max(copyNumber) as copyNumberMax from Copy", conn);

                conn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                int copyNumberMax = 0;
                if (rd.Read())
                    copyNumberMax = int.Parse(rd["copyNumberMax"].ToString());
                rd.Close();

                conn.Close();
                return copyNumberMax;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
  
    }
}
