using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Lab4_Group1.DAL;

namespace Lab4_Group1.BLL
{
    class ReserveBL
    {
        public static DataSet SelectDS()
        {
            return ReservationDA.SelectDS();
        }

        public static int check(int memID,int booknum)
        {
            //BookNumber doesn't exist
            if (!BookDA.isExistCode(booknum)) return 2;

            //User has already reserved 1 book
            DataSet ds = ReservationDA.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "borrowerNumber=" + memID +"And status='R'";
            if (dv.Count > 0) return 3;

            //The still has available copy
            SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
            string str = "Select * from Copy where bookNumber= " + booknum +"And type='A'";
            SqlDataAdapter da = new SqlDataAdapter(str, cn);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            DataView dv1 = new DataView(ds1.Tables[0]);
            if(dv1.Count>0) return 4;

            //Book only referenced
            string str1 = "Select * from Copy where bookNumber ="+booknum +"And type in('A','B')";
            SqlDataAdapter da1 = new SqlDataAdapter(str1, cn);
            DataSet ds2 = new DataSet();
            da1.Fill(ds2);
            DataView dv2 = new DataView(ds2.Tables[0]);
            if (dv2.Count == 0) return 5;
            return 1;
        }
        
        public static bool isTheFirstReservation(int brNumber, int bookNumber)
        {
            return ReservationDA.isTheFirstReservater(brNumber, bookNumber);
        }
       
        public static void setStatusOfReservation(int brNumber, int bookNumber, char ch)
        {
            ReservationDA.setStatusOfReservation(brNumber, bookNumber, ch);
        }
    }
}
