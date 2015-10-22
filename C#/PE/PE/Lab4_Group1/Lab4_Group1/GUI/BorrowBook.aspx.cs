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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime borDay = DateTime.Now;
            DateTime dueDay = borDay.AddDays(14);
            tbBorrowDate.Text = borDay.ToString();
            tbDueDate.Text = dueDay.ToString();
        }
        Boolean isMember(int x)
        {
            int k = 0;
            
                DataSet ds = BorrowerBL.SelectDS();
                
                DataView dv = new DataView(ds.Tables[0]);
                String rf = "borrowerNumber = '" + x + "'";
                dv.RowFilter = rf;
               
                k =  dv.Count;
                
                if (k != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
          
        }

        Boolean isCopy(int x)
        {
            int k = 0;

            DataSet ds = CopyBL.SelectDS();

            DataView dv = new DataView(ds.Tables[0]);
            String rf = "copyNumber = '" + x + "'";
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(tbBorrowerNumber.Text);
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

        //check Condition
        protected void Button2_Click(object sender, EventArgs e)
        {

            int x = int.Parse(tbBorrowerNumber.Text);
            int y = int.Parse(tbCopyNumber.Text);
            
            if (isCopy(y))
            {
                Copy c = CopyBL.GetCopy(y);
                if (c.Type == 'A' || c.Type == 'a' && getNumberOf_BorroweredBook(x) < 5)
                {
                    lbConditionError.Text = "";
                    Button3.Enabled = true;
                }
                else
                {
                    if (c.Type != 'A') lbConditionError.Text = "This book is not available!";
                    if (getNumberOf_BorroweredBook(x) >= 5) lbConditionError.Text = "You have already borrowed 5 book!";
                }

            }
            else
            {
                lbConditionError.Text = "This Copy is not registed!";
            }

        }

        //Borrow a Copies
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                CirculatedCopy cir = new CirculatedCopy();
                CirculatedCopyBL.SetIDNumberMax();
                //cir.Id = CirculatedCopyBL.IDMax + 1;
                cir.CopyNumber = int.Parse(tbCopyNumber.Text);
                cir.BorrowerNumber = int.Parse(tbBorrowerNumber.Text);
                cir.BorrowedDate = DateTime.Today;
                cir.DueDate = DateTime.Today.AddDays(14);
                
                CirculatedCopyBL.Insert(cir);
                CopyBL.UpdateType(int.Parse(tbCopyNumber.Text), 'B');

                GridView1.DataBind();
                //viewBorrowedBook(cir.BorrowerNumber);
                lbBorrowedBook.Text = "The number of borrowed Book : " + getNumberOf_BorroweredBook(int.Parse(tbBorrowerNumber.Text));

                updateReservationStatus();
                Button3.Enabled = false;
            }
            catch (Exception ex)
            {
                lbConditionError.Text = ex.Message;
            }

        }

        // upate Reservation Status
        public void updateReservationStatus()
        {
            int bookNum;
            int borrowerNum = int.Parse(tbBorrowerNumber.Text);
            string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("select bookNumber from Copy where copyNumber = @copyNumber", cn);
            
            cmd.Parameters.AddWithValue("@copyNumber", int.Parse(tbCopyNumber.Text));
            

            cn.Open();
            bookNum = (int)cmd.ExecuteScalar();
            cn.Close();


            ReservationBL.UpdateStatus(borrowerNum, bookNum, 'A');



        }
        //view Borrowed Book
        void viewBorrowedBook(int x)
        {
            DataSet ds = CirculatedCopyBL.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            String rf = "borrowerNumber = '" + x + "'and returnedDate is null";
            dv.RowFilter = rf;
            GridView1.DataSource = dv;
            lbBorrowedBook.Text = "The number of borrowed Book : " + dv.Count;
            
        }
    }
}