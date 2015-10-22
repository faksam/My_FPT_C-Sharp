using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lab3_Group1.BLL;
using Lab3_Group1.DTL;
using Lab3_Group1.DAL;

namespace Lab3_Group1.GUI
{
    public partial class BorrowGUI : Form
    {        
        public BorrowGUI()
        {
            InitializeComponent();
        }

        private void btCheckMember_Click(object sender, EventArgs e)
        {            
            int memberCode;
            try
            {
                memberCode = int.Parse(tbMemberCode.Text);
                if (!CirculatedCopyBL.isContainBorrowerCode(memberCode))
                {
                    Exception ex = new Exception("Member code does not exist!");
                    throw ex;
                }
                else {
                    tbName.Text = CirculatedCopyBL.getNameBorrower(memberCode);
                    tbName.Enabled = false;
                    DataSet ds = CirculatedCopyBL.selectDs();
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.RowFilter = "returnedDate is NULL and borrowerNumber="+memberCode;
                    labelBorrowBorrowedBook.Text = dv.Count.ToString();
                    dgvBorrowed.DataSource = dv;
                    tbCopyNumber.Enabled = true;
                    btCheckBorrowCondition.Enabled = true;
                    btCheckMember.Enabled = false;
                }

            }
            catch (Exception ex) {
                tbName.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void btCheckBorrowCondition_Click(object sender, EventArgs e)
        {
            try {
                int copyNumber = int.Parse(tbCopyNumber.Text);
                if (!CopyBL.isContainCopyNumber(copyNumber))
                {
                    Exception ex = new Exception("Copy Number does not exist!");
                    throw ex;
                }
                else {
                    int count = int.Parse(labelBorrowBorrowedBook.Text);
                    if (count >= 5)
                    {
                        Exception ex = new Exception("You can borrow 5 book only!");
                        throw ex;
                    }
                    else {
                        char ch = CopyBL.getTypeOfCopyNumber(copyNumber);
                        if (ch == 'B')
                        {
                            Exception ex = new Exception("This copy was borrowed!");
                            throw ex;
                        }
                        else {
                            if (ch == 'R')
                            {
                                Exception ex = new Exception("this copy is only for reference!");
                                throw ex;
                            }
                            else {
                                int bookNumber = CopyBL.getBookNumber(copyNumber);
                                int brNumber = int.Parse(tbMemberCode.Text);
                                if (!ReserveBL.isTheFirstReservation(brNumber, bookNumber))
                                {
                                    Exception ex = new Exception("This book had been reserved by other before!");
                                    throw ex;
                                }
                                else {
                                    tbBorrowedDate.Enabled = true;
                                    btCheckBorrowCondition.Enabled = false;
                                    tbBorrowedDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                                    tbDueDate.Text = DateTime.Today.AddDays(14).ToString("dd/MM/yyyy");
                                    btBorrow.Enabled = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btBorrow_Click(object sender, EventArgs e)
        {
            DateTime brDate;
            DateTime dueDate;
            int brNumber = int.Parse(tbMemberCode.Text.ToString());    
            int copyNumber = int.Parse(tbCopyNumber.Text.ToString());
            try {
                //brDate = DateTime.Parse(tbBorrowedDate.Text.ToString());                
                brDate = Utility.getReturnedDate(tbBorrowedDate.Text);
                dueDate = brDate.AddDays(14);
                CirculatedCopy c = new CirculatedCopy(copyNumber, brNumber, dueDate);
                if (CirculatedCopyBL.insert(c)) {
                    CopyBL.setTypeOfCopyNumber(copyNumber, 'B');
                    int bookNumber = CopyBL.getBookNumber(copyNumber);
                    ReserveBL.setStatusOfReservation(brNumber, bookNumber, 'A');
                    tbBorrowedDate.Enabled = false;
                    tbCopyNumber.Enabled = false;
                    btBorrow.Enabled = false ;
                    tbMemberCode.Enabled = true;
                    btCheckMember.Enabled = true;
                    tbDueDate.Text = dueDate.ToShortDateString();
                    MessageBox.Show("Borrow successful!");
                }
                DataSet ds = CirculatedCopyBL.selectDs();
                DataView dv = new DataView(ds.Tables[0]);
                dv.RowFilter = "returnedDate is NULL and borrowerNumber=" + brNumber;
                labelBorrowBorrowedBook.Text = dv.Count.ToString();
                dgvBorrowed.DataSource = dv;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
