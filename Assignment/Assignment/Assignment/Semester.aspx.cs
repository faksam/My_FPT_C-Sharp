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
    public partial class Semester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                //load all records from semester table to dropdowlist1
                SqlDataAdapter sda = new SqlDataAdapter("select * from semester",
                    App.ConnectionString);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "Name"; //column will be displayed
                DropDownList1.DataValueField = "Id"; //PK of Semester
                //commit binding
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        //move to page Index.aspx
        Response.Redirect("Student.aspx?uid= " + DropDownList1.Text);
       
    }
        }
    }
