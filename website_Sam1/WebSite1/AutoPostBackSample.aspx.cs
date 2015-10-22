using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AutoPostBackSample : System.Web.UI.Page
{
    DataView MyDataView = null;
    DataSet MyDataSet = new DataSet();
            
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack== false)
        {
            //load all records from semester tablt to dropdownlist1
            SqlDataAdapter sda = new SqlDataAdapter("Select * from semester", App.ConnectionString);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Name";//name of column to display
            DropDownList1.DataValueField = "Id";//pk of semester
            //commit binding
            DropDownList1.DataBind();

            Display();
            MyDataView = new DataView(MyDataSet.Tables["Student"]);
        }
        
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Display();
        MyDataView = new DataView(MyDataSet.Tables["Student"]);

        GridView1.DataSource = MyDataView;
        GridView1.DataBind();
        //display total students to label1
        Label1.Text = "Total number of student(s): " + GridView1.Rows.Count;
        Label2.Visible = Button1.Visible = TextBox1.Visible=true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            Display();
            
            MyDataView.RowFilter = "FullName like '%" + TextBox1.Text + "%'";
            GridView1.DataSource = MyDataView;
            GridView1.DataBind();
            Label1.Text = "Total number of student(s): " + GridView1.Rows.Count;
        }
    }

    public void Display()
    {
        string slcItem = DropDownList1.SelectedValue;
        SqlDataAdapter sda = new SqlDataAdapter("Select FullName,Student.RollNo,ClassCode,Status from Student,StudentStatus where semesterId = "
                                        + slcItem + "AND Student.RollNo=StudentStatus.RollNo", App.ConnectionString);
        sda.Fill(MyDataSet, "Student");
        MyDataView = new DataView(MyDataSet.Tables["Student"]);
    }
}