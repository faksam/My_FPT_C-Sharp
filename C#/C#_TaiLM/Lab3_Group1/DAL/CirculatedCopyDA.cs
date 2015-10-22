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
    class CirculatedCopyDA
    {
        public static DataSet SelectDS()
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source = KHJ; Initial Catalog = Library;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("select * from CirculatedCopy", cn);
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

        public static bool Insert(CirculatedCopy c)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                string str;
                if (c.ReturnedDate < c.BorrowedDate)
                {
                    str = "Insert into CirculatedCopy(copyNumber, borrowerNumber, borrowedDate, dueDate)"
                    + "values(@copyNumber, @borrowerNumber, @borrowedDate, @dueDate)";
                    SqlCommand cmd1 = new SqlCommand(str, cn);
                    cmd1.Parameters.AddWithValue("@copyNumber", c.CopyNumber);
                    cmd1.Parameters.AddWithValue("@borrowerNumber", c.BorrowerNumber);
                    cmd1.Parameters.AddWithValue("@borrowedDate", c.BorrowedDate);
                    cmd1.Parameters.AddWithValue("@dueDate", c.DueDate);
                    cn.Open();
                    cmd1.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Insert into CirculatedCopy(copyNumber, borrowerNumber, borrowedDate, dueDate, returnedDate, fineAmount)"
                   + "values(@copyNumber, @borrowerNumber, @borrowedDate, @dueDate, @returnedDate, @fineAmount)", cn);
                    cmd.Parameters.AddWithValue("@copyNumber", c.CopyNumber);
                    cmd.Parameters.AddWithValue("@borrowerNumber", c.BorrowerNumber);
                    cmd.Parameters.AddWithValue("@borrowedDate", c.BorrowedDate);
                    cmd.Parameters.AddWithValue("@dueDate", c.DueDate);
                    cmd.Parameters.AddWithValue("@returnedDate", c.ReturnedDate);
                    cmd.Parameters.AddWithValue("@fineAmount", c.FineAmount);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool Update(CirculatedCopy c)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Update CirculatedCopy set borrowerNumber = @borrowerNumber, "
                + "borrowedDate = @borrowedDate, dueDate = @dueDate, returnedDate=@returnedDate, fineAmount=@fineAmount, copyNumber = @copyNumber where id=@id", cn);
                cmd.Parameters.AddWithValue("@copyNumber", c.CopyNumber);
                cmd.Parameters.AddWithValue("@borrowerNumber", c.BorrowerNumber);
                cmd.Parameters.AddWithValue("@borrowedDate", c.BorrowedDate);
                cmd.Parameters.AddWithValue("@dueDate", c.DueDate);
                cmd.Parameters.AddWithValue("@returnedDate", c.ReturnedDate);
                cmd.Parameters.AddWithValue("@fineAmount", c.FineAmount);
                cmd.Parameters.AddWithValue("@id", c.Id);

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

        public static bool Delete(CirculatedCopy c)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Delete CirculatedCopy where copyNumber = @copyNumber", cn);
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
    }
}
