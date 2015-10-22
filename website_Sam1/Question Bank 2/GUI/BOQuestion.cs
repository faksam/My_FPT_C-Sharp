using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QuestionBankLibrary;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;//

namespace GUI
{
    class BOQuestion
    {
        string conStr = null;

        public BOQuestion()
        {
            conStr = "Server=localhost; Database=Question_Bank; Integrated Security= true";
        }

        //Add a question to sql database
        public void Add(Question q)
        {
            //connect to DB
            SqlConnection con = new SqlConnection();
            //Transaction can do many sql command, if one of them fail, transaction will abort other commands
            SqlTransaction tran; 
            con.ConnectionString = conStr;
            con.Open();
            tran = con.BeginTransaction();

            try
            {
                //Insert to Questions table
                using (SqlCommand cmdq = new SqlCommand("INSERT INTO Questions (QuestionCode, Text, Mark, TopicID, Image)" +
                   "VALUES (@QuestionCode, @Text, @Mark, @TopicID, @Image)", con, tran))
                {
                    //set value to parameters
                    cmdq.Parameters.AddWithValue("@QuestionCode", q.Code);
                    cmdq.Parameters.AddWithValue("@Text", q.Text);
                    cmdq.Parameters.AddWithValue("@Mark", q.Code);
                    cmdq.Parameters.AddWithValue("@TopicID", getTopicID(q.Topic));

                    cmdq.Parameters.Add("@Image", SqlDbType.Image);
                    if (q.Image != null)
                        //cmdq.Parameters.AddWithValue("@Image", q.Image);
                        cmdq.Parameters["@Image"].Value = q.Image;
                    else
                        cmdq.Parameters["@Image"].Value = DBNull.Value;
                        //cmdq.Parameters.AddWithValue("@Image", DBNull.Value);
                        //cmdq.Parameters.AddWithValue("@Image", new byte[0]);

                    //execute query
                    cmdq.ExecuteNonQuery();
                }

                //Insert to Answers table
                for (int i = 0; i < q.Answers.Count; i++)
                {
                    using (SqlCommand cmda = new SqlCommand("INSERT INTO Answers (AnswerCode, QuestionCode, Text, IsCorrect) " +
                             "VALUES (@AnswerCode, @QuestionCode, @Text, @IsCorrect)", con, tran))
                    {
                        //set value to parameters
                        cmda.Parameters.AddWithValue("@AnswerCode", q.Code*10+i);
                        cmda.Parameters.AddWithValue("@QuestionCode", q.Code);
                        cmda.Parameters.AddWithValue("@Text", q.Answers[i].Text);
                        cmda.Parameters.AddWithValue("@IsCorrect",q.Answers[i].IsCorrect);

                        //execute query
                        cmda.ExecuteNonQuery();
                    }
                }
                tran.Commit();
                MessageBox.Show("Question is added sucessfully!");
            }
            catch (SqlException sqlError)
            {
                MessageBox.Show("Fail to add question\n"+sqlError.Message);
                tran.Rollback();
            }
            con.Close();
        }

        //Get TopicID of a question
        public string getTopicID(string topic)
        {
            string s = null;
            //connect to DB
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT TopicID FROM Topics WHERE TopicName = @Topic", con))
            {
                //set value to parameters
                cmd.Parameters.AddWithValue("@Topic", topic);

                //execute 
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())//PROBLEM: dr has no data
                {
                    s = dr["TopicID"].ToString();
                }
                dr.Close();
                con.Close();
                return s;
            }

            
        }

