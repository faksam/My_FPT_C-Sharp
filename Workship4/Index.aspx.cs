using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Index : System.Web.UI.Page
{
    string connectionString = "Data Source=IBRAHIM;Initial Catalog=StudentDB;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string sql = "";
        //if checkbox is unchecked
        if (CheckBox1.Checked == false)
        {
            sql = "select  fullname, rollno, classcode " +
                  "from Student " +
                   "where FullName like '%" + TextBox1.Text + "%' ";
        }
        else
        {
            sql = "select  fullname, Student.RollNo, classcode, StudentStatus.Status " +
                 "from Student, StudentStatus " +

                "where Student.RollNo = StudentStatus.RollNo  " +
            "And FullName like '%" + TextBox1.Text + "%' ";

        }
        SqlDataAdapter sda = new SqlDataAdapter(sql, connectionString);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        Label1.Text = "Total Student(s): " + GridView1.Rows.Count;
    }
}