using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SM_project.Class;
using SM_project.Data.Access;

namespace SM_project.GUI
{
    public partial class StatisticGUI : Form
    {
        public StatisticGUI()
        {
            InitializeComponent();
            loadTopProduct();
            loadTopEmployee();
            loadOrder();
            ValueAndBill(DateTime.Today);
        }

        private void loadTopProduct()
        {
            string cmd = "select Products.ProductID, Products.ProductName,Suppliers.CompanyName, Sum(OrderDetails.Quantity) as 'Saled' "
                +"from Products,OrderDetails,Suppliers where Products.ProductID = OrderDetails.ProductID "
                +"and Products.SupplierID = Suppliers.SupplierID "
                +"group by Products.ProductID, Products.ProductName,Suppliers.CompanyName order by Sum(OrderDetails.Quantity) desc";
            try
            {
                DataSet ds = SelectDA.SelectDS(cmd);
                dataGridView1.DataSource = ds.Tables[0];
                
                DataGridViewColumn column = dataGridView1.Columns[0];
                column.Width = 65;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadTopEmployee()
        {
            string cmd = "with ValueSaled as( select OrderID,UnitPrice*Quantity as 'Value Saled' from OrderDetails)"
                + " select Employees.EmployeeID,Accounts.Username,Employees.FirstName + ' ' + Employees.LastName as 'Fullname',Sum(ValueSaled.[Value Saled]) "
                +"as 'Total Value Saled' from ValueSaled,Orders,Employees,Accounts where Employees.EmployeeID = Orders.EmployeeID "
                + "and Orders.OrderID = ValueSaled.OrderID and Accounts.EmployeeID = Employees.EmployeeID group by Employees.EmployeeID,Accounts.Username,Employees.FirstName + ' ' + Employees.LastName "
                +"order by [Total Value Saled] desc";
            try
            {
                DataSet ds = SelectDA.SelectDS(cmd);
                dataGridView2.DataSource = ds.Tables[0];
                
                DataGridViewColumn column1 = dataGridView2.Columns[0];
                column1.Width = 65;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadOrder()
        {
            string cmd = "select Orders.OrderID,Accounts.Username,Orders.OrderDate from Orders,Accounts"
                + " where cast(OrderDate as date) = cast(GETDATE() as date) and Orders.EmployeeID = Accounts.EmployeeID";
            try
            {
                DataSet ds = SelectDA.SelectDS(cmd);
                dataGridView3.DataSource = ds.Tables[0];
                DataGridViewColumn column1 = dataGridView3.Columns[0];
                column1.Width = 65;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime day = dateTimePicker1.Value;
            ValueAndBill(day);
        }
        private void ValueAndBill(DateTime day)
        {
            string daypick = day.ToString("yyyy-MM-dd");
            string cmd = "select Orders.OrderID,Accounts.Username,Orders.OrderDate from Orders,Accounts"
                + " where cast(OrderDate as date) = '" + daypick + "' and Orders.EmployeeID = Accounts.EmployeeID";
            try
            {
                DataSet ds = SelectDA.SelectDS(cmd);
                dataGridView3.DataSource = ds.Tables[0];
                DataGridViewColumn column1 = dataGridView3.Columns[0];
                column1.Width = 65;
                txtDay.Text = day.ToShortDateString() + " : " + SelectDA.GetSaled(daypick) + " VND";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int orderId = int.Parse(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                string cmd = "select Orders.OrderID,Products.ProductID,Products.ProductName,Suppliers.CompanyName,OrderDetails.Quantity,Orders.Discount"
                    + " from OrderDetails,Products,Suppliers,Orders where Orders.OrderID = " + orderId
                    + "and Orders.OrderID = OrderDetails.OrderID and Products.ProductID = OrderDetails.ProductID and Products.SupplierID = Suppliers.SupplierID";
                try
                {
                    DataSet ds = SelectDA.SelectDS(cmd);
                    dataGridView4.DataSource = ds.Tables[0];
                    DataGridViewColumn column1 = dataGridView4.Columns[0];
                    column1.Width = 65;
                    DataGridViewColumn column2 = dataGridView4.Columns[1];
                    column2.Width = 65;
                    DataGridViewColumn column3 = dataGridView4.Columns[4];
                    column3.Width = 65;
                    DataGridViewColumn column4 = dataGridView4.Columns[5];
                    column4.Width = 65;
                    DataGridViewColumn column5 = dataGridView4.Columns[2];
                    column5.Width = 116;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception) { }
        }
    }
}