        //Get Topic of a question
        public string getTopic(string topicID)
        {
            string s = null;
            //connect to DB
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT TopicName FROM Topics WHERE TopicID = @TopicID", con))
            {
                //set value to parameters
                cmd.Parameters.AddWithValue("@TopicID", topicID);

                //execute 
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())//PROBLEM: dr has no data
                {
                    s = dr["TopicName"].ToString();
                }
                dr.Close();
                con.Close();
                return s;
            }
        }

        //Update a question in sql server
        public void Update(Question q, int oldCode)
        {
            //connect to DB
            SqlConnection con = new SqlConnection();
            //Transaction can do many sql command, if one of them fail, transaction will abort other commands
            SqlTransaction tran;
            con.ConnectionString = conStr;
            con.Open();
            tran = con.BeginTransaction();
            //delete q in DB
            try
            {
                //delete in Answers table
                using (SqlCommand cmd =
                   new SqlCommand("DELETE FROM Answers WHERE QuestionCode = @QuestionCode", con, tran))
                {
                    //set value to parameters
                    cmd.Parameters.AddWithValue("@QuestionCode", oldCode);
                    //execute query
                    cmd.ExecuteNonQuery();
                }
                //update in Questions table
                using (SqlCommand cmd =
               new SqlCommand("UPDATE Questions SET QuestionCode = @QuestionCode, Text = @Text, Mark = @Mark, TopicID = @TopicID" +
                   " WHERE QuestionCode = @OldQuestionCode", con, tran))
                {
                    //set value to parameters
                    cmd.Parameters.AddWithValue("@QuestionCode", q.Code);
                    cmd.Parameters.AddWithValue("@Text", q.Text);
                    cmd.Parameters.AddWithValue("@Mark", q.Mark);
                    cmd.Parameters.AddWithValue("@TopicID", getTopicID(q.Topic));
                    cmd.Parameters.AddWithValue("@OldQuestionCode", oldCode);
                    //execute query
                    cmd.ExecuteNonQuery();
                }
                //Insert to Answers table
                for (int i = 0; i < q.Answers.Count; i++)
                {
                    using (SqlCommand cmda = new SqlCommand("INSERT INTO Answers (AnswerCode, QuestionCode, Text, IsCorrect) " +
                             "VALUES (@AnswerCode, @QuestionCode, @Text, @IsCorrect)", con, tran))
                    {
                        //set value to parameters
                        cmda.Parameters.AddWithValue("@AnswerCode", q.Code * 10 + i);
                        cmda.Parameters.AddWithValue("@QuestionCode", q.Code);
                        cmda.Parameters.AddWithValue("@Text", q.Answers[i].Text);
                        cmda.Parameters.AddWithValue("@IsCorrect", q.Answers[i].IsCorrect);

                        //execute query
                        cmda.ExecuteNonQuery();
                    }
                }

                tran.Commit();
                MessageBox.Show("Question is updated!");
            }
            catch (SqlException sqlError)
            {
                MessageBox.Show("Fail to update question\n" + sqlError.Message);
                tran.Rollback();
            }
            con.Close();
        }

        //Delete a question in sql server
        public void Delete(Question q)
        {
            //connect to DB
            SqlConnection con = new SqlConnection();
            //Transaction can do many sql command, if one of them fail, transaction will abort other commands
            SqlTransaction tran;
            con.ConnectionString = conStr;
            con.Open();
            tran = con.BeginTransaction();
            //delete q in DB
            try
            {
                //delete in Answers table
                using (SqlCommand cmd =
                   new SqlCommand("DELETE FROM Answers WHERE QuestionCode = @QuestionCode", con, tran))
                {
                    //set value to parameters
                    cmd.Parameters.AddWithValue("@QuestionCode", q.Code);
                    //execute query
                    cmd.ExecuteNonQuery();
                }

                //delete in Questions table
                using (SqlCommand cmd =
                   new SqlCommand("DELETE FROM Questions WHERE QuestionCode = @QuestionCode", con, tran))
                {
                    //set value to parameters
                    cmd.Parameters.AddWithValue("@QuestionCode", q.Code);
                    //execute query
                    cmd.ExecuteNonQuery();
                }
                

                tran.Commit();
                MessageBox.Show("Question is deleted!");
            }catch (SqlException sqlError)
            {
                MessageBox.Show("Fail to delete question\n"+sqlError.Message);
                tran.Rollback();
            }
            con.Close();
        }

        //Load all questions in sql server
        public List<Question> ListAll()
        {
            List<Question> list = new List<Question>();
            //connect to DB
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            //Select all topics
            string sql = "SELECT * FROM Questions";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            //execute 
            SqlDataReader dr = cmd.ExecuteReader();
            //add to list
            while (dr.Read())
            {
                //create question
                Question q = new Question();
                q.Code = (int)dr["QuestionCode"];
                q.Text = dr["Text"].ToString();
                q.Mark = (double)dr["Mark"];
                q.Topic = getTopic(dr["TopicID"].ToString());
                if(dr["Image"]==DBNull.Value)
                    q.Image = null;
                else
                    q.Image = (byte[])dr["Image"];

                //add to list
                list.Add(q);
            }
            dr.Close();
            con.Close();
            return list;
        }
    }
}
