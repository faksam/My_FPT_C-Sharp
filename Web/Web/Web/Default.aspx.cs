using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; //datatable
using System.Data.SqlClient;//sqldataadapter

namespace Web
{
    public partial class _Default : System.Web.UI.Page
    {
        string connectionString = @"data source=IBRAHIM; database=StudentDB; integrated security=true;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                string sql = "select * from semester";
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
            string sql = "";
            if (CheckBox1.Checked == true)
            {
                sql = "select Student.RollNo, Class.ClassCode, Student.FullName, Student.Nationality, Class.Batch, Class.Major, Student.FullName, StudentStatus.SemesterNo, StudentStatus.Status " +
                      "from StudentStatus, Semester, Student, Class " +
                      "where StudentStatus.semesterid = semester.id " +
                      "and Student.RollNo = StudentStatus.RollNo " +
                      "and Student.ClassCode = Class.ClassCode ";
            }
            else
            {
                sql = "select Student.RollNo, Class.ClassCode, Student.FullName, Student.Nationality, Class.Batch, Class.Major, Student.FullName, StudentStatus.SemesterNo, StudentStatus.Status " +
                      "from StudentStatus, Semester, Student, Class " +
                      "where StudentStatus.semesterid = semester.id " +
                      "and Student.RollNo = StudentStatus.RollNo " +
                      "and Student.ClassCode = Class.ClassCode " +
                      "and Student.FullName like '%" + TextBox1.Text + "%' " +
                       "and Semester.id =  " + DropDownList1.SelectedValue.ToString() +
                       "and StudentStatus.Status =  '" + DropDownList2.SelectedItem.ToString() + "'" +
                       "and StudentStatus.SemesterNo = " + DropDownList3.SelectedItem.ToString();
            }
            SqlDataAdapter sda = new SqlDataAdapter(sql, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Label1.Text = "Total Student(s): " + GridView1.Rows.Count;
        }
    }
}