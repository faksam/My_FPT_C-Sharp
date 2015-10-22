using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QuestionBankLibrary;
using System.Data;
using System.Data.SqlClient;//sql server 
namespace GUI
{
    class BOTopic
    {
        string conStr = null;

        public BOTopic()
        {
            conStr = "Server=localhost; Database=Question_Bank; Integrated Security= true";
        }

        //Add a topic to sql server
        public bool Add(Topic t)
        {
            //connect to DB
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            //save t into DB
            string sql = "INSERT INTO Topics (TopicID, TopicName) "+
                         "VALUES (@TopicID, @TopicName)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            //define query parameters
            cmd.Parameters.Add("TopicID", SqlDbType.NVarChar);
            cmd.Parameters.Add("TopicName", SqlDbType.NVarChar);
            //set value to parameters
            cmd.Parameters["TopicID"].Value = t.TopicID;
            cmd.Parameters["TopicName"].Value = t.TopicName;
            //execute query
            int ret=cmd.ExecuteNonQuery();
            con.Close();
            
            //return success status
            return ret == 1;
        }

        //Load all topic in sql server
        public List<Topic> ListAll()
        {
            List<Topic> list = new List<Topic>();
            //connect to DB
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            //Select all topics
            string sql = "SELECT * FROM Topics";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            //execute 
            SqlDataReader dr = cmd.ExecuteReader();
            //add to list
            while (dr.Read())
            {
                //create topic
                Topic t = new Topic();
                t.TopicID = dr["TopicID"].ToString();
                t.TopicName = dr["TopicName"].ToString();
                //add to list
                list.Add(t);
            }
            dr.Close();
            con.Close();
            return list;
        }

        //Delete a topic in sql server
        public bool Delete(string topicID)
        {
            //connect to DB
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            //delete t in DB
            using (SqlCommand cmd =
               new SqlCommand("DELETE FROM Topics WHERE TopicID = @TopicID", con))
            {
                //set value to parameters
                cmd.Parameters.AddWithValue("@TopicID", topicID);
                //execute query
                int ret = cmd.ExecuteNonQuery();
                con.Close();

                //return success status
                return ret == 1;
            }
        }

        //Update a topic in sql server
        public bool Update(Topic t, string oldTopicID)
        {
            //connect to DB
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            //update t in DB
            using (SqlCommand cmd =
               new SqlCommand("UPDATE Topics SET TopicID=@NewTopicID,  TopicName = @NewTopicName" +
                   " WHERE TopicID = @OldTopicID", con))
            {   
                //set value to parameters
                cmd.Parameters.AddWithValue("@NewTopicID", t.TopicID);
                cmd.Parameters.AddWithValue("@NewTopicName", t.TopicName);
                cmd.Parameters.AddWithValue("@OldTopicID", oldTopicID);
                //execute query
                int ret = cmd.ExecuteNonQuery();
                con.Close();

                //return success status
                return ret == 1;
            }
        }

        //public Topic Search(string topicID)
        //{
        //    return null;
        //}

        //public List<Topic> Search(string topicName)
        //{
        //    return null;
        //}
    }
}
