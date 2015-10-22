using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SE0715_Group1_Lab3.DTL;

namespace SE0715_Group1_Lab3.DAL
{
    public class BorrowDA
    {
        public DataSet SelectDS(int brNum)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=SampleExam;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("select ID,copyNumber,borrowerNumber,borrowedDate,dueDate from CirculatedCopy where borrowerNumber =" + brNum + "AND returnedDate is NULL", cn);
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

        public int GetIdMax()
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Select MAX(ID) as idMax from CirculatedCopy", cn);

                cn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                int bookNumberMax = 0;
                if (rd.Read())
                    bookNumberMax = int.Parse(rd["idMax"].ToString());
                rd.Close();

                cn.Close();

                return bookNumberMax;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }
        public void insertBorrow(CirculatedCopy a)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT [dbo].[CirculatedCopy] ON" + "\n" + "Insert into CirculatedCopy(ID, copyNumber, borrowerNumber, borrowedDate,dueDate,returnedDate,fineAmount) " +
                "values(@ID, @copyNumber,@borrowerNumber, @borrowedDate,@dueDate,NULL,NULL)", cn);

                cmd.Parameters.AddWithValue("@ID", a.Id);
                cmd.Parameters.AddWithValue("@copyNumber", a.CopyNumber);
                cmd.Parameters.AddWithValue("@borrowerNumber", a.BorrowerNumber);
                cmd.Parameters.AddWithValue("@borrowedDate", a.BorrowedDate);
                cmd.Parameters.AddWithValue("@dueDate", a.BorrowedDate.AddDays(14));
                //cmd.Parameters.AddWithValue("@returnedDate", null);
                //cmd.Parameters.AddWithValue("@fineAmount", 0);
                cn.Open();

                cmd.ExecuteNonQuery();
                cn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


        }

        public void borrowUpdate(int copyNum)
        {
            try
            {
                string cm = "Update Copy set type = @type " + "where copyNumber = " + copyNum;

                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(cm, cn);
                cmd.Parameters.AddWithValue("@type", 'B');


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public string getName(int brNum)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Select name as borrowerName from Borrower where borrowerNumber = " + brNum, cn);

                cn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                string a = "";
                if (rd.Read())
                    a = rd["borrowerName"].ToString();
                rd.Close();

                cn.Close();
                return a;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }


        public int getBoNum(int copyNum)
        {
            int a;
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Select bookNumber as bNum from Copy where copyNumber  = " + copyNum, cn);

                cn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                a = 0;
                if (rd.Read())
                    a = int.Parse(rd["bNum"].ToString());
                rd.Close();

                cn.Close();
                return a;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int getBrNum(int bNum)
        {
            int a;
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Select Top 1 borrowerNumber as brNum from Reservation where bookNumber  = " + bNum + "AND status = 'R'", cn);

                cn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                a = 0;
                if (rd.Read())
                    a = int.Parse(rd["brNum"].ToString());
                rd.Close();

                cn.Close();
                return a;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public void borrowReUpdate(int boNum, int brNum)
        {
            try
            {
                string cm = "Update Reservation set status = @type " + "where bookNumber = " + boNum + "AND borrowerNumber =" + brNum;

                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(cm, cn);
                cmd.Parameters.AddWithValue("@type", 'A');


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
