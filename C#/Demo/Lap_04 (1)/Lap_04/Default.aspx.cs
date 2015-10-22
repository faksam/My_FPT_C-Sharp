using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    string connectionString = @"data source=KHJ;database=QLDiem;integrated security=true";
    SqlConnection sqlConn = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string temp = TextBox1.Text;
            if (!string.IsNullOrEmpty(temp))
            {
                sqlConn = new SqlConnection(connectionString);
                string sqlSelect = "select s.RollNo,s.FullName,c.ClassCode,c.TimeSlot ";
                sqlSelect += " from Class c inner join Student s on c.ClassCode = s.ClassCode ";

                //if (!CheckBox1.Checked)
                //sqlSelect += " DESC";

                SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, sqlConn);
                sqlConn.Open();

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmdSelect);
                DataSet ds = new DataSet();
                sda.Fill(ds, "student");
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                sqlConn.Close();

                //Calculate avg
                int totalRow = GridView1.Rows.Count;
                for (int i = 0; i < totalRow; i++)

                    if (totalRow > 0)
                        Label2.Text = "Total students: " + totalRow.ToString();
                    else
                        Label2.Text = "No record found";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string fullName = TextBox1.Text;
        if (!string.IsNullOrEmpty(fullName))
        {

            sqlConn = new SqlConnection(connectionString);
            string sqlSelect = "select s.RollNo,s.FullName,s.BirthDate,c.ClassCode,c.TimeSlot ";
            sqlSelect += " from Class c inner join Student s on c.ClassCode = s.ClassCode ";
            sqlSelect += " where s.FullName like '%" + fullName + "%'";


            //if (!CheckBox1.Checked)
            //sqlSelect += " DESC";

            SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, sqlConn);
            sqlConn.Open();

            SqlDataAdapter sda = new SqlDataAdapter(sqlCmdSelect);
            DataSet ds = new DataSet();
            sda.Fill(ds, "student");
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            int totalRow1 = GridView1.Rows.Count;
            if (totalRow1 < 1)
            {
                Label3.Text = "Not Match";
                return;
            }
            sqlConn.Close();

            //Calculate avg
            if (CheckBox1.Checked == false)
            {
                int totalRow = GridView1.Rows.Count;
                for (int i = 0; i < totalRow; i++)

                    if (totalRow > 0)
                        Label2.Text = "Total students: " + totalRow.ToString();
                    else
                        Label2.Text = "No record found";
            }
            else
            {
                //Calculate avg
                int totalRow = GridView1.Rows.Count;
                double sum = 0;
                for (int i = 0; i < totalRow; i++)
                {
                    double m = double.Parse(GridView1.Rows[1].Cells[7].Text);
                    sum += m;
                }
                if (totalRow > 0)
                    Label2.Text = "Average mark: " + Math.Round((sum / totalRow), 2);
                else
                    Label1.Text = "No record found";
            }
        }
        else
        {

            sqlConn = new SqlConnection(connectionString);
            string sqlSelect = "select s.RollNo,s.FullName,c.ClassCode,c.TimeSlot ";
            sqlSelect += " from Class c inner join Student s on c.ClassCode = s.ClassCode ";

            //if (!CheckBox1.Checked)
            //sqlSelect += " DESC";

            SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, sqlConn);
            sqlConn.Open();

            SqlDataAdapter sda = new SqlDataAdapter(sqlCmdSelect);
            DataSet ds = new DataSet();
            sda.Fill(ds, "student");
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            sqlConn.Close();

            //Calculate avg
            int totalRow = GridView1.Rows.Count;
            for (int i = 0; i < totalRow; i++)

                if (totalRow > 0)
                    Label2.Text = "Total students: " + totalRow.ToString();
                else
                    Label2.Text = "No record found";
        }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        string fullName = TextBox1.Text;
        sqlConn = new SqlConnection(connectionString);
        string sqlSelect = "select s.RollNo,s.FullName,s.BirthDate,c.ClassCode,c.TimeSlot,m.SubjectCode,m.Mark ";
        sqlSelect += " from Class c inner join Student s on c.ClassCode = s.ClassCode ";
        sqlSelect += " join Mark m on m.RollNo = s.RollNo";
        sqlSelect += " where s.FullName like '%" + fullName + "%'";


        //if (!CheckBox1.Checked)
        //sqlSelect += " DESC";

        SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, sqlConn);
        sqlConn.Open();

        SqlDataAdapter sda = new SqlDataAdapter(sqlCmdSelect);
        DataSet ds = new DataSet();
        sda.Fill(ds, "student");
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        sqlConn.Close();


            //Calculate avg
            int totalRow = GridView1.Rows.Count;
            double sum = 0;
            for (int i = 0; i < totalRow; i++)
            {
                double m = double.Parse(GridView1.Rows[i].Cells[6].Text);
                sum += m;
            }
            if (totalRow > 0)
                Label2.Text = "Average mark: " + Math.Round((sum / totalRow), 2);
            else
                Label1.Text = "No record found";
        
    }
}