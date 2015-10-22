using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SE0715_Group1_Lab3.DTL;
using SE0715_Group1_Lab3.DAL;
using SE0715_Group1_Lab3.BLL;
using System.Data.SqlClient;

namespace SE0715_Group1_Lab3
{
    public partial class BookUI : Form
    {
        int AddSave = 0;//Add
        int EditSave = 0;
        int AddSaveCopy = 0;
        int EditSaveCopy = 0;
        public BookUI()
        {
            InitializeComponent();
            InitializeData();
            CopyInitializeData();
            txtCopyBookNumber.Enabled = false;
            txtCopyNumber.Enabled = false;
            txtSequenceNumber.Enabled = false;
            txtType.Enabled = false;
            txtPrice.Enabled = false;
        }
        public void InitializeData()
        {
            DataSet ds = BookBL.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            Book_BookTable.DataSource = dv;
            txtAuthors.Enabled = false;
            txtPublisher.Enabled = false;
            txtTitle.Enabled = false;
        }
        public void CopyInitializeData()
        {
            SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Select * from Copy", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataView dv = new DataView(ds.Tables[0]);
            dataGridView2.DataSource = dv;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!isSelected())
            {
                MessageBox.Show("Please select a book to edit");
                return;
            }
            if (EditSave == 0)
            {
                btnEdit.Text = "Save";
                txtBookNumber.Enabled = false; ;
                txtTitle.Enabled = true;
                txtPublisher.Enabled = true;
                txtAuthors.Enabled = true;
                btnDelete.Enabled = false;
                btnAdd.Enabled = false;
                button7.Enabled = false;
                EditSave = 1;//Save
            }
            else
            {
                int bookNum = int.Parse(txtBookNumber.Text);
                string title = txtTitle.Text.Trim();
                string author = txtAuthors.Text.Trim();
                string publisher = txtPublisher.Text.Trim();
                Book book = new Book(bookNum, title, author, publisher);
                try
                {
                    BookBL.Update(book);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                btnDelete.Enabled = true;
                btnAdd.Enabled = true;
                button7.Enabled = true;
                EditSave = 0;//Edit
                btnEdit.Text = "Edit";
                InitializeData();
            }

        }
        private bool isSelected()
        {
            if (Book_BookTable.SelectedRows.Count == 0)
                return false;
            if (Book_BookTable.SelectedRows[0].Cells["bookNumber"].Value == null) return false;
            return true;
        }
        private bool Grid2isSelected()
        {
            if (dataGridView2.SelectedRows.Count == 0)
                return false;
            if (dataGridView2.SelectedRows[0].Cells["copyNumber"].Value == null) return false;
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!isSelected())
            {
                MessageBox.Show("Please select a book to delete");
                return;
            }

