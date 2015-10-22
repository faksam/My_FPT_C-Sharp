using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Q2
{
    public partial class Question2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strConn = "Server = localhost; database = Y12S2B3; Integrated Security = true";
                DataSet ds = new DataSet();
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("select * from ContactTitles order by ContactTitle", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                ddContact.DataSource = ds.Tables[0];
                ddContact.DataTextField = "ContactTitle";
                ddContact.DataValueField = "ContactTitleID";
                ddContact.DataBind();

            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string strConn = "Data Source=localhost;Initial Catalog=Y12S2B3;Integrated Security=True";
                    SqlConnection cn = new SqlConnection(strConn);
                    SqlDataAdapter da = new SqlDataAdapter("SELECT CustomerID, CompanyName, ContactName, ContactTitleID, Address, Phone, Fax" +
                        " FROM Customers ORDER BY ContactTitleID", cn);
                    da.Fill(ds);

                    DataView dv = new DataView(ds.Tables[0]);
                    gvContact.DataSource = dv;
                    gvContact.DataBind();
                    gvContact.Visible = true;
                    lbNumber.Text = "Number of Records: "+gvContact.Rows.Count.ToString();
                }
                catch (Exception)
                {

                    return;
                }
            }
            else
            {
                try
                {
                    
                    DataSet ds = new DataSet();
                    string strConn = "Data Source=localhost;Initial Catalog=Y12S2B3;Integrated Security=True";
                    SqlConnection cn = new SqlConnection(strConn);
                    SqlCommand cmd = new SqlCommand("SELECT CustomerID, CompanyName, ContactName, ContactTitleID, Address, Phone, Fax" +
                        " FROM Customers WHERE ContactTitleID=@ContactTitleID ORDER BY ContactTitleID", cn);
                    cmd.Parameters.AddWithValue("@ContactTitleID",ddContact.SelectedValue);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    
                    da.Fill(ds);

                    DataView dv = new DataView(ds.Tables[0]);
                    gvContact.DataSource = dv;
                    gvContact.DataBind();
                    gvContact.Visible = true;
                    lbNumber.Text = "Number of Records: " + gvContact.Rows.Count.ToString();
                }
                catch (Exception)
                {

                    return;
                }
            }

        }
    }
}