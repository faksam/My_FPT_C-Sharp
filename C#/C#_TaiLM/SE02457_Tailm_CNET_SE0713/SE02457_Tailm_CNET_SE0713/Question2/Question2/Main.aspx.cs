using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Question2
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Label1.Visible = false;
                tbNumber.Visible = false;
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Y12S2B2;Integrated Security=True");
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select distinct SpinningSpeed from Washers", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DropDownListSpeed.DataSource = ds.Tables[0];
                DropDownListSpeed.DataTextField = "SpinningSpeed";
                DropDownListSpeed.DataValueField = "SpinningSpeed";
                DropDownListSpeed.DataBind();
                cn.Close();
            
            }                
        }

        protected void GridViewWashers_DataBound(object sender, EventArgs e)
        {
            tbNumber.Text = GridViewWashers.Rows.Count.ToString();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            tbNumber.Visible = true;
            SqlConnection cn2 = new SqlConnection("Data Source=localhost;Initial Catalog=Y12S2B2;Integrated Security=True");
            SqlDataAdapter da2 = new SqlDataAdapter("select washers.washerTypeID,Model, MakerName,capacity,spinningSpeed,price from Washers,washerTypes,makers where washers.washerTypeID=washerTypes.washerTypeID and washers.makerID = makers.makerID order by SpinningSpeed", cn2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            DataView dw = new DataView(ds2.Tables[0]); ;
            if (CheckBoxSelect.Checked)
            {                               
                dw.RowFilter = "SpinningSpeed = '" + DropDownListSpeed.SelectedValue.ToString()+"'";                
                GridViewWashers.DataSource = dw;
                GridViewWashers.DataBind();
            }
            else
            {
                GridViewWashers.DataSource = dw;
                GridViewWashers.DataBind();
            }
            cn2.Close();
        }
    }
}