            Book b = new Book();
            b.BookNumber = int.Parse(Book_BookTable.SelectedRows[0].Cells["bookNumber"].Value.ToString());
            DialogResult result = MessageBox.Show("Do you really want to delete this book", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                BookDA.DeleteAllCopy(b);
                BookBL.Delete(b);
            }
            else { }
            InitializeData();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (AddSave == 0)
            {
                btnAdd.Text = "Save";
                SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("SELECT MAX(bookNumber) FROM Book", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int Num = int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1;
                txtBookNumber.Enabled = false;
                txtBookNumber.Text = Num + "";
                txtTitle.Enabled = true;
                txtTitle.Text = "";
                txtPublisher.Enabled = true;
                txtPublisher.Text = "";
                txtAuthors.Enabled = true;
                txtAuthors.Text = "";
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                button7.Enabled = false;
                AddSave = 1;//Save
            }
            else
            {
                int bookNum = int.Parse(txtBookNumber.Text);
                string title = txtTitle.Text.Trim();
                string author = txtAuthors.Text.Trim();
                string publisher = txtPublisher.Text.Trim();
                Book book = new Book(bookNum, title, author, publisher);

                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                button7.Enabled = true;
                AddSave = 0;//Add
                btnAdd.Text = "Add";

                try
                {
                    BookBL.Insert(book);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                InitializeData();
                txtBookNumber.Enabled = true;
            }

        }

        public void loadSpecifiCopy(String cmd)
        {
            SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter(cmd, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataView dv = new DataView(ds.Tables[0]);
            dataGridView2.DataSource = dv;
        }


        private void Book_BookTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                String BookNumber=Book_BookTable.Rows[e.RowIndex].Cells["bookNumber"].Value.ToString();
                String cmd="Select * from Copy where bookNumber = "+BookNumber;
                loadSpecifiCopy(cmd);
                txtAuthors.Text=Book_BookTable.Rows[e.RowIndex].Cells["authors"].Value.ToString();
                txtBookNumber.Text=Book_BookTable.Rows[e.RowIndex].Cells["bookNumber"].Value.ToString();
                txtTitle.Text=Book_BookTable.Rows[e.RowIndex].Cells["title"].Value.ToString();
                txtPublisher.Text=Book_BookTable.Rows[e.RowIndex].Cells["publisher"].Value.ToString();
            } catch(Exception) {

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                txtCopyBookNumber.Text=dataGridView2.Rows[e.RowIndex].Cells["bookNumber"].Value.ToString();
                txtCopyNumber.Text=dataGridView2.Rows[e.RowIndex].Cells["copyNumber"].Value.ToString();
                txtSequenceNumber.Text=dataGridView2.Rows[e.RowIndex].Cells["sequenceNumber"].Value.ToString();
                txtType.Text=dataGridView2.Rows[e.RowIndex].Cells["type"].Value.ToString();
                txtPrice.Text=dataGridView2.Rows[e.RowIndex].Cells["price"].Value.ToString();
            } catch(Exception) {
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(txtBookNumber.Text.Trim() != "") {
                errorBook.Clear();
                DataSet ds=BookDA.Filter(txtBookNumber.Text.Trim());
                if(ds.Tables[0].Rows.Count==0) {
                    MessageBox.Show("Cannot found any book that has Book Number = "+txtBookNumber.Text);
                } else {
                    DataView dv=new DataView(ds.Tables[0]);
                    Book_BookTable.DataSource=dv;
                }
            } else {
                errorBook.SetError(txtBookNumber,"This field cannot be blank when filter");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isSelected())
            {
                MessageBox.Show("Please select book to add a copy");
                return;
            }
            else
            {
                if (AddSaveCopy == 0)
                {
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button2.Text = "Save";
                    
                    int Num = CopyDA.GetCopyNumberMax() + 1;
                    int Seq;
                    try
                    {
                        Seq = CopyDA.getSequenceMax(txtBookNumber.Text.Trim()) + 1;
                    }
                    catch (Exception)
                    {
                        Seq = 1;
                    }
                    txtCopyNumber.Text = Num + "";
                    txtCopyBookNumber.Text = txtBookNumber.Text;
                    txtCopyBookNumber.Enabled = false;
                    txtPrice.Enabled = true;
                    txtPrice.Text = "";
                    txtSequenceNumber.Enabled = false;
                    txtSequenceNumber.Text = Seq + "";
                    txtPrice.Enabled = true;
                    txtType.Text = "";
                    txtType.Enabled = true;
                    AddSaveCopy = 1;

                }
                else
                {
                    bool fail = false;
                    int BookNum = int.Parse(txtCopyBookNumber.Text);
                    int CopyNum = int.Parse(txtCopyNumber.Text);
                    int sequence = int.Parse(txtSequenceNumber.Text);
                    char type = new char();
                    try
                    {
                        type = char.Parse(txtType.Text);
                        errorBook.Clear();
                    }
                    catch (Exception)
                    {
                        fail = true;
                        errorBook.SetError(txtType, "Must be A or B or R");
                    }
                    if (type != 'A' && type != 'B' && type != 'R')
                    {
                        errorBook.SetError(txtType, "Must be A or B or R");
                        fail = true;
                    }
                    else{
                        errorBook.Clear();
                        fail = false;
                    }
                    double price = 0;
                    try
                    {
                        price = double.Parse(txtPrice.Text);
                    }
                    catch (Exception)
                    {
                        errorBook.SetError(txtPrice, "Price must be a digit");
                        fail = true;
                    }

                    Copy copy = new Copy(BookNum, CopyNum, sequence, type, price);
                    if (fail == false)
                    {
                        try
                        {
                            CopyBL.Insert(copy);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        button5.Enabled = true;
                        button6.Enabled = true;
                        txtPrice.Enabled = false;
                        txtType.Enabled = false;
                        AddSaveCopy = 0;//Add
                        button2.Text = "Add";
                        String cmd = "Select * from Copy where bookNumber = " + txtBookNumber.Text;
                        loadSpecifiCopy(cmd);
                    }
                    else { }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (!Grid2isSelected())
            {
                MessageBox.Show("Please select a copy to edit");
                return;
            }
            if (EditSaveCopy == 0)
            {
                button5.Text = "Save";
                button2.Enabled = false;
                button6.Enabled = false;
                txtPrice.Enabled = true;
                txtType.Enabled = true;
                EditSaveCopy = 1;//Save
            }
            else
            {
                bool fail = false;
                int BookNum = int.Parse(txtCopyBookNumber.Text);
                int CopyNum = int.Parse(txtCopyNumber.Text);
                int sequence = int.Parse(txtSequenceNumber.Text);
                char type = new char();
                try
                {
                    type = char.Parse(txtType.Text);
                    errorBook.Clear();
                }
                catch (Exception)
                {
                    fail = true;
                    errorBook.SetError(txtType, "Must be A or B or R");
                }
                if (type != 'A' && type != 'B' && type != 'R')
                {
                    errorBook.SetError(txtType, "Must be A or B or R");
                    fail = true;
                }
                else
                {
                    errorBook.Clear();
                    fail = false;
                }
                double price = 0;
                try
                {
                    price = double.Parse(txtPrice.Text);
                }
                catch (Exception)
                {
                    errorBook.SetError(txtPrice, "Price must be a digit");
                    fail = true;
                }

                Copy copy = new Copy(BookNum, CopyNum, sequence, type, price);
                if (fail == false)
                {
                    try
                    {
                        CopyBL.Update(copy);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    button2.Enabled = true;
                    button6.Enabled = true;
                    txtPrice.Enabled = false;
                    txtType.Enabled = false;
                    AddSaveCopy = 0;//Add
                    button5.Text = "Edit";
                    String cmd = "Select * from Copy where bookNumber = " + txtBookNumber.Text;
                    loadSpecifiCopy(cmd);
                }
                else { }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!Grid2isSelected())
            {
                MessageBox.Show("Please select a copy to delete");
                return;
            }

            Copy c = new Copy();
            c.CopyNumber = int.Parse(dataGridView2.SelectedRows[0].Cells["copyNumber"].Value.ToString());
            DialogResult result = MessageBox.Show("Do you really want to delete this copy", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CopyBL.Delete(c);
            }
            else { }
            String cmd = "Select * from Copy where bookNumber = " + txtBookNumber.Text;
            loadSpecifiCopy(cmd);
        }
    }
}
