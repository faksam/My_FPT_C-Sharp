using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SM_project.Class;

namespace SM_project.Data.Access
{
    class EmployeeDA
    {
        static SqlConnection cn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
        
        public static DataSet SelectDS()
        {
            try
            {
               SqlDataAdapter da = new SqlDataAdapter("select EmployeeID, FirstName, LastName, Phone, Address, Title from Employees", cn);
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


        public static bool Insert(EmployeeCL b)
        {
            try
            {
                 SqlCommand cmd = new SqlCommand("Insert into Employees (LastName, FirstName, Phone, Address, Title) " +
                "values (@last, @first, @phone, @add, @tit)", cn);
                cmd.Parameters.AddWithValue("@last", b.LastName);
                cmd.Parameters.AddWithValue("@first", b.FirstName);
                cmd.Parameters.AddWithValue("@phone", b.Phone);
                cmd.Parameters.AddWithValue("@add", b.Address);
                cmd.Parameters.AddWithValue("@tit", b.Title);

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

        public static bool Delete(EmployeeCL e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete Employees where EmployeeID = @empID", cn);
                cmd.Parameters.AddWithValue("@empID", e.EmployeeID);

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

        public static bool Update(EmployeeCL b)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Update Employees set LastName = @last, FirstName = @first, Phone = @phone, Address = @add, Title = @tit where EmployeeID = @empID", cn);
                cmd.Parameters.AddWithValue("@last", b.LastName);
                cmd.Parameters.AddWithValue("@first", b.FirstName);
                cmd.Parameters.AddWithValue("@phone", b.Phone);
                cmd.Parameters.AddWithValue("@add", b.Address);
                cmd.Parameters.AddWithValue("@tit", b.Title);
                cmd.Parameters.AddWithValue("@empID", b.EmployeeID);

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
