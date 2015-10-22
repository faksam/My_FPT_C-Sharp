using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Question2
{
    public class FlowerDA
    {
        public static bool Insert(Flower f)
        {
            try
            {
                string strConn = "Server = localhost; database = SampleExam; Integrated Security=true";
                SqlConnection cn = new SqlConnection(strConn);

                SqlCommand cmd = new SqlCommand("Insert into Flowers(FlowerName, ColorID, UnitPrice) " +
                "Values(@FlowerName, @ColorID, @UnitPrice)", cn);

                cmd.Parameters.AddWithValue("@FlowerName", f.FlowerName);
                cmd.Parameters.AddWithValue("@ColorID", f.ColorID);
                cmd.Parameters.AddWithValue("@UnitPrice", f.UnitPrice);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
    }
}