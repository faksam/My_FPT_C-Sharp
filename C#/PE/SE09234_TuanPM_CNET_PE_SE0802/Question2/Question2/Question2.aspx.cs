using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Question2
{
    public partial class Question2 : System.Web.UI.Page
    {
        String strConn = "Data Source=localhost;Initial Catalog=Y12S2B3;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(strConn);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from ContactTitles ORDER BY ContactTitle", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DropDownList1.DataSource = ds.Tables[0];
                DropDownList1.DataTextField = "ContactTitle";
                DropDownList1.DataValueField = "ContactTitleID";
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            Label2.Visible = true;
            String sqlStr = "";
            String a = DropDownList1.Text;
            if (CheckBox1.Checked)
            {
                sqlStr = "SELECT CustomerID, CompanyName, ContactName,Customers.ContactTitleID, Address, Phone, Fax FROM Customers, ContactTitles where Customers.ContactTitleID = ContactTitles.ContactTitleID  and Customers.ContactTitleID = " + DropDownList1.SelectedValue + "ORDER BY Customers.ContactTitleID ";
            }
            else
            {
                sqlStr = "SELECT CustomerID, CompanyName, ContactName,Customers.ContactTitleID, Address, Phone, Fax FROM Customers, ContactTitles where Customers.ContactTitleID = ContactTitles.ContactTitleID ORDER BY Customers.ContactTitleID";
            }

            SqlConnection cn = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            GridView1.DataSource = new DataView(ds.Tables[0]);
            GridView1.DataBind();
            
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            Label1.Text = GridView1.Rows.Count.ToString();
        }
    }
}