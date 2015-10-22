using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Question1
{
    class CustomerDA
    {
        public static Customer Select(string customerID)
        {
            string strConn = "server=localhost;database=SampleExam; Integrated Security = true";
            SqlConnection cn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("select * from customers where CustomerID = @CustomerID" ,cn);
            cmd.Parameters.AddWithValue("@CustomerID",customerID);
            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read()) return null;
            Customer c = new Customer();
            c.CustomerID = customerID;
            c.CompanyName = dr["CompanyName"].ToString();
            c.ContactName = dr["ContactName"].ToString();
            c.ContactTitle = dr["ContactTitle"].ToString();
            c.Address = dr["Address"].ToString();
            c.Phone = dr["Phone"].ToString();
            c.Fax = dr["Fax"].ToString();

            dr.Close();
            cn.Close();
            return c;

        }


        public static bool Update(Customer c)
        {
            try
            {
                string strConn = "server=localhost;database=SampleExam; Integrated Security = true";
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("update customers set CompanyName = @CompanyName " +
                    ", ContactName=@ContactName,ContactTitle=@ContactTitle" +
                    ", Address = @Address, Phone = @Phone, Fax = @Fax" +
                    " where CustomerID = @CustomerID", cn);

                cmd.Parameters.AddWithValue("@CustomerID", c.CustomerID);
                cmd.Parameters.AddWithValue("@CompanyName", c.CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", c.ContactName);
                cmd.Parameters.AddWithValue("@ContactTitle", c.ContactTitle);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Phone", c.Phone);
                cmd.Parameters.AddWithValue("@Fax", c.Fax);

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
