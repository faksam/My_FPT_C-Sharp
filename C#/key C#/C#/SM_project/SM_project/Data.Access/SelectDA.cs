using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using SM_project.Class;


namespace SM_project.Data.Access
{
    class SelectDA
    {
        static SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");

        public static LoginCL getUser(string username)
        {
            LoginCL login = null;
            try
            {
                SqlCommand cmd = new SqlCommand("select Accounts.Username,Accounts.Password,Employees.LastName,Employees.Title from Accounts,Employees where Accounts.EmployeeID = Employees.EmployeeID and Username = '" + username + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    login = null;
                }
                else
                {
                    while (dr.Read())
                    {
                        string account = dr[0].ToString();
                        string pass = dr[1].ToString();
                        string last = dr[2].ToString();
                        string title = dr[3].ToString();
                        login = new LoginCL(account, pass, last, title);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return login;
        }

        public static DataSet SelectDS(string command)
        {
            SqlDataAdapter da = new SqlDataAdapter(command, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public static int GetMax(string attribute, string table)
        {
            int max = 0;
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select Max(" + attribute + ")from " + table, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    try
                    {
                        max = int.Parse(dr[0].ToString());
                    }
                    catch (Exception)
                    {
                        max = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return max;
        }

        public static List<ProductCL> getAllProductSell()
        {
            List<ProductCL> ware = new List<ProductCL>();

            try
            {
                SqlCommand cmd = new SqlCommand("select Products.ProductID,Products.ProductName,Suppliers.CompanyName,Products.UnitPrice from Products, Suppliers where Products.SupplierID = Suppliers.SupplierID", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    ware = null;
                }
                else
                {
                    while (dr.Read())
                    {
                        int id = int.Parse(dr[0].ToString());
                        string name = dr[1].ToString();
                        string supName = dr[2].ToString();
                        double price = double.Parse(dr[3].ToString());
                        ProductCL pro = new ProductCL(id, name, supName, price);
                        ware.Add(pro);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ware;
        }

        public static int getEmpID(string acc)
        {
            int ID = 0;
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select Employees.EmployeeID from Employees,Accounts where Employees.EmployeeID = Accounts.EmployeeID and Accounts.Username = '" + acc + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    try
                    {
                        ID = int.Parse(dr[0].ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ID;
        }

        public static int getDiscount(int empId)
        {
            int dis = 0;
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select Discount from Customers where CustomerID = " + empId, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    try
                    {
                        dis = int.Parse(dr[0].ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dis;
        }

        public static bool isCustomer(int cus)
        {
            bool isCus = false;
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select * from Customers where CustomerID = " + cus, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    isCus = true;
                }
                else
                {
                    isCus = false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return isCus;
        }

        public static List<ProductCL> getAllProduct()
        {
            List<ProductCL> ware = null;

            try
            {
                SqlCommand cmd = new SqlCommand("select Products.ProductID,Products.ProductName,Suppliers.CompanyName,Products.UnitPrice from Products, Suppliers where Products.SupplierID = Suppliers.SupplierID", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    ware = null;
                }
                else
                {
                    while (dr.Read())
                    {
                        int id = int.Parse(dr[0].ToString());
                        string name = dr[1].ToString();
                        string supName = dr[2].ToString();
                        double price = double.Parse(dr[3].ToString());
                        ProductCL pro = new ProductCL(id, name, supName, price);
                        ware.Add(pro);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ware;
        }

        public static void getComboBox(ComboBox combobox, string command)
        {

            SqlCommand cmd = new SqlCommand(command, con);

            con.Open();
            ComboboxItem newItem = new ComboboxItem();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                newItem = new ComboboxItem();
                newItem.Text = dr[1].ToString();
                newItem.Value = dr[0].ToString();

                combobox.Items.Add(newItem);
            }
            combobox.SelectedIndex = 0;
            dr.Close();
            con.Close();

        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }

        }

        public static int GetSaled(string day)
        {
            int saled = 0;
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select Sum(OrderDetails.Quantity*OrderDetails.UnitPrice - OrderDetails.Quantity*OrderDetails.UnitPrice*Orders.Discount/100 ) from Orders,OrderDetails where cast(OrderDate as date) = '" + day + "' and Orders.OrderID = OrderDetails.OrderID", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    try
                    {
                        saled = int.Parse(dr[0].ToString());
                    }
                    catch (Exception)
                    {
                        saled = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return saled;
        }

        public static bool rightPass(string acc,string pass)
        {
            bool right = false;
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select * from Accounts where Username = '"+acc+"' and Password = '"+pass+"'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    right = true;
                }
                else
                {
                    right = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return right;
        }

        public static DataSet searchCustomerByID(int customerID)
        {
            string cmd = "SELECT * FROM Customers WHERE CustomerID = " + customerID;
            return SelectDS(cmd);
        }
        public static DataSet searchCustomerByName(string cusname)
        {
            string cmd = "SELECT *FROM Customers WHERE FirstName like '%" + cusname + "%' OR LastName like '%" + cusname + "%'";
            return SelectDS(cmd);
        }

        public static DataSet searchSupplierByID(int supID)
        {
            string cmd = "SELECT * FROM Suppliers WHERE SupplierID = " + supID;
            return SelectDS(cmd);
        }
        public static DataSet searchSupplierByComName(string comname)
        {
            string cmd = "SELECT * FROM Suppliers WHERE CompanyName like '%" + comname + "%'";
            return SelectDS(cmd);
        }
    }
}
