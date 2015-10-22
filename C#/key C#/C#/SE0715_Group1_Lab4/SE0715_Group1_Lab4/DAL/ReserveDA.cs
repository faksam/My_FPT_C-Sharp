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
    class ReserveDA
    {
        public static DataSet SelectDS()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlDataAdapter da = new SqlDataAdapter("select * from Reservation", conn);
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
        public static DataSet selectTableReservation(int borrowernum)
        {
            string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(conn);
            string cmd = "select * from Reservation where borrowerNumber = " + borrowernum + "AND status != 'A'";
            SqlDataAdapter da = new SqlDataAdapter(cmd, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public static bool Insert(Reservation b)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("Insert into Reservation(borrowerNumber,bookNumber,date,status) " +
                "values(@borrowerNumber,@bookNumber,@date,@status)", cn);
                cmd.Parameters.AddWithValue("@borrowerNumber", b.BorrowerNumber);
                cmd.Parameters.AddWithValue("@bookNumber", b.BookNumber);
                cmd.Parameters.AddWithValue("@date", b.Date);
                cmd.Parameters.AddWithValue("@status", b.Status);

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
                SqlCommand cmd = new SqlCommand("Select Max(ID) as IDMax from Reservation", cn);

                cn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                int bookNumberMax = 0;
                if (rd.Read())
                    bookNumberMax = int.Parse(rd["IDMax"].ToString());
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
