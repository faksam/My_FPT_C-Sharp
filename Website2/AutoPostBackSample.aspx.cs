using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;//sqldataadapter, dataset

public partial class AutoPostBackSample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack == false)
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
}