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
            string sql = "select * from suppliers order by CompanyName";
            SqlDataAdapter sda = new SqlDataAdapter(sql, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "CompanyName";
            DropDownList1.DataValueField = "SupplierId";
            DropDownList1.DataBind();
            //the message "Data is empty" will be displayed if gridview is empty
            GridView1.EmptyDataText = "Data is empty";
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //get product name
        string pname = TextBox1.Text;
        //build sql
        string sql = "";
        if (CheckBox1.Checked == true)
            sql = "select * from Products where productname like '%"+pname+"%'";
        else
            sql = "select * from Products where SupplierId = '" +
                DropDownList1.SelectedValue.ToString() + "' and " +
                "productname like '%"+pname+"%'";
        SqlDataAdapter sda = new SqlDataAdapter(sql, connectionString);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        Label1.Text = "Total record(s): " + GridView1.Rows.Count;
         
            
    }
}