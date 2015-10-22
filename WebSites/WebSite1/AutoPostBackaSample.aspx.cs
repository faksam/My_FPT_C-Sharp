using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;// sqlcommand, sqlConnection
using System.Data;// sqldtataAdapter, dataset

public partial class AutoPostBackaSample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //load all records form the semester table to dropdownlist1
            SqlDataAdapter sda = new SqlDataAdapter("select * from Semester", App.ConnectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Name";// column will be displayed
            DropDownList1.DataValueField = "Id";// PK of semester
            //commit binding
            DropDownList1.DataBind();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string slcItem = DropDownList1.SelectedValue;
        //slcItem = DropDownList1.SelectedItem.ToString();
        ////display to the lable
        //Label1.Text = "You have selected: " + slcItem;
        string sqlSelect = " select * from StudentStatus where SemesterId =" + slcItem;
        SqlDataAdapter sda = new SqlDataAdapter(sqlSelect, App.ConnectionString);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        //bind dt to gridview
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //Display total Student to Label1
        Label1.Text = "Total Student(s): " + dt.Rows.Count;

    }
}