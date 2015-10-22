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
namespace SM_project.GUI {
    public partial class CustomerGUI: Form {
        public CustomerGUI() {
            InitializeComponent();
            EnableTextBox(false);
            ClearTextBox();
            comboBox1.SelectedIndex = 1;
            showData("");
        }
        public void EnableTextBox(bool b) {
            textBox1.Enabled = b;
            textBox2.Enabled = b;
            textBox3.Enabled = b;
            textBox4.Enabled = b;
            textBox5.Enabled = b;
            textBox6.Enabled = b;
            textBox8.Enabled = b;
            textBox7.Enabled = !b;
            comboBox1.Enabled = !b;
        }
        public void ClearTextBox() {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox8.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void button4_Click(object sender, EventArgs e) {
            string searchString = textBox7.Text.Trim();
            if(comboBox1.SelectedIndex == 0) {
                int a;
                try {
                    a = int.Parse(searchString);
                    DataSet ds = SelectDA.searchCustomerByID(a);
                    if(ds.Tables[0].Rows.Count == 0) {
                        MessageBox.Show("not found!");
                    } else {
                        DataView dv = new DataView(ds.Tables[0]);
                        dataGridView1.DataSource = dv;
                        //  dv.Table.Rows[0].
                    }
                } catch(Exception) {
                    MessageBox.Show("Please enter number");
                }
            } else if(comboBox1.SelectedIndex == 1) {
                showData(searchString);
            } else {
                MessageBox.Show("Please chosing search type first");
            }


        }
        public void showData(string search) {
            DataSet ds = SelectDA.searchCustomerByName(search);
            if(ds.Tables[0].Rows.Count == 0) {
                MessageBox.Show("not found!");
            } else {
                DataView dv = new DataView(ds.Tables[0]);
                dataGridView1.DataSource = dv;
            }
        }
        //public void showToLable(CustomerCL cus) {
        //    textBox1.Text = cus.CustomerID.ToString();
        //    textBox2.Text = cus.Lastname;
        //    textBox3.Text = cus.Firstname;
        //    textBox4.Text = cus.Companyname;
        //    textBox6.Text = cus.Phone;
        //    textBox5.Text = cus.Address;
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            try {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["CompanyName"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["Discount"].Value.ToString();
            } catch(Exception) {
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            if(button1.Text == "Add") {
                int a = SelectDA.GetMax("CustomerID", "Customers")+1;
                ClearTextBox();
                EnableTextBox(true);
                dataGridView1.DataSource = null;
                textBox1.Enabled = false;
                textBox1.Text = a.ToString();
                button1.Text = "Save";
                button2.Enabled = false;
                button3.Enabled = false;
            } else {
                if(textBox2.Text == ""||textBox3.Text=="") {
                    MessageBox.Show("First name and last name must be fill");
                } else {
                    CustomerCL cus = new CustomerCL();
                    try {
                        cus.Discount = int.Parse(textBox8.Text);
                        cus.CustomerID = int.Parse(textBox1.Text.Trim());
                        cus.Lastname = textBox2.Text;
                        cus.Firstname = textBox3.Text;
                        cus.Companyname = textBox4.Text;
                        cus.Phone = textBox6.Text;
                        cus.Address = textBox5.Text;
                        InsertDA.insertCustomer(cus);
                        ClearTextBox();
                        EnableTextBox(false);
                        button1.Text = "Add";
                        button2.Enabled = true;
                        button3.Enabled = true;
                        showData("");
                    } catch(Exception ex) {
                        MessageBox.Show("Discount must be filled");
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if(button2.Text == "Edit") {
                EnableTextBox(true);
                textBox1.Enabled = false;
                button2.Text = "Save";
                button1.Enabled = false;
                button3.Enabled = false;
            } else {
                if(textBox2.Text == "" || textBox3.Text == "") {
                    MessageBox.Show("First name and last name must be fill");
                } else {
                    CustomerCL cus = new CustomerCL();
                    try {
                        cus.Discount = int.Parse(textBox8.Text);
                        cus.CustomerID = int.Parse(textBox1.Text.Trim());
                        cus.Lastname = textBox2.Text;
                        cus.Firstname = textBox3.Text;
                        cus.Companyname = textBox4.Text;
                        cus.Phone = textBox6.Text;
                        cus.Address = textBox5.Text;
                        UpdateDA.CustomerUpdate(cus);
                        ClearTextBox();
                        EnableTextBox(false);
                        button2.Text = "Edit";
                        button1.Enabled = true;
                        button3.Enabled = true;
                        showData("");
                    } catch(Exception ex) {
                        MessageBox.Show("Discount must be filled");
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e) {
            if (textBox1.Text == "")
                return;
            int a = int.Parse(textBox1.Text);

            DialogResult result = MessageBox.Show("Are you sure to delete Mr/Mrs " + textBox3.Text + "'s account?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteDA.DeleteAllOrder(a);
                DeleteDA.DeleteChung(a, "CustomerID", "Orders");
                DeleteDA.DeleteCustomer(a);
                showData("");
            }
            else
            {
            }
        }
    }
}
