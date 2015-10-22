using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3_Group1.DTL;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab3_Group1.DAL
{
    class ReservationDA
    {
        public static DataSet SelectDS()
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source = KHJ; Initial Catalog = Library;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("select * from Reservation", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static bool Insert(Reservation c)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Insert into Reservation(borrowerNumber, bookNumber, date, status)"
                    + "values(@borrowerNumber, @bookNumber, @date, @status)", cn);
                cmd.Parameters.AddWithValue("@borrowerNumber", c.BorrowerNumber);
                cmd.Parameters.AddWithValue("@bookNumber", c.BookNumber);
                cmd.Parameters.AddWithValue("@date", c.Date);
                cmd.Parameters.AddWithValue("@status", c.Status);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool Update(Reservation c)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Update Reservation set borrowerNumber = @borrowerNumber, "
                + "bookNumber = @bookNumber, date = @date, status=@status where id = @id", cn);
                cmd.Parameters.AddWithValue("@borrowerNumber", c.BorrowerNumber);
                cmd.Parameters.AddWithValue("@bookNumber", c.BookNumber);
                cmd.Parameters.AddWithValue("@date", c.Date);
                cmd.Parameters.AddWithValue("@status", c.Status);
                cmd.Parameters.AddWithValue("@id", c.Id);


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

        public static bool Delete(Reservation c)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Delete Reservation where id = @id", cn);
                cmd.Parameters.AddWithValue("@id", c.Id);

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

        public static string GetMemberName(int k)// return name of member that has ID k
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                string str = "Select name as Member from Borrower where borrowerNumber= " + k;
                SqlCommand cmd = new SqlCommand(str, cn);
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                string s = "";
                if (rd.Read())
                {
                    s = rd["Member"].ToString();
                    cn.Close();
                    return s;
                }

                else { cn.Close(); return null; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        public static bool isTheFirstReservater(int brNumber, int bookNumber)
        {
            SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
            string str = "SELECT TOP 1 borrowerNumber as memberCode FROM Reservation WHERE bookNumber=" + bookNumber + "and status='R'";
            SqlCommand cmd = new SqlCommand(str, cn);
            cn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                if (int.Parse(rd["memberCode"].ToString()) == brNumber)
                {
                    return true;
                }
                else return false;
            }
            else return true;
        }
        public static void setStatusOfReservation(int brNumber, int bookNumber, char ch)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Update Reservation set status = @status where borrowerNumber=@brNumber and bookNumber=@bkNumber", cn);
                cmd.Parameters.AddWithValue("@bkNumber", bookNumber);
                cmd.Parameters.AddWithValue("@brNumber", brNumber);
                cmd.Parameters.AddWithValue("@status", ch);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
