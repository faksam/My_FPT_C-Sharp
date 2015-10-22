using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QuestionBankLibrary;
using System.Data;
using System.Data.SqlClient;

namespace GUI
{
    class BOAnswer
    {
         string conStr = null;

        public BOAnswer()
        {
            conStr = "Server=localhost; Database=Question_Bank; Integrated Security= true";
        }

        //Add an answer to sql server
        public bool Add(Answer a)
        {
            //connect to DB
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            //save t into DB
            string sql = "INSERT INTO Answers (AnswerCode, QuestionCode, Text, IsCorrect) "+
                         "VALUES (@AnswerCode, @QuestionCode, @Text, @IsCorrect)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            //define query parameters
            cmd.Parameters.Add("AnswerCode", SqlDbType.Int);
            cmd.Parameters.Add("QuestionCode", SqlDbType.Int);
            cmd.Parameters.Add("Text", SqlDbType.NVarChar);
            cmd.Parameters.Add("IsCorrect", SqlDbType.Bit);
            //set value to parameters
            cmd.Parameters["AnswerCode"].Value = a.Code;
            cmd.Parameters["QuestionCode"].Value = a.QCode;
            cmd.Parameters["Text"].Value = a.Text;
            cmd.Parameters["IsCorrect"].Value = a.IsCorrect;
            //execute query
            int ret=cmd.ExecuteNonQuery();
            con.Close();
            
            //return success status
            return ret == 1;
        }

        //Load all answer in sql server
        public List<Answer> ListAll()
        {
            List<Answer> list = new List<Answer>();
            //connect to DB
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            //Select all topics
            string sql = "SELECT * FROM Answers";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            //execute 
            SqlDataReader dr = cmd.ExecuteReader();
            //add to list
            while (dr.Read())
            {
                //create topic
                Answer a = new Answer();
                a.Code = (int)dr["AnswerCode"];
                a.QCode = (int)dr["QuestionCode"];
                a.Text = dr["Text"].ToString();
                a.IsCorrect = (bool)dr["IsCorrect"];
                //add to list
                list.Add(a);
            }
            dr.Close();
            con.Close();
            return list;
        }
    }
}
