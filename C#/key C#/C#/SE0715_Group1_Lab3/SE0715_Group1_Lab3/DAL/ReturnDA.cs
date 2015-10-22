﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using SE0715_Group1_Lab3.DTL;


namespace SE0715_Group1_Lab3.DAL
{
    public class ReturnDA
    {
        public string getName(int brNum)
        {
            try
            {
                SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
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

        public DataSet SelectDS(int brNum)
        {
            try
            {
                SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("select * from CirculatedCopy where borrowerNumber =" + brNum + "AND returnedDate is NULL", cn);
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

        public void returnUpdate(int copyNum)
        {
            try
            {
                string cm = "Update Copy set type = @type " + "where copyNumber = " + copyNum;

                SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
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

        public void cirUpdate(CirculatedCopy c)
        {
            try
            {
                string cm = "Update CirculatedCopy set returnedDate = @returnedDate, fineAmount = @fineAmount " + "where copyNumber = "
                            + c.CopyNumber + "AND ID =" + c.Id;

                SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(cm, cn);
                cmd.Parameters.AddWithValue("@returnedDate", c.ReturnedDate);
                cmd.Parameters.AddWithValue("@fineAmount", c.FineAmount);

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