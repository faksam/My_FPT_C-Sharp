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
    public class CirculatedCopyDA
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

       

        
        //======================================
        public static bool Insert(CirculatedCopy cir)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Insert into CirculatedCopy(copyNumber,borrowerNumber,borrowedDate,dueDate) " +
                "values(@copyNumber,@borrowerNumber,@borrowedDate,@dueDate)", cn);
                //cmd.Parameters.AddWithValue("@ID", cir.Id);
                cmd.Parameters.AddWithValue("@copyNumber", cir.CopyNumber);
                cmd.Parameters.AddWithValue("@borrowerNumber", cir.BorrowerNumber);
                cmd.Parameters.AddWithValue("@borrowedDate", cir.BorrowedDate);
                cmd.Parameters.AddWithValue("@dueDate", cir.DueDate);
                //cmd.Parameters.AddWithValue("@returnDate", cir.ReturnedDate);
                //cmd.Parameters.AddWithValue("@fineAmount", cir.FineAmount);
                //,returnedDate,fineAmount    ,@returnedDate,@fineAmount
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

        //==========================

        public static bool Update(CirculatedCopy cir)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Update CirculatedCopy set copyNumber = @copyNumber, borrowerNumber = @borrowerNumber, borrowedDate = @borrowedDate "
                + "dueDate = @dueDate, returnDate = @returnDate, fineAmount = @fineAmount where ID = @ID", cn);
                cmd.Parameters.AddWithValue("@ID", cir.Id);
                cmd.Parameters.AddWithValue("@copyNumber", cir.CopyNumber);
                cmd.Parameters.AddWithValue("@borrowerNumber", cir.BorrowerNumber);
                cmd.Parameters.AddWithValue("@borrowedDate", cir.BorrowedDate);
                cmd.Parameters.AddWithValue("@dueDate", cir.DueDate);
                cmd.Parameters.AddWithValue("@returnDate", cir.ReturnedDate);
                cmd.Parameters.AddWithValue("@fineAmount", cir.FineAmount);

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
        //==============================
        public static bool Delete(CirculatedCopy c)
        {
            try
            {
                 string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Delete CirculatedCopy where ID = @ID", cn);
                cmd.Parameters.AddWithValue("@ID", c.Id);

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
        //=============================================


        //bo?
        public static int GetIDNumberMax()
        {
            
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Select Max(ID) as IDMax from CirculatedCopy", cn);

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
    }
                
    }

    