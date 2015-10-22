using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data; 


public partial class StudentByName : System.Web.UI.Page
{
    string connectionString = @"data source=(local); database= StudentDB; Integrated security=true";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "";

        if(CheckBox1.Checked == false)
        {
            sql = " select rollno, fullname, classcode " +
                   "from student where fullname like '% " + TextBox1.Text + "%' ";
        }
        else
        {
            sql = "select rollno, fullname, classcode from student ";
        }
        SqlDataAdapter sda = new SqlDataAdapter(sql, connectionString);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        Label1.Text = "Total Student(s): " + GridView1.Rows.Count;
    }
}