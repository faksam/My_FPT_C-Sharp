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
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        int countReservedBook(int x)
        {
            try
            {
                int k = 0;
              //  char sta = 'R';
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("select count(*) from Reservation bookNumber where borrowerNumber = @borrowerNumber and status = @status", cn);

                cmd.Parameters.AddWithValue("@borrowerNumber", x);
                cmd.Parameters.AddWithValue("@status", 'R');
                

                cn.Open();
                //cmd.ExecuteNonQuery();
                k = (int)cmd.ExecuteScalar();
                cn.Close();
                return k;
            }
            catch (Exception e)
            {
               
                return 0;
            }

        }
        Boolean isReservedBook(int x,int y)
        {
            try
            {
                int k = 0;
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("select count(*) from Reservation bookNumber where borrowerNumber = @borrowerNumber and bookNumber = @bookNumber and status = @status", cn);
                cmd.Parameters.AddWithValue("@borrowerNumber", x);
                cmd.Parameters.AddWithValue("@bookNumber", y);
                cmd.Parameters.AddWithValue("@status", 'R');

                cn.Open();
                
                k = (int)cmd.ExecuteScalar();
                cn.Close();
                if(k!=0)return true;
                else return false;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        Boolean isBook(int x)
        {
            int k = 0;

            DataSet ds = BookBL.SelectDS();

            DataView dv = new DataView(ds.Tables[0]);
            String rf = "bookNumber = " + x ;
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

        //check Member
        protected void btCheckMember_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (tbBorrowerNumber.Text != null)
            {
                x = int.Parse(tbBorrowerNumber.Text);
            }
            if (!isMember(x))
            {
                lbMemberError.Text = "This member is not registed!";
            }
            else
            {
                lbMemberError.Text = "";
                Borrower b = BorrowerBL.GetBorrower(x);
                tbname.Text = b.Name;
                lbReservedBook.Text ="The number of Reserved Book : "+ countReservedBook(x);
                GridView1.DataBind();
                btCheckCondition.Enabled = true;
            }
        }

        //check condition
        protected void Condition_Click(object sender, EventArgs e)
        {
            int bookNum = int.Parse(tbBookNumber.Text);
            int borrowerNum = int.Parse(tbBorrowerNumber.Text);
            Book b = BookBL.GetBook(bookNum);
            tbTitle.Text = b.Title;
            tbDate.Text = DateTime.Today.ToString("d");
            if (isBook(bookNum) && !isReservedBook(borrowerNum, bookNum))
            {
                lbConditionerror.Text = "";
                btReserve.Enabled = true;
                
                
            }
            else
            {
                if (!isBook(bookNum)) lbConditionerror.Text = "This book is not in Library!";
                if (isReservedBook(borrowerNum, bookNum)) lbConditionerror.Text = "You have already reserved this book!";
            }
        }

        //RESERVE
        protected void btServe_Click(object sender, EventArgs e)
        {
            int x = int.Parse(tbBorrowerNumber.Text);
            Reservation re = new Reservation();
            //re.Id = ReservationBL.idMax + 1;
            re.BorrowerNumber = int.Parse(tbBorrowerNumber.Text);
            re.BookNumber = int.Parse(tbBookNumber.Text);
            re.Date = DateTime.Today;
            re.Status = 'R';
            ReservationBL.Insert(re);

            lbReservedBook.Text = "The number of Reserved Book : " + countReservedBook(x);
            GridView1.DataBind();
            btReserve.Enabled = false;
        }

       
    }
}