using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Question2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strConn = "Server=KHJ;database=NorthWind;Integrated Security=true";
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter("select * from Employees order by FirstName", cn);
            da.Fill(ds);
            // Display Colors in DropDownList
            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataTextField = "FirstName";
            DropDownList1.DataValueField = "FirstName";

            DropDownList1.DataBind();
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string st = " select Birthdate from Employees";
        if (CheckBox1.Checked == false)
        {
            string strConn = "Server=KHJ;database=NorthWind;Integrated Security=true";
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter(st, cn);
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Label1.Text = GridView1.Rows.Count.ToString();
        }
        else
        {

            int i = int.Parse(DropDownList1.SelectedValue.ToString());
            string d = DropDownList1.SelectedItem.ToString();
            string strConn = "Server=KHJ;database=Northwind; Integrated Security = true";
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter(string.Format("select Lastname + ' ' + firstname from Employees = '{0}'", i), cn);
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        Button1_Click(null, null);
    }

}