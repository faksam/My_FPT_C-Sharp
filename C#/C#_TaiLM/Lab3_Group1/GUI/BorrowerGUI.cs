using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lab3_Group1.DAL;
using Lab3_Group1.BLL;
using Lab3_Group1.DTL;

namespace Lab3_Group1.GUI
{
    public partial class BorrowerGUI : Form
    {
        public BorrowerGUI()
        {
            InitializeComponent();
            DataSet ds = BorrowerDA.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            dataGridView1.DataSource = dv;
        }

        private void refresh()
        {
            txtMemberCode.Text = "";
            txtName.Text = "";
            txtSex.Text = "";
            txtAddress.Text = "";
            txtTelephone.Text = "";
            txtEmail.Text = "";

            txtName.Enabled = false;
            txtSex.Enabled = false;
            txtAddress.Enabled = false;
            txtTelephone.Enabled = false;
            txtEmail.Enabled = false;

            DataSet ds = BorrowerDA.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            dataGridView1.DataSource = dv;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMemberCode.Text = dataGridView1.Rows[e.RowIndex].Cells["borrowerNumber"].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
            txtSex.Text = dataGridView1.Rows[e.RowIndex].Cells["sex"].Value.ToString();
            txtTelephone.Text = dataGridView1.Rows[e.RowIndex].Cells["telephone"].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
        }

        private void buttonMAdd_Click(object sender, EventArgs e)
        {
            
            txtName.Enabled = true;
            txtMemberCode.Enabled = false;
            txtSex.Enabled = true;
            txtAddress.Enabled = true;
            txtTelephone.Enabled = true;
            txtEmail.Enabled = true;
            if (buttonMAdd.Text == "Finish")
            {
                //Check Sex
                if (txtSex.Text != "M" && txtSex.Text != "F")
                {
                    MessageBox.Show("Re-enter Sex for member : 'M' or 'F'");
                    txtSex.Clear();
                    txtSex.Focus();
                    return;
                }
                //Check telephone
                if (txtTelephone.Text != "")
                {
                    float n;
                    bool isNum = float.TryParse(txtTelephone.Text.Trim(), out n);
                    if (!isNum)
                    {
                        txtTelephone.Clear();
                        txtTelephone.Focus();
                        MessageBox.Show("Re-enter telephone number!");
                        return;
                    }
                }
                Borrower b = new Borrower();
                b.BorrowerNumber = int.Parse(txtMemberCode.Text);
                b.Name = txtName.Text;
                b.Sex = char.Parse(txtSex.Text);
                b.Address = txtAddress.Text;
                b.Telephone = txtTelephone.Text;
                b.Email = txtEmail.Text;
                BorrowerBL.Insert(b);
                refresh();

                buttonMAdd.Text = "Add";
                buttonMDelete.Enabled = true;
                buttonMEdit.Enabled = true;
                buttonMFilter.Enabled = true;
                txtMemberCode.Enabled = true;
            }
            else
            {
                buttonMAdd.Text = "Finish";

                BorrowerBL.SetBorrowerNumberMax();
                int max = ++BorrowerBL.borrowerNumberMax;
                txtMemberCode.Text = max.ToString();
                txtName.Focus();
                buttonMDelete.Enabled = false;
                buttonMEdit.Enabled = false;
                buttonMFilter.Enabled = false;

            }
        }

        private void buttonMFilter_Click(object sender, EventArgs e)
        {
            int n;
            bool isNum = int.TryParse(txtMemberCode.Text.Trim(), out n);
            if (txtMemberCode.Text != "" && !isNum)
            {
                MessageBox.Show("Enter member code to filter!");
                txtMemberCode.Clear();
                txtMemberCode.Focus();
            }
            else if(txtMemberCode.Text == "")
            {
                DataSet ds = BorrowerDA.SelectDS();
                DataView dv = new DataView(ds.Tables[0]);
                dv.RowFilter = "";
                dataGridView1.DataSource = dv;
            }
            
            else
            {
                DataSet ds = BorrowerDA.SelectDS();
                DataView dv = new DataView(ds.Tables[0]);
                dv.RowFilter = "borrowerNumber = " + txtMemberCode.Text;
                dataGridView1.DataSource = dv;
            }
        }

        private void buttonMEdit_Click(object sender, EventArgs e)
        {
            if (!isSelectedCopy()) 
            {
                MessageBox.Show("Please select a member to edit!");
                return;
            }

            if (buttonMEdit.Text == "Finish")
            {
                Borrower b = new Borrower();
                b.BorrowerNumber = int.Parse(txtMemberCode.Text);
                b.Name = txtName.Text;
                b.Sex = char.Parse(txtSex.Text);
                b.Address = txtAddress.Text;
                b.Telephone = txtTelephone.Text;
                b.Email = txtEmail.Text;
                BorrowerBL.Update(b);
                refresh();

                buttonMEdit.Text = "Edit";
                buttonMDelete.Enabled = true;
                buttonMAdd.Enabled = true;
                buttonMFilter.Enabled = true;
                txtMemberCode.Enabled = true;
            }
            else
            {
                buttonMEdit.Text = "Finish";
                txtName.Enabled = true;
                txtMemberCode.Enabled = false;
                txtSex.Enabled = true;
                txtAddress.Enabled = true;
                txtTelephone.Enabled = true;
                txtEmail.Enabled = true;
                
                txtName.Focus();

                buttonMDelete.Enabled = false;
                buttonMAdd.Enabled = false;
                buttonMFilter.Enabled = false;
            }
        }

        private bool isSelectedCopy()
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return false;
            if (dataGridView1.SelectedRows[0].Cells["borrowerNumber"].Value == null) return false;
            return true;
        }

        private void buttonMDelete_Click(object sender, EventArgs e)
        {
            if (!isSelectedCopy())
            {
                MessageBox.Show("Please select a member to delete");
                return;
            }

            Borrower c = new Borrower();
            c.BorrowerNumber = int.Parse(dataGridView1.SelectedRows[0].Cells["borrowerNumber"].Value.ToString());
            BorrowerBL.Delete(c);
            refresh();
        }
    }
}
