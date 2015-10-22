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
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataView dv;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strConn = "Server = localhost; database = Y12S2B1; Integrated Security = true";
                DataSet ds = new DataSet();
                SqlConnection cn = new SqlConnection(strConn);
                SqlDataAdapter da = new SqlDataAdapter("select * from Routes order by RouteName", cn);
                da.Fill(ds);

                // Display Colors in DropDownList
                DropDownList1.DataSource = ds.Tables[0];
                DropDownList1.DataTextField = "RouteName";
                DropDownList1.DataValueField = "RouteID";

                DropDownList1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string st = "select Routes.RouteName, TrainCodes.TrainCode,RailwayStations.StationName,TrainStops.ArrivalTime,TrainStops.DepartureTime from Routes join TrainCodes on Routes.RouteID=TrainCodes.RouteID join TrainStops on TrainStops.TrainCode=TrainCodes.TrainCode join RailwayStations on RailwayStations.StationID=TrainStops.StationID";
            if (CheckBox1.Checked == false)
            {
                string strConn = "Server = localhost; database = Y12S2B1; Integrated Security = true";
                DataSet ds = new DataSet();
                SqlConnection cn = new SqlConnection(strConn);
                SqlDataAdapter da = new SqlDataAdapter(st, cn);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Label2.Text = GridView1.Rows.Count.ToString();
            }
            else
            {

                int i = int.Parse(DropDownList1.SelectedValue.ToString());
                string d = DropDownList1.SelectedItem.ToString();
                string strConn = "Server = localhost; database = Y12S2B1; Integrated Security = true";
                DataSet ds = new DataSet();
                SqlConnection cn = new SqlConnection(strConn);
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select Routes.RouteName, TrainCodes.TrainCode,RailwayStations.StationName,TrainStops.ArrivalTime,TrainStops.DepartureTime from Routes join TrainCodes on Routes.RouteID=TrainCodes.RouteID join TrainStops on TrainStops.TrainCode=TrainCodes.TrainCode join RailwayStations on RailwayStations.StationID=TrainStops.StationID = '{0}'", i), cn);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}