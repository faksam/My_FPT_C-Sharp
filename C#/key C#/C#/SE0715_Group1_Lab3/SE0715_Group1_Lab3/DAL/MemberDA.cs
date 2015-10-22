using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using SE0715_Group1_Lab3.DTL;


namespace SE0715_Group1_Lab3.DAL
{
    class MemberDA
    {
        public static DataSet SelectDS()
        {
            try
            {
                SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("select * from Borrower", cn);
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
                SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
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
                SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
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
                SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
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
    }
}
