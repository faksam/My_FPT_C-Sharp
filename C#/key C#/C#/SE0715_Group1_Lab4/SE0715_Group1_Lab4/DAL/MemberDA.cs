using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using SE0715_Group1_Lab4.DTL;
using System.Configuration;


namespace SE0715_Group1_Lab4.DAL
{
    class MemberDA
    {
        public static DataSet SelectDS()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlDataAdapter da = new SqlDataAdapter("select * from Borrower", conn);
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

        public static bool Insert(Borrower b)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("Insert into Borrower(borrowerNumber, name, sex, address,telephone,email) " +
                "values(@borrowerNumber, @name, @sex, @address,@telephone,@email)", cn);
                cmd.Parameters.AddWithValue("@borrowerNumber", b.BorrowerNumber);
                cmd.Parameters.AddWithValue("@name", b.Name);
                cmd.Parameters.AddWithValue("@sex", b.Sex);
                cmd.Parameters.AddWithValue("@address", b.Address);
                cmd.Parameters.AddWithValue("@telephone", b.Telephone);
                cmd.Parameters.AddWithValue("@email", b.Email);

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

        public static bool Update(Borrower b)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("Update Borrower set name = @name, "
                + "sex = @sex, address = @address,telephone = @telephone,email = @email where borrowerNumber = @borrowerNumber", cn);
                cmd.Parameters.AddWithValue("@borrowerNumber", b.BorrowerNumber);
                cmd.Parameters.AddWithValue("@name", b.Name);
                cmd.Parameters.AddWithValue("@sex", b.Sex);
                cmd.Parameters.AddWithValue("@telephone", b.Telephone);
                cmd.Parameters.AddWithValue("@email", b.Email);
                cmd.Parameters.AddWithValue("@address", b.Address);

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

        public static bool Delete(Borrower b)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("Delete Borrower where borrowerNumber = @borrowerNumber", cn);
                cmd.Parameters.AddWithValue("@borrowerNumber", b.BorrowerNumber);

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

        public static int GetMaxBorrower()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlDataAdapter da = new SqlDataAdapter("SELECT MAX(borrowerNumber) FROM Borrower", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int Num = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                return Num;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static Borrower SelectByID(string s)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                string sql = "SELECT * FROM Borrower where borrowerNumber = " + s;
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Borrower br = new Borrower();
                br.BorrowerNumber = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                br.Name = ds.Tables[0].Rows[0][1].ToString();
                br.Sex = char.Parse(ds.Tables[0].Rows[0][2].ToString());
                br.Address = ds.Tables[0].Rows[0][3].ToString();
                br.Telephone = ds.Tables[0].Rows[0][4].ToString();
                br.Email = ds.Tables[0].Rows[0][5].ToString();
                return br;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Borrower();
            }
        }
    }
}
