using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{ 
    static string strConn = @"Server = IBRAHIM; Database = SampleExam; Integrated Security = true";
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
        string fn = TextBox1.Text;
        string up = TextBox2.Text;
        if(String.IsNullOrEmpty(fn))
        {
            MessageBox.Show("Please Enter Name Of Flower");
        }
        if(String.IsNullOrEmpty(up))
        {
            MessageBox.Show("Please Enter Unit Price...");
        }
        double pu = 0;
        if (double.TryParse(up, out pu) == false)
        {
            MessageBox.Show("Please a numberic");
            return;
        }
        if (pu < 0)
        {
            MessageBox.Show("must be greater than or equals to zero");
            return;
        }
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

               MessageBox.Show("Information of a new flower is addded!");
            }
                catch (Exception ex)
            {
               
            }





        

    }
}