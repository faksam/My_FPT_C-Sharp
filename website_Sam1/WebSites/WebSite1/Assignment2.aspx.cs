using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web;

public partial class Assignment2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conc = new SqlConnection(App.ConnectionString);
        // string st = "select * from Colors";
        SqlDataAdapter sqlda = new SqlDataAdapter("select * from Colors", conc);
        DataTable dat = new DataTable();
        sqlda.Fill(dat);
        DropDownList1.DataSource = dat;
        DropDownList1.DataTextField = "ColorName";
        DropDownList1.DataValueField = "ColorID";

        DropDownList1.DataBind();
        

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string price = TextBox2.Text;
        double p = 0;
        
       

        string flower = TextBox1.Text;
          if (string.IsNullOrEmpty(flower) && (Double.TryParse(price, out p)) == false)
        {
            changed_text.InnerHtml = "Please Enter a name of a Flower";
            Span1_text.InnerHtml = "Please Enter a unit price";
            return;
        }
          else if (TextBox1.Text.Equals(""))
          {

              changed_text.InnerHtml = "Please Enter a name of a Flower";
              Span1_text.InnerHtml = "";
              return;
          }

        else if (TextBox2.Text.Equals(""))
        {
            Span1_text.InnerHtml = "Please Enter a unit price";
            changed_text.InnerHtml = "";
            return;

        }      
        else if (Double.TryParse(TextBox2.Text,out p)==true && p <= 0)
        {
            Span1_text.InnerHtml = "Please Enter a unit price";
            changed_text.InnerHtml = "";
            return;
        }
        else
        {
            SqlConnection conc = new SqlConnection(App.ConnectionString);
            //string DBst = "insert into Flowers values(@FlowerName,@ColorID,@UnitPrice)";
            conc.Open();
           
            //col= DropDownList1.SelectedValue;
            string DBst = "insert into Flowers values(@v1,@v2,@v3)";
            SqlCommand cmd = new SqlCommand(DBst, conc);
            cmd.Parameters.AddWithValue("@v1", flower);
            cmd.Parameters.AddWithValue("@v2", DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("@v3",p );

            cmd.ExecuteNonQuery();
            conc.Close();
            changed_text.InnerHtml = "";
            Span1_text.InnerHtml = "";
            Span2_text.InnerHtml = "Flower Info has been Saved.";
            
        }
        
    }
}