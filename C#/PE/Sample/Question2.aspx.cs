using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Question2 : System.Web.UI.Page
{
    static string strConn = @"Server=KHJ;Database=SampleExam;Integrated security=true";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Lay du lieu tu bang Color ve DataSet
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter("select * from Colors order by ColorName", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            //Gan du lieu cho DropDownList
           DropDownList1.DataSource = ds.Tables[0];

            //Hien theo column "ColorName"
           DropDownList1.DataTextField = "ColorName";

            //Gia tri thuc theo Column "ColorID"
           DropDownList1.DataValueField = "ColorID";

            //Thuc hien bind du lieu (chi voi WEB)
           DropDownList1.DataBind();

        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("INSERT INTO Flowers(FlowerName, ColorID, UnitPrice) " +
                "VALUES(@FlowerName, @ColorID, @UnitPrice)", conn);
            cmd.Parameters.AddWithValue("@FlowerName", TextBox1.Text);
            cmd.Parameters.AddWithValue("@ColorID", DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("@UnitPrice", double.Parse(TextBox2.Text));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Label1.Text = "Information of a new flower is addded!";
        }
        catch (Exception ex)
        {
            Label1.Text = "Can't add a new flower!";
        }

    }
}