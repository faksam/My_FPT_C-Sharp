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
    public partial class AdminGUI : Form
    {
        public AdminGUI()
        {
            InitializeComponent();
            SelectDA.getComboBox(comboBox2, "SELECT * FROM Suppliers ORDER BY CompanyName");
            DataSet ds = SelectDA.SelectDS("SELECT ProductID,ProductName,CompanyName,UnitPrice FROM Products,Suppliers WHERE Products.SupplierID = Suppliers.SupplierID");
            DataView dv = new DataView(ds.Tables[0]);
            dataGridView3.DataSource = dv;
            textBox10.Enabled = false;
            textBox9.Enabled = false;
            comboBox2.Enabled = false;
            textBox8.Enabled = false;
            button8.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;

            EnableTextBox(false);
            ClearTextBox();
            cbTypeSearch.SelectedIndex = 1;
            showData("");
            InitializeMemberData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = "SELECT ProductID,ProductName,CompanyName,UnitPrice FROM Products,Suppliers WHERE Products.SupplierID = Suppliers.SupplierID AND " + comboBox3.SelectedItem.ToString() + " LIKE '" + textBox11.Text + "%'";
                DataSet ds = SelectDA.SelectDS(cmd);
                DataView dv = new DataView(ds.Tables[0]);
                dataGridView3.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text.Equals("Add"))
            {
                button6.Text = "Save";
                button5.Text = "Cancel";
                button4.Enabled = false;
                textBox10.Text = "" + (SelectDA.GetMax("ProductID", "Products") + 1);
                textBox9.Enabled = true;
                comboBox2.Enabled = true;
                textBox8.Enabled = true;
                return;
            }

            if (button6.Text.Equals("Save"))
            {
                ProductCL a = new ProductCL();
                a.ProductID = SelectDA.GetMax("ProductID", "Products") + 1;
                a.ProductName = textBox9.Text;
                SelectDA.ComboboxItem selectedCar = (SelectDA.ComboboxItem)comboBox2.SelectedItem;
                int selecteVal = Convert.ToInt32(selectedCar.Value);
                a.SupplierId = selecteVal;
                try
                {
                    a.Price = int.Parse(textBox8.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Wrong input for Unit Price !");
                }
                InsertDA.insertProduct(a);
                DataSet ds = SelectDA.SelectDS("SELECT ProductID,ProductName,CompanyName,UnitPrice FROM Products,Suppliers WHERE Products.SupplierID = Suppliers.SupplierID");
                DataView dv = new DataView(ds.Tables[0]);
                dataGridView3.DataSource = dv;
                textBox10.Enabled = false;
                textBox9.Enabled = false;
                comboBox2.Enabled = false;
                textBox8.Enabled = false;
                button6.Text = "Add";
                button5.Text = "Edit";
                button4.Enabled = true;
                textBox10.Text = "";
                textBox9.Text = "";
                textBox8.Text = "";
                comboBox2.SelectedIndex = 0;
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text.Equals("Cancel"))
            {
                textBox10.Text = "";
                textBox9.Text = "";
                textBox8.Text = "";
                comboBox2.SelectedIndex = 0;
                textBox10.Enabled = false;
                textBox9.Enabled = false;
                comboBox2.Enabled = false;
                textBox8.Enabled = false;
                button6.Text = "Add";
                button5.Text = "Edit";
                button4.Enabled = true;
                return;
            }

            if (button5.Text.Equals("Edit"))
            {


                try
                {
                    textBox10.Text = "" + int.Parse(dataGridView3.SelectedRows[0].Cells["ProductID"].Value.ToString());
                    textBox9.Text = dataGridView3.SelectedRows[0].Cells["ProductName"].Value.ToString();
                    //comboBox2.SelectedIndex = comboBox2.Items.IndexOf(int.Parse(dataGridView1.SelectedRows[0].Cells["SupplierID"].Value.ToString()));
                    comboBox2.Text = dataGridView3.SelectedRows[0].Cells["CompanyName"].Value.ToString();
                    textBox8.Text = "" + int.Parse(dataGridView3.SelectedRows[0].Cells["UnitPrice"].Value.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("You must select a Product !");
                    return;
                }

                button6.Enabled = false;
                button5.Text = "Save";
                button4.Text = "Cancel";
                textBox9.Enabled = true;
                comboBox2.Enabled = true;
                textBox8.Enabled = true;
                dataGridView3.Enabled = false;
                return;
            }

            if (button5.Text.Equals("Save"))
            {
                ProductCL a = new ProductCL();
                a.ProductID = int.Parse(textBox10.Text);
                a.ProductName = textBox9.Text;
                SelectDA.ComboboxItem selectedCar = (SelectDA.ComboboxItem)comboBox2.SelectedItem;
                int selecteVal = Convert.ToInt32(selectedCar.Value);
                a.SupplierId = selecteVal;
                try
                {
                    a.Price = int.Parse(textBox8.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Wrong input for Unit Price !");
                }
                UpdateDA.productUpdate(a);
                DataSet ds = SelectDA.SelectDS("SELECT ProductID,ProductName,CompanyName,UnitPrice FROM Products,Suppliers WHERE Products.SupplierID = Suppliers.SupplierID");
                DataView dv = new DataView(ds.Tables[0]);
                dataGridView3.DataSource = dv;
                textBox10.Enabled = false;
                textBox9.Enabled = false;
                comboBox2.Enabled = false;
                textBox8.Enabled = false;
                textBox10.Text = "";
                textBox9.Text = "";
                textBox8.Text = "";
                comboBox2.SelectedIndex = 0;
                button4.Text = "Delete";
                button5.Text = "Edit";
                button6.Enabled = true;
                dataGridView3.Enabled = true;
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text.Equals("Cancel"))
            {
                textBox10.Text = "";
                textBox9.Text = "";
                textBox8.Text = "";
                comboBox2.SelectedIndex = 0;
                textBox10.Enabled = false;
                textBox9.Enabled = false;
                comboBox2.Enabled = false;
                textBox8.Enabled = false;
                button6.Text = "Add";
                button5.Text = "Edit";
                button4.Text = "Delete";
                button6.Enabled = true;
                dataGridView3.Enabled = true;
                return;
            }

            if (button4.Text.Equals("Delete"))
            {
                ProductCL a = new ProductCL();
                try
                {
                    a.ProductID = int.Parse(dataGridView3.SelectedRows[0].Cells["ProductID"].Value.ToString());

                }
                catch (Exception)
                {
                    MessageBox.Show("You must select a Product !");
                    return;
                }
                DialogResult result = MessageBox.Show("Do you want to DELETE this product ?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteDA.DeleteAllOrder(a);
                    DeleteDA.DeleteProduct(a);
                    DataSet ds = SelectDA.SelectDS("SELECT ProductID,ProductName,CompanyName,UnitPrice FROM Products,Suppliers WHERE Products.SupplierID = Suppliers.SupplierID");
                    DataView dv = new DataView(ds.Tables[0]);
                    dataGridView3.DataSource = dv;
                }
                else
                {
                    return;
                }

            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = "SELECT * FROM Suppliers WHERE " + cbTypeSearch.SelectedItem.ToString() + " LIKE '" + tbKeyword.Text + "%'";
                DataSet ds = SelectDA.SelectDS(cmd);
                DataView dv = new DataView(ds.Tables[0]);
                dgvSupplier.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbSupID.Text = dgvSupplier.Rows[e.RowIndex].Cells["SupplierID"].Value.ToString();
                tbComName.Text = dgvSupplier.Rows[e.RowIndex].Cells["CompanyName"].Value.ToString();
                tbConName.Text = dgvSupplier.Rows[e.RowIndex].Cells["ContactName"].Value.ToString();
                tbAddress.Text = dgvSupplier.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                tbPhone.Text = dgvSupplier.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                tbFax.Text = dgvSupplier.Rows[e.RowIndex].Cells["Fax"].Value.ToString();
            }
            catch (Exception) { }
        }
        public void ClearTextBox()
        {
            tbSupID.Clear();
            tbComName.Clear();
            tbConName.Clear();
            tbAddress.Clear();
            tbPhone.Clear();
            tbFax.Clear();
        }
        public void showData(string search)
        {
            DataSet ds = SelectDA.searchSupplierByComName(search);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("not found!");
            }
            else
            {
                DataView dv = new DataView(ds.Tables[0]);
                dgvSupplier.DataSource = dv;
            }
        }

        public void EnableTextBox(bool b)
        {
            tbSupID.Enabled = b;
            tbComName.Enabled = b;
            tbAddress.Enabled = b;
            tbConName.Enabled = b;
            tbPhone.Enabled = b;
            tbFax.Enabled = b;
            tbKeyword.Enabled = !b;
            cbTypeSearch.Enabled = !b;
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (btAdd.Text == "Add")
            {
                int a = SelectDA.GetMax("SupplierID", "Suppliers") + 1;
                ClearTextBox();
                EnableTextBox(true);
                dgvSupplier.DataSource = null;
                tbSupID.Enabled = false;
                tbSupID.Text = a.ToString();
                btAdd.Text = "Save";
                btEdit.Enabled = false;
                btDelete.Enabled = false;
            }
            else
            {
                if (tbComName.Text == "")
                {
                    MessageBox.Show("Company Name must be fill");
                }
                else
                {
                    SupplierCL sup = new SupplierCL();
                    try
                    {
                        sup.SupplierID = int.Parse(tbSupID.Text.Trim());
                        sup.ComName = tbComName.Text;
                        sup.ConName = tbConName.Text;
                        sup.Address = tbAddress.Text;
                        sup.Phone = tbPhone.Text;
                        sup.Fax = tbFax.Text;
                        InsertDA.insertSupplier(sup);
                        ClearTextBox();
                        EnableTextBox(false);
                        btAdd.Text = "Add";
                        btEdit.Enabled = true;
                        btDelete.Enabled = true;
                        showData("");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Company Name must be filled");
                    }
                }
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (btEdit.Text == "Edit")
            {
                EnableTextBox(true);
                tbSupID.Enabled = false;
                btEdit.Text = "Save";
                btAdd.Enabled = false;
                btDelete.Enabled = false;
            }
            else
            {
                if (tbComName.Text == "")
                {
                    MessageBox.Show("Company name must be fill");
                }
                else
                {
                    SupplierCL sup = new SupplierCL();
                    try
                    {
                        sup.SupplierID = int.Parse(tbSupID.Text.Trim());
                        sup.ComName = tbComName.Text;
                        sup.ConName = tbConName.Text;
                        sup.Address = tbAddress.Text;
                        sup.Phone = tbPhone.Text;
                        sup.Fax = tbFax.Text;
                        UpdateDA.SupplierUpdate(sup);
                        ClearTextBox();
                        EnableTextBox(false);
                        btEdit.Text = "Edit";
                        btAdd.Enabled = true;
                        btDelete.Enabled = true;
                        showData("");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Company Name must be filled");
                    }
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (tbSupID.Text == "")
                return;
            int a = int.Parse(tbSupID.Text);

            DialogResult result = MessageBox.Show("Are you sure to delete " + tbComName.Text + " Company", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteDA.DeleteAllSup(a);
                DeleteDA.DeleteChung(a, "SupplierID", "Products");
                DeleteDA.DeleteSupplier(a);
                ClearTextBox();
                showData("");
            }
            else
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox6.Visible = true;
            textBox7.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;

            dataGridView1.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            comboBox1.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button8.Visible = false;
            button9.Visible = true;
            button10.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
        }
        private bool isSelected()
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return false;
            if (dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value == null) return false;
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!isSelected())
            {
                MessageBox.Show("Please select a employee to edit!");
                return;
            }
            dataGridView1.Enabled = false;

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            comboBox1.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button8.Visible = true;
            button9.Visible = false;
            button10.Visible = false;

            textBox6.Visible = false;
            textBox7.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;

            if (!isSelected())
            {
                MessageBox.Show("Please select a employee to delete!");
                return;
            }

            EmployeeCL emp = new EmployeeCL();
            emp.EmployeeID = int.Parse(dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value.ToString());

            AccountCL acc = new AccountCL();
            acc.EmployeeID = emp.EmployeeID;
            DialogResult result = MessageBox.Show("Do you really want to delete this employee and its account!", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteDA.DeleteAllEmp(acc.EmployeeID);
                DeleteDA.DeleteChung(acc.EmployeeID, "EmployeeID", "Orders");
                AccountDA.Delete(acc);
                EmployeeDA.Delete(emp);
            }
            else { }
            InitializeMemberData();
        }
        int emID;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                emID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["EmployeeID"].Value.ToString());
            }
            catch (Exception)
            {
            }
        }

        public void InitializeMemberData()
        {
            DataSet ds = EmployeeDA.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            dataGridView1.DataSource = dv;

            dataGridView1.Enabled = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            comboBox1.Enabled = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.Text = "";
        }


        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter value for Lastname!");
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter value for Firstname!");
                return;
            }

            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select value for Rank!");
                return;
            }

            string last = textBox1.Text;
            string first = textBox2.Text;
            string phone = textBox3.Text;
            string add = textBox4.Text;
            string tit = comboBox1.SelectedItem.ToString();

            DialogResult result = MessageBox.Show("Do you really want to edit this employee!", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                EmployeeCL em = new EmployeeCL(last, first, phone, add, tit);
                em.EmployeeID = emID;
                EmployeeDA.Update(em);
            }
            else { }
            button8.Visible = false;
            InitializeMemberData();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter value for Lastname!");
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter value for Firstname!");
                return;
            }

            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select value for Rank!");
                return;
            }

            if (textBox6.Text == "")
            {
                MessageBox.Show("Please enter value for Account Name!");
                return;
            }

            if (textBox6.Text.Length > 50)
            {
                MessageBox.Show("Account Name too long!");
                return;
            }

            if (textBox7.Text == "")
            {
                MessageBox.Show("Please enter value for Password!");
                return;
            }

            if (textBox7.Text.Length > 30)
            {
                MessageBox.Show("Password too long!");
                return;
            }

            string last = textBox1.Text;
            string first = textBox2.Text;
            string phone = textBox3.Text;
            string add = textBox4.Text;
            string tit = comboBox1.SelectedItem.ToString();

            EmployeeCL em = new EmployeeCL(last, first, phone, add, tit);
            string user = textBox6.Text;
            string pass = textBox7.Text;
            

            bool check = AccountDA.checkAcc(user);
            if (check == true)
            {
                MessageBox.Show("Username is existed. Please try other Username!");
                return;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                DialogResult result1 = MessageBox.Show("Are you sure to create new adminitrator??", "Confirm", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    EmployeeDA.Insert(em);
                    int empID = SelectDA.GetMax("EmployeeID", "Employees");
                    AccountCL ac = new AccountCL(user, pass, empID);
                    AccountDA.Insert(ac);
                }
                else { }
            }
            else
            {
                DialogResult result2 = MessageBox.Show("Are you sure to create new employee??", "Confirm", MessageBoxButtons.YesNo);
                if (result2 == DialogResult.Yes)
                {
                    EmployeeDA.Insert(em);
                    int empID = SelectDA.GetMax("EmployeeID", "Employees");
                    AccountCL ac = new AccountCL(user, pass, empID);
                    AccountDA.Insert(ac);
                }
                else { }
            }
            InitializeMemberData();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            InitializeMemberData();

            textBox6.Visible = false;
            textBox7.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
        }
    }
}
