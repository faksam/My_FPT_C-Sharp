using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using SE0715_Group1_Lab3.DTL;
using SE0715_Group1_Lab3.DAL;

namespace SE0715_Group1_Lab3.BLL
{
    public class ReturnBL
    {

        public bool checkMember(int memCode)
        {

            string cmd = "select * from Borrower where borrowerNumber = " + memCode;

            SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter(cmd, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else return true;

        }


    }
}
