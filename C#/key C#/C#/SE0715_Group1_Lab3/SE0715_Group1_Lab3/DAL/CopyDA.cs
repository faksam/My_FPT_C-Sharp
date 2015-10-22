using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SE0715_Group1_Lab3.DTL;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace SE0715_Group1_Lab3.DAL
{
    class CopyDA
    {
        public static DataSet SelectDS()
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("select * from Copy", cn);
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

        public static bool Insert(Copy c)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Insert into Copy(copyNumber, bookNumber, sequenceNumber, type, price) " +
                "values(@copyNumber, @bookNumber, @sequenceNumber, @type, @price)", cn);
                cmd.Parameters.AddWithValue("@copyNumber", c.CopyNumber);
                cmd.Parameters.AddWithValue("@bookNumber", c.BookNumber);
                cmd.Parameters.AddWithValue("@sequenceNumber", c.SequenceNumber);
                cmd.Parameters.AddWithValue("@type", c.Type);
                cmd.Parameters.AddWithValue("@price", c.Price);

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

        public static bool Update(Copy c)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Update Copy set sequenceNumber = @sequenceNumber, "
                + "type = @type,bookNumber = @bookNumber,price = @price where copyNumber = @copyNumber", cn);
                cmd.Parameters.AddWithValue("@copyNumber", c.CopyNumber);
                cmd.Parameters.AddWithValue("@type", c.Type);
                cmd.Parameters.AddWithValue("@price", c.Price);
                cmd.Parameters.AddWithValue("@sequenceNumber", c.SequenceNumber);
                cmd.Parameters.AddWithValue("@bookNumber", c.BookNumber);

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

        public static bool Delete(Copy c)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Delete Copy where copyNumber = @copyNumber", cn);
                cmd.Parameters.AddWithValue("@copyNumber", c.CopyNumber);

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
        public static int getSequenceMax(String s) {

            SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
            SqlDataAdapter da=new SqlDataAdapter("select MAX(sequenceNumber) FROM Copy where bookNumber = "+s, cn);
            DataSet ds2=new DataSet();
            da.Fill(ds2);
            int Seq=int.Parse(ds2.Tables[0].Rows[0][0].ToString());
            return Seq;
        }
        public static int GetCopyNumberMax() {
            try {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd=new SqlCommand("Select Max(copyNumber) as copyNumberMax from Copy", cn);

                cn.Open();

                SqlDataReader rd=cmd.ExecuteReader();
                int copyMax=0;
                if(rd.Read())
                    copyMax=int.Parse(rd["copyNumberMax"].ToString());
                rd.Close();

                cn.Close();
                return copyMax;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

    }
}
