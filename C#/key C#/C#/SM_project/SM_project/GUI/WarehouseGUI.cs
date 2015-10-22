using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SM_project.Data.Access;
using SM_project.Class;

namespace SM_project.GUI
{
    public partial class WarehouseGUI : Form
    {
        public WarehouseGUI()
        {
            InitializeComponent();
            DataSet ds = SelectDA.SelectDS("SELECT ProductID,ProductName,CompanyName,UnitPrice FROM Products,Suppliers WHERE Products.SupplierID = Suppliers.SupplierID");
            DataView dv = new DataView(ds.Tables[0]);
            dataGridView2.DataSource = dv;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = "SELECT ProductID,ProductName,CompanyName,UnitPrice FROM Products,Suppliers WHERE Products.SupplierID = Suppliers.SupplierID AND " + comboBox3.SelectedItem.ToString() + " LIKE '" + textBox4.Text + "%'";
                DataSet ds = SelectDA.SelectDS(cmd);
                DataView dv = new DataView(ds.Tables[0]);
                dataGridView2.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

    }
}
