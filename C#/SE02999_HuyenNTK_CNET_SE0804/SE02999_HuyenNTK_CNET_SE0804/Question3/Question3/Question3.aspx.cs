using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Question3
{
    public partial class Question3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strConn = "Server=KHJ; database=PE0503; Integrated Security = true";
                DataSet ds = new DataSet();
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("select * from AssetTypes order by AssetTypeName", cn);
                SqlCommand cmd2 = new SqlCommand("select * from Companies order by companyName", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                DropDownList1.DataSource = ds.Tables[0];
                DropDownList1.DataTextField = "AssetTypeName";
                DropDownList1.DataValueField = "AssetTypeID";
                DropDownList1.DataBind();

                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                da.Fill(ds);
                DropDownList2.DataSource = ds.Tables[0];
                DropDownList2.DataTextField = "companyName";
                DropDownList2.DataValueField = "companyID";
              //  DropDownList2.DataBind();
                
            }
        }
    }
}