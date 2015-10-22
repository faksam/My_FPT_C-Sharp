using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using SE0715_Group1_Lab4.DTL;
using SE0715_Group1_Lab4.DAL;
using SE0715_Group1_Lab4.DAL;
using System.Configuration;

namespace SE0715_Group1_Lab4.BLL
{
    public class BorrowBL
    {
        public int idMax;

        public void SetIdMax()
        {
            BorrowDA a = new BorrowDA();
            idMax = a.GetIdMax();
        }

        public bool checkMember(int memCode)
        {
            string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter("select * from Borrower where borrowerNumber = " + memCode, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else return true;

        }

        public bool checkCopy(int copyNum)
        {
            string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter("select * from Copy where copyNumber = " + copyNum + "AND type =" + "'A'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else return true;
        }

        public bool checkFive(int brNum)
        {
            string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter("select * from CirculatedCopy where borrowerNumber =" + brNum + "AND returnedDate is NULL", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 5)
            {
                return false;
            }
            else return true;
        }

        public bool checkReserve1(int copyNum)
        {
            BorrowDA a = new BorrowDA();
            int bN = a.getBoNum(copyNum);
            string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter("select * from Reservation where bookNumber =" + bN + "AND status = 'R'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count < 1)
            {
                return false;
            }
            return true;
        }

        public bool checkReserve(int copyNum, int boNum, int brNum)
        {
            //bool test = checkReserve1(copyNum);
            BorrowDA a = new BorrowDA();
            int k = a.getBrNum(boNum);
            if (k == brNum)
            {
                return true;

            }
            else return false;
        }

        public string showMemberName(int memCode)
        {
            string conn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter("select name from Borrower where borrowerNumber = " + memCode, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                return dr["name"].ToString();
            }
            return null;
        }

        internal static DataSet SelectDS()
        {
            return BorrowDA.SelectDS();
        }
    }
}

