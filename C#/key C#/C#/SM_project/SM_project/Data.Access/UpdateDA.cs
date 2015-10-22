using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SM_project.Class;
using System.Windows.Forms;

namespace SM_project.Data.Access
{
    class UpdateDA
    {
        static SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");

        public static void productUpdate(ProductCL a)
        {
            try
            {
                string cm = "Update Products set ProductName = @ProductName,SupplierID = @SupplierID,UnitPrice = @UnitPrice  " + "where ProductID = " + a.ProductID;


                SqlCommand cmd = new SqlCommand(cm, con);
                cmd.Parameters.AddWithValue("@ProductName", a.ProductName);
                cmd.Parameters.AddWithValue("@SupplierID", a.SupplierId);
                cmd.Parameters.AddWithValue("@UnitPrice", a.Price);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        public static void CustomerUpdate(CustomerCL a)
        {
            try
            {
                string cm = "Update Customers set LastName = @LastName,FirstName = @FirstName,CompanyName = @CompanyName, Phone=@Phone,Address=@Address,Discount=@Discount " + "where CustomerID = " + a.CustomerID;

                SqlCommand cmd = new SqlCommand(cm, con);
                cmd.Parameters.AddWithValue("@LastName", a.Lastname);
                cmd.Parameters.AddWithValue("@FirstName", a.Firstname);
                cmd.Parameters.AddWithValue("@CompanyName", a.Companyname);
                cmd.Parameters.AddWithValue("@Phone", a.Phone);
                cmd.Parameters.AddWithValue("@Address", a.Address);
                cmd.Parameters.AddWithValue("@Discount", a.Discount);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public static void updatePassword(string acc,string newPass)
        {
            try
            {
                string cm = "update Accounts set Password = '"+newPass+"' where Username = '"+acc+"'";

                SqlCommand cmd = new SqlCommand(cm, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public static void SupplierUpdate(SupplierCL a)
        {
            try
            {
                string cm = "Update Suppliers set CompanyName = @CompanyName,ContactName = @ContactName, Address=@Address,Phone=@Phone,Fax=@Fax " + "where SupplierID = " + a.SupplierID;
                SqlCommand cmd = new SqlCommand(cm, con);

                cmd.Parameters.AddWithValue("@SupplierID", a.SupplierID);
                cmd.Parameters.AddWithValue("@CompanyName", a.ComName);
                cmd.Parameters.AddWithValue("@ContactName", a.ConName);
                cmd.Parameters.AddWithValue("@Address", a.Address);
                cmd.Parameters.AddWithValue("@Phone", a.Phone);
                cmd.Parameters.AddWithValue("@Fax", a.Fax);

                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
