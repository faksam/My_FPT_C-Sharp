using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
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
        public List<Colors> GetAllColors()
        {
            List<Colors> cl = new List<Colors>();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlCmdSelect = new SqlCommand("select * from colors", sqlConn);
            sqlConn.Open();
            SqlDataReader r = sqlCmdSelect.ExecuteReader();
            while (r.Read())
            {
                //get data of current row
                int id = r.GetInt32(0);
                string name = r.GetString(1);
                Colors c = new Colors();
                c.ColorId = id;
                c.ColorName = name;
                cl.Add(c);
            }
            sqlConn.Close();
            return cl;
        }
        public bool InsertColor(Colors c)
        {
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            string sqlInsert = "insert into colors values(@colorName)";
            SqlCommand sqlCmdInsert = new SqlCommand(sqlInsert, sqlConn);
            sqlCmdInsert.Parameters.AddWithValue("@colorName", c.ColorName);
            int i = sqlCmdInsert.ExecuteNonQuery();
            sqlConn.Close();
            if (i != 0)
                return true;
            else
                return false;
        }
        public bool DeleteColor(int colorId)
        {
            return true;
        }
        public bool UpdateColor(Colors colorId)
        {
            return true;
        }
    }
}
