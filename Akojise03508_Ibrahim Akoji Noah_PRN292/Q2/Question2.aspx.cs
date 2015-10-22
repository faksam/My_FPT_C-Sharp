using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Question2 : System.Web.UI.Page
{
    string connectionString = "data source=IBRAHIM; database=Y12S3B1; integrated security=true";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //use distinct to remove duplicate value
            string sql = "select * from WaterHeaterTypes order by TypeName ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "TypeName";
            DropDownList1.DataValueField = "Typeid";
            DropDownList1.DataBind();
            //the message "Data is empty" will be displayed if gridview is empty
            GridView1.EmptyDataText = "Data is empty";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (CheckBox1.Checked == false)
            sql = "select TypeID, Capacity,Power, Material, Price from WaterHeaters";

        else
            sql = " select TypeID, Capacity,Power, Material, Price from WaterHeaters where typeid = " + DropDownList1.SelectedValue;
        SqlDataAdapter sda = new SqlDataAdapter(sql, connectionString);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        Label1.Text = "Number of Records:  " + GridView1.Rows.Count;
    }
}