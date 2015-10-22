using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    string connectionString = "Data Source=IBRAHIM;Initial Catalog=CNET_PE;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        /*
         * get values of textbox1(fromprice) and textbox2(toprice)
         * if fromprice and toprice are numbers
         * select * from products where Unitprice >=10 and Unitprice <= 20
         * select * from products where  Unitprice <= 20
            select * from products where Unitprice >=10 
            select * from products
         */
        //1
        string fvalue = TextBox1.Text;
        string svalue = TextBox2.Text;
        string Sql = "";
        //2
        double fromprice = 0, toprice = 0;
        if(double.TryParse(fvalue, out fromprice) == true && 
            double.TryParse(svalue, out toprice) == true)
        {
            Sql = "select * from products where Unitprice >= "+fromprice+" and Unitprice <=" + toprice;
        }
        else if (double.TryParse(fvalue, out fromprice) == false &&
           double.TryParse(svalue, out toprice) == true)
        {
            Sql = "select * from products where Unitprice >= " + fromprice;
        }
        else if (double.TryParse(fvalue, out fromprice) == true &&
           double.TryParse(svalue, out toprice) == false)
        {
            Sql = "select * from products where Unitprice >= " + fromprice;
        }
        else
        {
            Sql = " select * from products ";
        }
        SqlDataAdapter sda = new SqlDataAdapter(Sql, connectionString);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //dissplay total records
        Label1.Text = "Total record(s): " + GridView1.Rows.Count;
    }
}