using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SM_project.Class;
using System.Windows.Forms;

namespace SM_project.Data.Access
{
    class InsertDA
    {
        static SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");

        public static void InsertOrder(OrderCL or)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT [dbo].[Orders] ON insert into Orders(OrderID,CustomerID,EmployeeID,OrderDate,Discount) "
                    + "values (@OrderID,@CustomerID,@EmployeeID,getDate(),@Discount)" +
                    "SET IDENTITY_INSERT [dbo].[Orders] OFF", con);
                cmd.Parameters.AddWithValue("@OrderID", or.OrderID);
                cmd.Parameters.AddWithValue("@CustomerID", or.CustomerID);
                cmd.Parameters.AddWithValue("@EmployeeID", or.EmployeeID);
                cmd.Parameters.AddWithValue("@Discount", or.Discount);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void InsertOrderDetail(OrderDetailCL orDe)
        {
            try
            {
            SqlCommand cmd = new SqlCommand("insert into OrderDetails(OrderID,ProductID,Quantity,UnitPrice) "
                    +"values (@OrderID,@ProductID,@Quantity,@UnitPrice)", con);
            cmd.Parameters.AddWithValue("@OrderID", orDe.OrderID);
            cmd.Parameters.AddWithValue("@ProductID", orDe.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", orDe.Quantity);
            cmd.Parameters.AddWithValue("@UnitPrice", orDe.Price);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void insertProduct(ProductCL a)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT Products ON Insert into Products(ProductID,ProductName,SupplierID,UnitPrice) " +
                "values(@ProductID,@ProductName,@SupplierID,@UnitPrice)", con);
                cmd.Parameters.AddWithValue("@ProductID", a.ProductID);
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
        public static void insertCustomer(CustomerCL a)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT Customers ON Insert into Customers" +
                    "(CustomerID,LastName,FirstName,CompanyName,Phone,Address,Discount) " +
                    "values(@CustomerID,@LastName,@FirstName,@CompanyName,@Phone,@Address,@Discount)", con);
                cmd.Parameters.AddWithValue("@CustomerID", a.CustomerID);
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

        public static void insertSupplier(SupplierCL a)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT Suppliers ON Insert into Suppliers" +
                    "(SupplierID,CompanyName,ContactName,Address,Phone,Fax) " +
                    "values(@SupplierID,@CompanyName,@ContactName,@Address,@Phone,@Fax)", con);
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
