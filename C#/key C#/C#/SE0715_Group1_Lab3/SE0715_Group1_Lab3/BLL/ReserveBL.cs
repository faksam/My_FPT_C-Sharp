using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SE0715_Group1_Lab3.DAL;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SE0715_Group1_Lab3.BLL
{
    class ReserveBL
    {
        public static DataSet SelectDS()
        {
            return ReserveDA.SelectDS();
        }
        public static DataSet selectTableReservation(int borrowernum)
        {
            return ReserveDA.selectTableReservation(borrowernum);
        }
        public static bool checkReservation(int booknum, int borrowernum)
        {
            if (!new BorrowBL().checkMember(borrowernum))
            {
                MessageBox.Show("doesn't match with any menber ! Please try again.");
            }
            string cmd = "select * from Book where bookNumber = " + booknum;
            SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
            SqlDataAdapter da3 = new SqlDataAdapter(cmd, cn);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            if (ds3.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("doesn't match with any book ! Please try again.");
                return false;
            }
            else
            {
                cmd = "select * from Copy where bookNumber = " + booknum + "AND type =" + "'A'";
                SqlDataAdapter da = new SqlDataAdapter(cmd, cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("This book still has available copy book ! You cannot reserve this book !!");
                    return false;
                }
                else
                {
                    cmd = "select * from CirculatedCopy where borrowerNumber = " + borrowernum + " AND returnedDate is NULL";
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd, cn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 5)
                    {
                        MessageBox.Show("You just can borrow 5 book!!");
                        return false;
                    }
                    else
                    {
                        cmd = "select * from Reservation where borrowerNumber = " + borrowernum + "AND status != 'A'";

                        SqlDataAdapter da2 = new SqlDataAdapter(cmd, cn);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("You just can reserve only one book!");
                            return false;
                        }
                        return true;
                    }
                }
            }
        }
        public static int IDMax()
        {
            return ReserveDA.GetBookNumberMax();
        }
    }

}
