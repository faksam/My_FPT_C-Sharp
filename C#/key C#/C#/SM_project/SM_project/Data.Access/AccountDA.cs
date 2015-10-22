using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SM_project.Class;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace SM_project.Data.Access
{
    class AccountDA
    {
        static SqlConnection cn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
        public static bool Insert(AccountCL b)
        {
            try
            {
                
                SqlCommand cmd = new SqlCommand("Insert into Accounts(Username, Password, EmployeeID) " +
                "values(@user, @pass, @empID)", cn);
                cmd.Parameters.AddWithValue("@user", b.Username);
                cmd.Parameters.AddWithValue("@pass", b.Password);
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

        public static bool Delete(AccountCL b)
        {
            try
            {
                
                SqlCommand cmd = new SqlCommand("Delete Accounts where EmployeeID = @empID", cn);
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


        public static bool checkAcc(String user)
        {
            string cmd = "select Username from Accounts where Username = '" + user + "'";
            
            SqlDataAdapter da = new SqlDataAdapter(cmd, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }
    }
}
