using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Lab4_Group3.DTL;
using System.Configuration;
namespace Lab4_Group3.DAL


{
    public class ReservationDA
    {

        public static DataSet SelectDS()
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlDataAdapter da = new SqlDataAdapter("select * from CirculatedCopy", strConn);
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

        public static bool Insert(Reservation re)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Insert into Reservation( borrowerNumber, bookNumber, date, status) " +
                "values( @borrowerNumber, @bookNumber, @date, @status)", cn);
                //cmd.Parameters.AddWithValue("@ID", re.Id);
                cmd.Parameters.AddWithValue("@borrowerNumber", re.BorrowerNumber);
                cmd.Parameters.AddWithValue("@bookNumber", re.BookNumber);
                cmd.Parameters.AddWithValue("@date", re.Date);
                cmd.Parameters.AddWithValue("@status", re.Status);

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

        public static bool Update(Reservation re)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Update Reservation set borrowerNumber = @borrowerNumber, "
                + "bookNumber = @bookNumber, date = @date, price= @price where ID = @ID", cn);
                cmd.Parameters.AddWithValue("@ID", re.Id);
                cmd.Parameters.AddWithValue("@borrowerNumber", re.BorrowerNumber);
                cmd.Parameters.AddWithValue("@bookNumber", re.BookNumber);
                cmd.Parameters.AddWithValue("@date", re.Date);
                cmd.Parameters.AddWithValue("@status", re.Status);

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

        public static bool Delete(Reservation re)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Delete Reservation where ID = @ID", cn);
                cmd.Parameters.AddWithValue("@ID", re.Id);

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

        //
        public static int GetIDMax()
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Select Max(ID) as IDMax from Reservation", cn);

                cn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                int IDMax = 0;
                if (rd.Read())
                    IDMax = int.Parse(rd["IDMax"].ToString());
                rd.Close();

                cn.Close();
                return IDMax;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        public static bool updateStatus(int borrowerNumber,int bookNumber, char ch)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Update Reservation set status = @status"
                + " where borrowerNumber = @borrowerNumber and bookNumber = @bookNumber", cn);
                cmd.Parameters.AddWithValue("@borrowerNumber", borrowerNumber);
                cmd.Parameters.AddWithValue("@bookNumber", bookNumber);
                cmd.Parameters.AddWithValue("@status", ch);
              //  cmd.Parameters.Add(new SqlParameter("@borrowerNumber", borrowerNumber));
              //  cmd.Parameters.Add(new SqlParameter("@bookNumber", bookNumber));
               // cmd.Parameters.Add(new SqlParameter("@type", ch));

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

    }
}