using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace Question2
{
    public partial class Question2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sql = "Data Source=localhost;Initial Catalog=Y12S2B3;Integrated Security=True";
                DataSet ds = new DataSet();
                SqlConnection cn = new SqlConnection(sql);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Regions ORDER BY Region", cn);
                da.Fill(ds);
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "Region";
                ddl.DataValueField = "RegionID";
                ddl.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Data Source=localhost;Initial Catalog=Y12S2B3;Integrated Security=True";
            if (CheckBox1.Checked)
            {
                DataSet ds = new DataSet();
                SqlConnection cn = new SqlConnection(sql);
                SqlDataAdapter da = new SqlDataAdapter("SELECT CustomerID,CompanyName,ContactName,Customers.RegionID,PostalCode,Phone,Fax FROM Customers,Regions WHERE Customers.RegionID = Regions.RegionID AND Regions.RegionID =" + ddl.SelectedValue, cn);
                da.Fill(ds);

                DataView dv = new DataView(ds.Tables[0]);
                GridView1.DataSource = dv;
                GridView1.DataBind();
            }
            else
            {
                DataSet ds = new DataSet();
                SqlConnection cn = new SqlConnection(sql);
                SqlDataAdapter da = new SqlDataAdapter("SELECT CustomerID,CompanyName,ContactName,Customers.RegionID ,PostalCode,Phone,Fax FROM Customers,Regions WHERE Regions.RegionID =" + ddl.SelectedValue, cn);
                da.Fill(ds);

                DataView dv = new DataView(ds.Tables[0]);
                GridView1.DataSource = dv;
                GridView1.DataBind();
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            Label1.Text = GridView1.Rows.Count.ToString();
        }
    }
}