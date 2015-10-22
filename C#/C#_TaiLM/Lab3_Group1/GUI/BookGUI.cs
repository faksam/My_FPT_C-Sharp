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
    public partial class BookGUI : Form
    {
        public BookGUI()
        {
            InitializeComponent();
            DataSet ds = BookBL.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            dataGridViewBook.DataSource = dv;
        }

        private void refreshBook()
        {
            DataSet ds = BookBL.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            dataGridViewBook.DataSource = dv;
            txtBookNumber.Text = "";
            txtTitle.Text = "";
            txtAuthors.Text = "";
            txtPublisher.Text = "";
        }

        private void refreshCopy()
        {
            showCopy();
            txtBookNumber1.Text = "";
            txtCopyNumber.Text = "";
            txtSequenceNumber.Text = "";
            txtType.Text = "";
            txtPrice.Text = "";
        }

        private void showCopy()
        {
            DataSet ds = CopyBL.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            if (txtBookNumber.Text != "")

                dv.RowFilter = "bookNumber=" + txtBookNumber.Text;
            else
                dv.RowFilter = "bookNumber=0";
            dataGridViewCopy.DataSource = dv;
        }

        private void dataGridViewBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtBookNumber.Text = dataGridViewBook.Rows[e.RowIndex].Cells["bookNumber"].Value.ToString();
            txtTitle.Text = dataGridViewBook.Rows[e.RowIndex].Cells["title"].Value.ToString();
            txtAuthors.Text = dataGridViewBook.Rows[e.RowIndex].Cells["authors"].Value.ToString();
            txtPublisher.Text = dataGridViewBook.Rows[e.RowIndex].Cells["publisher"].Value.ToString();
            showCopy();

        }

        private bool isSelectedBook()
        {
            if (dataGridViewBook.SelectedRows.Count == 0)
                return false;
            if (dataGridViewBook.SelectedRows[0].Cells["bookNumber"].Value == null) return false;
            return true;
        }

        private bool isSelectedCopy()
        {
            if (dataGridViewCopy.SelectedRows.Count == 0)
                return false;
            if (dataGridViewCopy.SelectedRows[0].Cells["copyNumber"].Value == null) return false;
            return true;
        }

        private void buttonBAdd_Click(object sender, EventArgs e)
        {
            txtBookNumber.Enabled = false;
            txtTitle.Enabled = true;
            txtAuthors.Enabled = true;
            txtPublisher.Enabled = true;

            if (buttonBAdd.Text == "Finish")
            {
                Book b = new Book();
                b.BookNumber = int.Parse(txtBookNumber.Text);
                b.Title = txtTitle.Text;
                b.Authors = txtAuthors.Text;
                b.Publisher = txtPublisher.Text;
                BookBL.Insert(b);
                refreshBook();

                buttonBAdd.Text = "Add";
                buttonBDelete.Enabled = true;
                buttonBEdit.Enabled = true;
                buttonFilter.Enabled = true;
                buttonCAdd.Enabled = true;
                buttonCDelete.Enabled = true;
                buttonCEdit.Enabled = true;
                txtBookNumber.Enabled = true;
                txtPublisher.Enabled = false;
                txtTitle.Enabled = false;
                txtAuthors.Enabled = false;
            }
            else
            {
                buttonBAdd.Text = "Finish";
                int max = ++BookBL.bookNumberMax;
                txtBookNumber.Text = max.ToString();
                txtTitle.Focus();

                buttonBDelete.Enabled = false;
                buttonBEdit.Enabled = false;
                buttonFilter.Enabled = false;
                buttonCAdd.Enabled = false;
                buttonCDelete.Enabled = false;
                buttonCEdit.Enabled = false;
            }

        }
        
        private void buttonBDelete_Click(object sender, EventArgs e)
        {
            if (!isSelectedBook())
            {
                MessageBox.Show("Please select a book to delete");
                return;
            }

            Book b = new Book();
            b.BookNumber = int.Parse(dataGridViewBook.SelectedRows[0].Cells["bookNumber"].Value.ToString());
            BookBL.Delete(b);
            refreshBook();
        }
        
        private void buttonBEdit_Click(object sender, EventArgs e)
        {
            if (!isSelectedBook())
            {
                MessageBox.Show("Please select a book to edit");
                return;
            }

            

            if (buttonBEdit.Text == "Finish")
            {
                Book b = new Book();
                b.BookNumber = int.Parse(txtBookNumber.Text);
                b.Title = txtTitle.Text;
                b.Authors = txtAuthors.Text;
                b.Publisher = txtPublisher.Text;
                BookBL.Update(b);
                refreshBook();
                buttonBDelete.Enabled = true;
                buttonBAdd.Enabled = true;
                buttonFilter.Enabled = true;
                buttonCAdd.Enabled = true;
                buttonCDelete.Enabled = true;
                buttonCEdit.Enabled = true;
                txtBookNumber.Enabled = true;
                txtPublisher.Enabled = false;
                txtTitle.Enabled = false;
                txtAuthors.Enabled = false;
            }
            else
            {
                buttonBEdit.Text = "Finish";
                txtBookNumber.Enabled = false;
                txtTitle.Enabled = true;
                txtAuthors.Enabled = true;
                txtPublisher.Enabled = true;
                buttonBDelete.Enabled = false;
                buttonBAdd.Enabled = false;
                buttonFilter.Enabled = false;
                buttonCAdd.Enabled = false;
                buttonCDelete.Enabled = false;
                buttonCEdit.Enabled = false;
            }
            
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            int n;
            bool isNum = int.TryParse(txtBookNumber.Text.Trim(),out n);
            if (txtBookNumber.Text != "" && !isNum)
            {
                MessageBox.Show("Enter Book number to filter!");
                txtBookNumber.Clear();
                txtBookNumber.Focus();
            }
            else if (txtBookNumber.Text == "")
            {
                DataSet ds = BookBL.SelectDS();
                DataView dv = new DataView(ds.Tables[0]);
                dv.RowFilter = "";
                dataGridViewBook.DataSource = dv;
                showCopy();
            }
            else
            {
                DataSet ds = BookBL.SelectDS();
                DataView dv = new DataView(ds.Tables[0]);
                dv.RowFilter = "bookNumber = " + txtBookNumber.Text;
                dataGridViewBook.DataSource = dv;
                showCopy();
                txtAuthors.Text = "";
                txtTitle.Text = "";
                txtPublisher.Text = "";
            }
            
        }

        private void dataGridViewCopy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtCopyNumber.Text = dataGridViewCopy.Rows[e.RowIndex].Cells["copyNumber"].Value.ToString();
            txtBookNumber1.Text = dataGridViewCopy.Rows[e.RowIndex].Cells["bookNumber"].Value.ToString();
            txtSequenceNumber.Text = dataGridViewCopy.Rows[e.RowIndex].Cells["sequenceNumber"].Value.ToString();
            txtType.Text = dataGridViewCopy.Rows[e.RowIndex].Cells["type"].Value.ToString();
            txtPrice.Text = dataGridViewCopy.Rows[e.RowIndex].Cells["price"].Value.ToString();
        }

        private void buttonCAdd_Click(object sender, EventArgs e)
        {
            //Check selected book
            if (!isSelectedBook() && txtBookNumber.Text=="")
            {
                MessageBox.Show("Please select a Book to add copy for it!");
                return;
            }

            

            txtType.Enabled = true;
            txtPrice.Enabled = true;
            
            if (buttonCAdd.Text == "Finish")
            {
                //Check type:
                if (txtType.Text!="" && txtType.Text != "A" && txtType.Text != "R")
                {
                    txtType.Clear();
                    MessageBox.Show("Re-enter Type of Copy : 'A' or 'R'");
                    txtType.Focus();
                    return;
                }
                //Check price
                if (txtPrice.Text != "")
                {
                    float n;
                    bool isNum = float.TryParse(txtPrice.Text.Trim(), out n);
                    if (!isNum)
                    {
                        txtPrice.Clear();
                        MessageBox.Show("Wrong format, re-enter price!");
                        txtPrice.Focus();
                        return;
                    }
                }
               
                Copy c = new Copy();
                c.BookNumber = int.Parse(txtBookNumber1.Text);
                c.CopyNumber = int.Parse(txtCopyNumber.Text);
                c.SequenceNumber = int.Parse(txtSequenceNumber.Text);
                if(txtType.Text=="") c.Type=' ';
                else
                    c.Type = char.Parse(txtType.Text);
                if (txtPrice.Text == "") c.Price = 0;
                else
                    c.Price = float.Parse(txtPrice.Text);
                CopyBL.Insert(c);
                refreshCopy();

                buttonCAdd.Text = "Add";

                buttonBDelete.Enabled = true;
                buttonBAdd.Enabled = true;
                buttonFilter.Enabled = true;
                buttonBEdit.Enabled = true;
                buttonCDelete.Enabled = true;
                buttonCEdit.Enabled = true;

            }
            else
            {
                buttonCAdd.Text = "Finish";
                int max = ++CopyBL.copyNumberMax;
                txtCopyNumber.Text = max.ToString();

                CopyBL.SetSequenceNumberMax(int.Parse(txtBookNumber.Text));

                int maxS = ++CopyBL.sequenceNumberMax;
                txtSequenceNumber.Text = maxS.ToString();

                txtBookNumber1.Text = txtBookNumber.Text;
                txtType.Focus();

                buttonBDelete.Enabled = false;
                buttonBAdd.Enabled = false;
                buttonFilter.Enabled = false;
                buttonBEdit.Enabled = false;
                buttonCDelete.Enabled = false;
                buttonCEdit.Enabled = false;
            }
        }

        private void buttonCEdit_Click(object sender, EventArgs e)
        {
            

            if (!isSelectedCopy())
            {
                MessageBox.Show("Please select a copy to edit");
                return;
            }
            if (buttonCEdit.Text == "Finish")
            {
                Copy c = new Copy();
                c.BookNumber = int.Parse(txtBookNumber1.Text);
                c.CopyNumber = int.Parse(txtCopyNumber.Text);
                c.SequenceNumber = int.Parse(txtSequenceNumber.Text);
                c.Type = char.Parse(txtType.Text);
                c.Price = float.Parse(txtPrice.Text);
                CopyBL.Update(c);
                refreshCopy();

                buttonBDelete.Enabled = true;
                buttonBAdd.Enabled = true;
                buttonFilter.Enabled = true;
                buttonBEdit.Enabled = true;
                buttonCDelete.Enabled = true;
                buttonCAdd.Enabled = true;
            }
            else
            {
                buttonCEdit.Text = "Finish";
                txtType.Enabled = true;
                txtPrice.Enabled = true;
                buttonBDelete.Enabled = false;
                buttonBAdd.Enabled = false;
                buttonFilter.Enabled = false;
                buttonBEdit.Enabled = false;
                buttonCDelete.Enabled = false;
                buttonCAdd.Enabled = false;
            }
        }

        private void buttonCDelete_Click(object sender, EventArgs e)
        {
            if (!isSelectedCopy())
            {
                MessageBox.Show("Please select a copy to delete");
                return;
            }

            Copy c = new Copy();
            c.CopyNumber = int.Parse(dataGridViewCopy.SelectedRows[0].Cells["copyNumber"].Value.ToString());
            CopyBL.Delete(c);
            refreshCopy();
        }
    }
}
