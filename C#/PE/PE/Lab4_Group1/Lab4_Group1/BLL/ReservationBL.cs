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
    public class ReservationBL
    {
        public static int idMax;
        public static DataSet SelectDS()
        {
            setIDMax();
            return ReservationDA.SelectDS();
        }
        public static void setIDMax()
        {
            idMax = ReservationDA.GetIDMax();
        }

        public static bool Insert(Reservation re)
        {
            return ReservationDA.Insert(re);
        }

        public static bool Update(Reservation re)
        {
            return ReservationDA.Update(re);
        }

        public static bool Delete(Reservation re)
        {
            return ReservationDA.Delete(re);
        }
        public static bool UpdateStatus(int borrowerNumber, int bookNumber, char status)
        {
            return ReservationDA.updateStatus(borrowerNumber, bookNumber, status);
        }
    }
}