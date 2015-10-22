using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab4_Group3.DTL;
using Lab4_Group3.BLL;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Lab4_Group3
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbReturnDate.Text = DateTime.Now.ToString();
        }

        Boolean isMember(int x)
        {
            int k = 0;

            DataSet ds = BorrowerBL.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            String rf = "borrowerNumber = '" + x + "'";
            dv.RowFilter = rf;

            k = dv.Count;
            if (k != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //number of borrowed Copies
        int getNumberOf_BorroweredBook(int x)
        {
            try
            {
                int k = 0;
                DataSet ds = CirculatedCopyBL.SelectDS();

                DataView dv = new DataView(ds.Tables[0]);
                String rf = "borrowerNumber = '" + x + "' AND returnedDate is null";
                dv.RowFilter = rf;

                k = dv.Count;
                return k;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }

        }

        //check Member
        protected void Button3_Click(object sender, EventArgs e)
        {
            int x = 0;
            if(tbBorrowerNumber.Text!=null)
            {
                x = int.Parse(tbBorrowerNumber.Text);

            }
            if (isMember(x))
            {
                lbMemberError.Text = "";
                DataSet ds = CirculatedCopyBL.SelectDS();
                DataView dv = new DataView(ds.Tables[0]);

                Borrower b = BorrowerBL.GetBorrower(x);
                tbName.Text = b.Name;
                lbBorrowedBook.Text = "The number of borrowed Book : " + getNumberOf_BorroweredBook(x);
            }
            else
            {
                lbMemberError.Text = "This member is not registed!";
            }
        }

        //Confirm fine
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                lbMemberError.Text = "Error: You must select a book!";
                return;
            }
            lbMemberError.Text = "";

            string borrowDate = GridView1.SelectedRow.Cells[4].Text;
            DateTime borDate = Convert.ToDateTime(borrowDate);
            DateTime retDate = Convert.ToDateTime(tbReturnDate.Text);
            TimeSpan tp = retDate - borDate;
            int fine = tp.Days;
            
            if (fine <= 14) tbFineAmount.Text = 0 + "";
            else tbFineAmount.Text = "" + (fine - 14);

            Button2.Enabled = true;
        }

        //Return
        protected void Button2_Click(object sender, EventArgs e)
        {
            int borNum = int.Parse(tbBorrowerNumber.Text);
            int id = int.Parse(GridView1.SelectedRow.Cells[1].Text);
            int fine = int.Parse(tbFineAmount.Text);

            //Update circulatedCopy
            string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("Update CirculatedCopy set returnedDate = @returnedDate ,"
            + "fineAmount = @fineAmount  where ID = @ID", cn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@returnedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@fineAmount", int.Parse(tbFineAmount.Text));
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            //Update Copy
            int copyNum = int.Parse(GridView1.SelectedRow.Cells[2].Text);
            CopyBL.UpdateType(copyNum,'A');

            GridView1.DataBind();
            Button2.Enabled = false;
            tbFineAmount.Text = "" + 0;
            lbBorrowedBook.Text = "The number of borrowed Book : " + getNumberOf_BorroweredBook(borNum);
        }
    }
}