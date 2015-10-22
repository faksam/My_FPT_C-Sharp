using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lab3_Group1.BLL;
using Lab3_Group1.DAL;
using Lab3_Group1.DTL;
using System.Data.SqlClient;

namespace Lab3_Group1.GUI
{
    public partial class ReturnGUI : Form
    {
        public ReturnGUI()
        {
            InitializeComponent();
        }

        private void btChkMember_Click(object sender, EventArgs e)
        {

            #region demo
            //try
            //{
            //    int memCode = int.Parse(txtMemCode.Text);
            //    txtName.Text = "";
            //    dataGridView1.DataSource = null;
            //    SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
            //    SqlCommand cmd = new SqlCommand("Select name as Member from Borrower where borrowerNumber="+memCode, cn);

            //    cn.Open();

            //    SqlDataReader rd = cmd.ExecuteReader();
            //    if (rd.Read())
            //    {
            //        txtName.Text = rd["Member"].ToString();
            //        DataSet ds = CirculatedCopyDA.SelectDS();
            //        DataView dv = new DataView(ds.Tables[0]);
            //        dv.RowFilter = "returnedDate IS NULL AND borrowerNumber="+memCode;
            //        labelBorrowedBookNumber.Text = dv.Count.ToString();
            //        dataGridView1.DataSource = dv;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Member does not exist!");
            //    }
            //    rd.Close();

            //    cn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //} 
            #endregion
            try
            {
                int id = int.Parse(txtMemCode.Text);
                string s;
                s = ReservationDA.GetMemberName(id);
                if (s != null)
                {

                    txtName.Text = s;

                    DataSet ds = CirculatedCopyDA.SelectDS();
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.RowFilter = "returnedDate IS NULL AND borrowerNumber=" + id;
                    labelBorrowedBookNumber.Text = dv.Count.ToString();
                    dataGridView1.DataSource = dv;
                }

                else
                {
                    MessageBox.Show("Member Code doesn't Exist ");
                    txtMemCode.Text = "";
                    txtMemCode.Focus();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Incorrect Id format!");
                txtMemCode.Text = "";
                txtMemCode.Focus();
            }
        }
        private void buttonConfirmFine_Click(object sender, EventArgs e)
        {
            if (!isSelectedCopy())
            {
                MessageBox.Show("Please select a copy to return!");
                return ;
            }
            DateTime today = DateTime.Today;
            DateTime dueDate = (DateTime)dataGridView1.SelectedRows[0].Cells["dueDate"].Value;
            double diff = today.Subtract(dueDate).TotalDays;
            if (diff < 0) diff = 0;
            txtFineAmount.Text = diff+"";
            int id = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;
            int copyNumber = (int)dataGridView1.SelectedRows[0].Cells["copyNumber"].Value;
            int borrowerNumber = (int)dataGridView1.SelectedRows[0].Cells["borrowerNumber"].Value;
            DateTime borrowedDate = (DateTime)dataGridView1.SelectedRows[0].Cells["borrowedDate"].Value;

            CirculatedCopy c = new CirculatedCopy(copyNumber, borrowerNumber, dueDate);
            c.Id = id;
            c.BorrowedDate = borrowedDate;
            c.ReturnedDate = today;
            c.FineAmount = (float)diff;

            ReturnBL.Update(c);
            CopyDA.updateStatus(copyNumber);

            MessageBox.Show("Book returned successfully!");

            

            DataSet ds = CirculatedCopyDA.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "returnedDate IS NULL AND borrowerNumber=" + borrowerNumber;
            dataGridView1.DataSource = dv;
        }

        public bool isSelectedCopy()
        {
            if (dataGridView1.SelectedRows.Count == 0) return false;
            if (dataGridView1.SelectedRows[0].Cells["copyNumber"] == null) return false;
            return true;
        }
    }
}
