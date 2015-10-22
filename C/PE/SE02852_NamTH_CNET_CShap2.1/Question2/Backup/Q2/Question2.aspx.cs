using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Q2
{
    public partial class Question2 : System.Web.UI.Page
    {

        Hashtable genreList;
        private SqlConnection GetConnection()
        {
            SqlConnection result = new SqlConnection();
            SqlConnectionStringBuilder connectString = new SqlConnectionStringBuilder();
            connectString.DataSource = "IBRAHIM";
            connectString.IntegratedSecurity = true;
            connectString.InitialCatalog = "Y12S1B3";
            result.ConnectionString = connectString.ToString();
            result.Open();
            return result;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cn = GetConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Genres", cn);
            da.Fill(dt);
            genreList = new Hashtable();
            foreach (DataRow row in dt.Rows)
            {
                int ID = int.Parse(row["GenreID"].ToString());
                String genre = row["GenreName"].ToString();
                genreList.Add(ID, genre);
                dropList.Items.Add(genre);
            }
            dropList.SelectedIndex = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            searchbox.Visible = true;
            if (cbGenre.Checked)
            {
                int genreID = 0;
                foreach (DictionaryEntry d in genreList)
                {
                    if (cbGenre.Text.CompareTo(d.Value.ToString()) == 0)
                    {
                        genreID = int.Parse(d.Key.ToString());
                    }
                }
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from ComputerGames where genreID=" + genreID, GetConnection());
                da.Fill(dt);
                nums.Text = dt.Rows.Count.ToString();
            }
            else
            {
                result0.Visible = true;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from ComputerGames", GetConnection());
                da.Fill(dt);
                nums.Text = dt.Rows.Count.ToString();
                result0.DataSource = dt;
            }
        }
    }
}
