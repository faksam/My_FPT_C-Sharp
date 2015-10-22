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
  //            DataSet ds = ColorsDA.SelectDS();

                // Select Colors and order by ColorName
                string strConn = "Server = localhost; database = SampleExam; Integrated Security = true";
                DataSet ds = new DataSet();
                SqlConnection cn = new SqlConnection(strConn);
                SqlDataAdapter da = new SqlDataAdapter("select * from Colors order by ColorName", cn);
                da.Fill(ds);
 
                // Display Colors in DropDownList
                ddlColorID.DataSource = ds.Tables[0];
                ddlColorID.DataTextField = "ColorName";
                ddlColorID.DataValueField = "ColorID";
     
                ddlColorID.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
         /*   Flower f = new Flower();
            f.FlowerName = txtFlowerName.Text;
            f.UnitPrice = double.Parse(txtUnitPrice.Text);
            f.ColorID = int.Parse(ddlColorID.SelectedValue);

            if (FlowerDA.Insert(f))

                lblInfo.Text = "Information of a new flower is added!";*/

            try
            {
                string strConn = "Server = localhost; database = SampleExam; Integrated Security = true";
                SqlConnection cn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Insert into Flowers(FlowerName, ColorID, UnitPrice) Values(@FlowerName, @ColorID, @UnitPrice)", cn);
                cmd.Parameters.AddWithValue("@FlowerName", txtFlowerName.Text);
                cmd.Parameters.AddWithValue("@ColorId", int.Parse(ddlColorID.SelectedValue));
                cmd.Parameters.AddWithValue("@UnitPrice", double.Parse(txtUnitPrice.Text));


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                lblInfo.Text = "Information of a new flower is added!";
            }
            catch
            {
                lblInfo.Text = "Can't add a new flower!";
            
            }


        }

       
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn = "Server = localhost; database = SampleExam; Integrated Security = true";

                DataSet ds = new DataSet();
                SqlConnection cn = new SqlConnection(strConn);
                SqlDataAdapter da = new SqlDataAdapter("select * from Flowers", cn);
                da.Fill(ds);

                DataView dv = new DataView(ds.Tables[0]);
                dv.RowFilter = "FlowerName like '*" + txtFlower.Text + "*'";
                GridView1.DataSource = dv;
                GridView1.DataBind();

                lblInfo.Text = "List of flowers is loaded!";
            }
            catch
            {
                lblInfo.Text = "Can't search!";


            }

 
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            lblNo.Text = GridView1.Rows.Count.ToString();
        }
    }
}