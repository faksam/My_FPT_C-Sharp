using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;



public partial class Index : System.Web.UI.Page
{
    SqlConnection sqlConn = null;
    string connectionString = WebConfigurationManager.ConnectionStrings["QLDiemConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*to do list
             * 1.read data from class to dataset
             * 2.bind dataset to dropdownlist as datasource
             * 
             * 
             * */
            sqlConn = new SqlConnection(connectionString);
            string sqlSelect = "select * from class";
            SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, sqlConn);
            sqlConn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmdSelect);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Class");
            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataTextField = "ClassCode";
            DropDownList1.DataValueField = "ClassCode";
            DropDownList1.DataBind();
            sqlConn.Close();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get selected class
           string classcode = DropDownList1.SelectedValue;
           sqlConn = new SqlConnection(connectionString);
        string sqlSelect = "select s.*, m.Mark, m.SubjectCode ";
        sqlSelect +=" from class c inner join student s on c.classcode = s.classcode ";
        sqlSelect +=" inner join mark m on m.RollNo = s.RollNo ";
        sqlSelect += " where c.ClassCode = @classcode order by s.rollno";
            //if DESC is checked 
            if(RadioButton2.Checked)
                sqlSelect += " DESC";
        SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, sqlConn);
        sqlConn.Open();
        //assign value to @classcode
        sqlCmdSelect.Parameters.AddWithValue("@classcode", classcode);
        SqlDataAdapter sda = new SqlDataAdapter(sqlCmdSelect);
        DataSet ds = new DataSet();
        sda.Fill(ds, "studentmark");
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        sqlConn.Close();

        //calculate avg
        int totalRow = GridView1.Rows.Count;
        //sum of mark
        double sum = 0;
        for (int i = 0; i < totalRow; i++)
        {
            double m = double.Parse(GridView1.Rows[i].Cells[7].Text);
            sum += m;
        }
        //if data is not empty
        if (totalRow > 0)
            Label1.Text = "Average mark(class): " + Math.Round((sum / totalRow),2);
        else
            Label1.Text = "No record found";
    }
protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
{
    //reload data and sorting if needed
    DropDownList1_SelectedIndexChanged(null, null);
}
protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
{
    DropDownList1_SelectedIndexChanged(null, null);
}
}