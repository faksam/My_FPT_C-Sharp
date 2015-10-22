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
    public class BorrowerDA
    {
        public static DataSet SelectDS()
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString2"].ConnectionString;
                SqlDataAdapter da = new SqlDataAdapter("select * from Borrower", strConn);
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

        public static Borrower gerBorrower(int borrowerNumber)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString2"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("select * from Borrower where borrowerNumber = @borrowerNumber", cn);
                cmd.Parameters.AddWithValue("@borrowerNumber", borrowerNumber);
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    Borrower b = new Borrower(int.Parse(rd["borrowerNumber"].ToString()), rd["name"].ToString(), rd["sex"].ToString(), rd["address"].ToString(), rd["telephone"].ToString(), rd["email"].ToString());
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

        public static bool Insert(Borrower b)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString2"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Insert into Borrower(borrowerNumber, name,sex,address, telephone, email) " +
                 "values(@borrowerNumber, @name, @sex, @address,@telephone,@email)", conn);

                cmd.Parameters.Add(new SqlParameter("@BorrowerNumber", b.BorrowerNumber));
                cmd.Parameters.Add(new SqlParameter("@name", b.Name));
                cmd.Parameters.Add(new SqlParameter("@sex", b.Sex));
                cmd.Parameters.Add(new SqlParameter("@Address", b.Address));
                cmd.Parameters.Add(new SqlParameter("@Telephone", b.Telephone));
                cmd.Parameters.Add(new SqlParameter("@Email", b.Email));

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

        public static bool Update(Borrower b)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString2"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Update Borrower set name = @name ,"
                 + "sex = @sex ,address = @address, telephone = @telephone, email = @email where borrowerNumber = @borrowerNumber", conn);

                cmd.Parameters.Add(new SqlParameter("@BorrowerNumber", b.BorrowerNumber));
                cmd.Parameters.Add(new SqlParameter("@name", b.Name));
                cmd.Parameters.Add(new SqlParameter("@sex", b.Sex));
                cmd.Parameters.Add(new SqlParameter("@Address", b.Address));
                cmd.Parameters.Add(new SqlParameter("@Telephone", b.Telephone));
                cmd.Parameters.Add(new SqlParameter("@Email", b.Email));

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

        public static Boolean Delete(Borrower b)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString2"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("delete Borrower where borrowerNumber=@borrowerNumber", conn);

                cmd.Parameters.Add(new SqlParameter("@borrowerNumber", b.BorrowerNumber));

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

        public static int getBorrowerMax()
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString2"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Select Max(borrowerNumber) as borrowerNumberMax from Borrower", conn);

                conn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                int borrowerNumberMax = 0;
                if (rd.Read())
                    borrowerNumberMax = int.Parse(rd["borrowerNumberMax"].ToString());
                rd.Close();

                conn.Close();
                return borrowerNumberMax;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        //count Member
        public static int countBorrower()
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString2"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Select count(*) as Count from Borrower", conn);

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