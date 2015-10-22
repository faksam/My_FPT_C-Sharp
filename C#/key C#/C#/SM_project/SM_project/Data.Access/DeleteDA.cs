using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using SM_project.Class;

namespace SM_project.Data.Access
{
    class DeleteDA
    {
        static SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
        public static void DeleteProduct(ProductCL b)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Delete Products where ProductID = @ProductID", con);
                cmd.Parameters.AddWithValue("@ProductID", b.ProductID);

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

        public static void DeleteAllOrder(ProductCL b)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Delete OrderDetails where ProductID = @ProductID", con);
                cmd.Parameters.AddWithValue("@ProductID", b.ProductID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void DeleteCustomer(int a)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete Customers where CustomerID = @CustomerID", con);
                cmd.Parameters.AddWithValue("@CustomerID", a);

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

        public static void DeleteSupplier(int a)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete Suppliers where SupplierID = @SupplierID", con);
                cmd.Parameters.AddWithValue("@SupplierID", a);

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

        public static void DeleteChung(int a, string attribute, string table)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete " + table + " where " + attribute + " = @d", con);
                cmd.Parameters.AddWithValue("@d", a);

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

        public static void DeleteAllSup(int a)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("WITH R AS(SELECT ProductID FROM Products,Suppliers WHERE Suppliers.SupplierID = Products.SupplierID AND Suppliers.SupplierID = @d) DELETE OrderDetails WHERE OrderDetails.ProductID IN (SELECT ProductID FROM R)", con);
                cmd.Parameters.AddWithValue("@d", a);

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

        public static void DeleteAllOrder(int a)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("WITH R AS(SELECT Orders.OrderID FROM Customers,Orders WHERE Orders.CustomerID = Customers.CustomerID AND Customers.CustomerID = @d) DELETE OrderDetails WHERE OrderDetails.OrderID IN (SELECT OrderID FROM R)", con);
                cmd.Parameters.AddWithValue("@d", a);

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

        public static void DeleteAllEmp(int a)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("WITH R AS(SELECT Orders.OrderID FROM Employees,Orders WHERE Orders.EmployeeID = Employees.EmployeeID AND Employees.EmployeeID = @d) DELETE OrderDetails WHERE OrderDetails.OrderID IN (SELECT OrderID FROM R)", con);
                cmd.Parameters.AddWithValue("@d", a);

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
