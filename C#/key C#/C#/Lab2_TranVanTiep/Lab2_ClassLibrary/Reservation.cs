using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2_ClassLibrary
{
   public class Reservation
    {
        public Queue<int> borrowNum;
        public int booknumber;
        public DateTime date;
        public char status;

        public Reservation()
        { }

        public Reservation(Queue<int> xborrowNum,int xbooknumber, DateTime xdate, char xstatus)
        {
            borrowNum = xborrowNum;
            booknumber = xbooknumber;
            date = xdate;
            status = xstatus;
        }
    }
}