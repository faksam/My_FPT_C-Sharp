using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AutoPostBackSample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //load all records from semester table to dropdownlist
            SqlDataAdapter sda = new SqlDataAdapter("Select * from semester", App.connectionString);
            DataSet dt = new DataSet();
            sda.Fill(dt, "semester");
            DropDownList1.DataSource = dt.Tables["semester"];
            DropDownList1.DataTextField = "Name";//column will be display
            DropDownList1.DataValueField = "Id";// pk of semester
            //commit binding
            DropDownList1.DataBind();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get the select value from dropdownlist
        string slcItem = DropDownList1.SelectedValue;
        slcItem = DropDownList1.SelectedItem.ToString();
        //display to label
       // Label1.Text = "You have selected: " + slcItem;
        string sqlSelect = "Select * from studentstatus where semesterid = "
            + slcItem;
        SqlDataAdapter sda = new SqlDataAdapter(sqlSelect, App.connectionString);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        //bind dt to gridview
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //display total students to label
        Label1.Text = "Total student(s): " + dt.Rows.Count;
    }
}