﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab4_Group1.DTL;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Group1.DAL
{
    public class BookDA
    {
        public static DataSet SelectDS()
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("select * from Book", cn);
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

        public static bool Insert(Book b)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Insert into Book(bookNumber, title, authors, publisher)"+"values(@bookNumber, @title, @authors, @publisher)", cn);
                cmd.Parameters.AddWithValue("@bookNumber", b.BookNumber);
                cmd.Parameters.AddWithValue("@title", b.Title);
                cmd.Parameters.AddWithValue("@authors", b.Authors);
                cmd.Parameters.AddWithValue("@publisher", b.Publisher);

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

        public static bool Update(Book b)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Update Book set title = @title, "
                + "authors = @authors, publisher = @publisher where bookNumber = @bookNumber", cn);
                cmd.Parameters.AddWithValue("@bookNumber", b.BookNumber);
                cmd.Parameters.AddWithValue("@title", b.Title);
                cmd.Parameters.AddWithValue("@authors", b.Authors);
                cmd.Parameters.AddWithValue("@publisher", b.Publisher);

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

        public static bool Delete(Book b)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Delete Book where bookNumber = @bookNumber", cn);
                cmd.Parameters.AddWithValue("@bookNumber", b.BookNumber);

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


        public static int GetBookNumberMax()
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Select Max(bookNumber) as bookNumberMax from Book", cn);

                cn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                int bookNumberMax = 0;
                if (rd.Read())
                    bookNumberMax = int.Parse(rd["bookNumberMax"].ToString());
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
        public static bool isExistCode(int k)// check if code exist or not
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                string str = "Select title as Ten from Book where BookNumber= " + k;
                SqlCommand cmd = new SqlCommand(str, cn);
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    return true;
                }

                else { cn.Close(); return false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
    }
}
