using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrjEntities;

namespace PrjDAL
{
    public class ColorsDAL
    {
        private string connectionString;
        public ColorsDAL(string connectionString)
        {
            this.connectionString = connectionString;

        }
        public List<Colors> GettAllColors
        {
            List<Colors> class = new  List<Colors>();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlCmdSelect = new SqlCommand("select *from colors", sqlConn);
            sqlConn.Open();
        SqlDataReader r = sqlCmdSelect.
        }
        public bool InsertColors(Colors c)
        {
            return true;
        }
        public bool DeleteColors(Colors c)
        {
            return true;
        }
        public bool UpdateColors(Colors c)
        {
            return true;
        }
    }
}
