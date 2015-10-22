using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Question2 : System.Web.UI.Page
{
    string connectionString = "Data Source=IBRAHIM;Initial Catalog=CNET_PE;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //use distinct to remove duplicate value
            string sql = "select distinct country from suppliers order by country";
            SqlDataAdapter sda = new SqlDataAdapter(sql, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "country";
            DropDownList1.DataValueField = "country";
            DropDownList1.DataBind();
            //the message "Data is empty" will be displayed if gridview is empty
            GridView1.EmptyDataText = "Data is empty";
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (CheckBox1.Checked == true)
            sql = "select * from suppliers";
        else
            sql = "select * from suppliers where country = '" + DropDownList1.SelectedValue.ToString() + "'";
        SqlDataAdapter sda = new SqlDataAdapter(sql, connectionString);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        Label1.Text = "Total record(s): " + GridView1.Rows.Count;
         
            
    }
}