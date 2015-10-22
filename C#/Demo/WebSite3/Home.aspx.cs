using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Home : System.Web.UI.Page
{
    string connectionString = "data source = KHJ; database = SampleExam;integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (!IsPostBack)
            Response.Write("<h1>Welcome</h1>");
        else Response.Write("<h1>Welcome back</h1>");*/

        if (!IsPostBack)
        {
            SqlConnection sqlConn = new SqlConnection(connectionString);
            string sqlSelect = "select * from colors";
            SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, sqlConn);
            sqlConn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmdSelect);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Colors");
            //
            ddl_Color.DataSource = ds.Tables[0];
           // ddl_Color.DataBind();
            //
            ddl_Color.DataValueField = "ColorID";
            ddl_Color.DataTextField = "ColorName";
            ddl_Color.DataBind();
            sqlConn.Close();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection sqlConn = new SqlConnection(connectionString);
        string sqlSelect = "select * from Flowers where colorId=@colorId";
        SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, sqlConn);
        sqlConn.Open();
        //get selected color
        int colorId = int.Parse(ddl_Color.SelectedValue);
        //add parameter
        sqlCmdSelect.Parameters.AddWithValue("@colorId", colorId);
        SqlDataAdapter sda = new SqlDataAdapter(sqlCmdSelect);
        DataSet ds = new DataSet();
        sda.Fill(ds, "Flowers");
        //
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        sqlConn.Close();
    }
    protected void ddl_Color_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button2_Click(null, null);
    }
}