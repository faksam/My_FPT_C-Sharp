using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Question2
{
    public class ColorsDA
    {
        public static DataSet SelectDS()
        {
            try
            {
                string strConn = "Server=localhost;database=SampleExam; Integrated Security=true";
                SqlConnection cn = new SqlConnection(strConn);

                SqlDataAdapter da = new SqlDataAdapter("select * from colors order by ColorName", cn);

                DataSet ds = new DataSet();

                da.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
                return null;
            }


        }
    }
}