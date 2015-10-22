using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PE1 : System.Web.UI.Page
{
    string connectionString = @"data source=(local); database= StudentDB; Integrated security=true";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack == false)
        {
            string sql = "select * from Semester ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //if checkbox is checked
        string sql = "";
        if(CheckBox1.Checked == true)
        {
            sql = "select studentstatus.*, semester.name 'semester name' " +
                "from studentstatus, semester " +
                "where studentstatus.semesterid = semester.Id ";
        }
        else
        {
            sql = "select studentstatus.*, semester.name 'semester name' " +
                "from studentstatus, semester " +
                "where studentstatus.semesterid = semester.Id " +
                "and semester.Id = " + DropDownList1.SelectedValue;
        }
        SqlDataAdapter sda = new SqlDataAdapter(sql, connectionString);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        Label1.Text = "Total Student(s): " + GridView1.Rows.Count;
    }
}