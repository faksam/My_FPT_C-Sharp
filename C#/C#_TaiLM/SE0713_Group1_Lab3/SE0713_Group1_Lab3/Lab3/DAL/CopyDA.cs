using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3_Group1.DTL;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab3_Group1.DAL
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
            catch (System.Exception ex)
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
                SqlCommand cmd = new SqlCommand("Insert into Copy(copyNumber, bookNumber, sequenceNumber, type, price)"
                    + "values(@copyNumber, @bookNumber, @sequenceNumber, @type, @price)", cn);
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
            catch (System.Exception ex)
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
                SqlCommand cmd = new SqlCommand("Update Copy set bookNumber = @bookNumber, "
                + "sequenceNumber = @sequenceNumber, type = @type, price=@price where copyNumber = @copyNumber", cn);
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

        public static int GetCopyNumberMax()
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Select Max(copyNumber) as copyNumberMax from Copy", cn);

                cn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                int copyNumberMax = 0;
                if (rd.Read())
                    copyNumberMax = int.Parse(rd["copyNumberMax"].ToString());
                rd.Close();

                cn.Close();
                return copyNumberMax;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        public static int GetSequenceNumberMax(int bookNumber)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Select Max(sequenceNumber) as sequenceNumberMax from Copy where bookNumber="+bookNumber, cn);

                cn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                int sequenceNumberMax = 0;
                if (rd.Read())
                    sequenceNumberMax = int.Parse(rd["sequenceNumberMax"].ToString());
                rd.Close();

                cn.Close();
                return sequenceNumberMax;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return 0;
            }

        }

        public static bool updateStatus(int copyNumber)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Update Copy set type =@type where copyNumber = @copyNumber", cn);
                cmd.Parameters.AddWithValue("@type", "A");
                cmd.Parameters.AddWithValue("@copyNumber", copyNumber);

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
        public static bool isContainCopyNumber(int copyNumber)
        {
            SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
            string strcmd = "SELECT copyNumber as cpNumber FROM Copy WHERE copyNumber=" + copyNumber;
            SqlCommand cmd = new SqlCommand(strcmd, cn);
            cn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read()) return true;
            else return false;
            cn.Close();
        }
        public static char getTypeOfCopyNumber(int copyNumber)
        {
            SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
            string strcmd = "SELECT type as ty FROM Copy WHERE copyNumber=" + copyNumber;
            SqlCommand cmd = new SqlCommand(strcmd, cn);
            cn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read()) return char.Parse(rd["ty"].ToString());
            else return '\0';
            cn.Close();
        }
        public static int getBookNumber(int copyNumber)
        {
            SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
            string strcmd = "SELECT bookNumber as bkNumber FROM Copy WHERE copyNumber=" + copyNumber;
            SqlCommand cmd = new SqlCommand(strcmd, cn);
            cn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                return (int.Parse(rd["bkNumber"].ToString()));
            }
            else return -1;
            cn.Close();
        }
        public static void setTypeOfCopyNumber(int copyNumber, char ch)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Update Copy set type=@type where copyNumber = @copyNumber", cn);
                cmd.Parameters.AddWithValue("@type", ch);
                cmd.Parameters.AddWithValue("@copyNumber", copyNumber);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
