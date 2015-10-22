using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using Lab4_Group3.DAL;
using Lab4_Group3.DTL;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Group3.BLL
{
    public class BorrowerBL
    {
        private static int borrowerNumberMax;

        public BorrowerBL()
        {
        }
        public static int BookNumberMax
        {
            get { return borrowerNumberMax; }
            set { borrowerNumberMax = value; }
        }

        public static DataSet SelectDS()
        {
            DataSet ds = BorrowerDA.SelectDS();
            if (ds == null) borrowerNumberMax = 0;
            else borrowerNumberMax = BorrowerDA.getBorrowerMax();
            return ds;
        }

        public static Borrower GetBorrower(int borrowerNumber)
        {
            return BorrowerDA.gerBorrower(borrowerNumber);
        }


        public static List<Borrower> SelectList()
        {
            DataSet ds = BorrowerDA.SelectDS();
            if (ds == null) return null;
            DataTable dt = ds.Tables[0];
            borrowerNumberMax = BorrowerDA.getBorrowerMax();
            List<Borrower> lb = new List<Borrower>();
            foreach (DataRow dr in dt.Rows)
            {
                lb.Add(new Borrower((int)dr["borrowerNumber"], (String)dr["name"], (String)dr["sex"], (String)dr["address"], (String)dr["telephone"], (String)dr["email"]));
            }
            return lb;
        }
        public static int getBorrowerNumberMax()
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Select Max(borrowerNumber) as borrowerNumberMax from Borrower", conn);

                conn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                int borrowerNumberMax = 0;
                if (rd.Read())
                    borrowerNumberMax = int.Parse(rd["borrowerNumberMax"].ToString());
                rd.Close();

                conn.Close();
                return borrowerNumberMax;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public static int countBorrower()
        {
            return BorrowerDA.countBorrower();
        }
       

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static bool Insert(Borrower b)
        {
            return BorrowerDA.Insert(b);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static bool Update(Borrower b)
        {
            return BorrowerDA.Update(b);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Borrower b)
        {
            return BorrowerDA.Delete(b);
        }

    }
}