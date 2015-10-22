using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//sqlcommand, sqlconnection
using System.Data.Sql;//sqldataadapter, dataset
using System.Data;


namespace Assignment
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request.QueryString["uid"];
            //get selected value from dropdownlist1
            string slcItem = name; //id of semester
            /*  slcItem = DropDownList1.SelectedItem.ToString(); //name of semester
              //display to label
              Label1.Text = "you have select" + slcItem;
             * */
            string sqlSelect = "select StudentStatus.RollNo, Student.FullName, Student.ClassCode, StudentStatus.Status from StudentStatus, Student " +
                                "where StudentStatus.RollNo = Student.RollNo " +
                                "and semesterid = " + slcItem;
            SqlDataAdapter sda = new SqlDataAdapter(sqlSelect, App.ConnectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //bind dt to gridview
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //display total students to label1
            // Label1.Text = "Total Student(s): " + dt.Rows.Count;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }
    }
}