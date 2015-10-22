using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Assignment1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (IsPostBack == false)
        //{
        //    //load all records form the semester table to dropdownlist1
        //    SqlDataAdapter sda = new SqlDataAdapter("select * from Semester", App.ConnectionString);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    DropDownList1.DataSource = dt;
        //    DropDownList1.DataTextField = "Name";// column will be displayed
        //    DropDownList1.DataValueField = "Id";// PK of semester
        //    //commit binding
        //    DropDownList1.DataBind();
        //}

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    DataView dv;
    SqlDataAdapter sda;
    DataTable dt;
    DataSet ds = new DataSet();
    protected void Button1_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = 0;
        string slcItem = DropDownList1.SelectedItem.ToString();
        //slcItem = DropDownList1.SelectedItem.ToString();
        ////display to the lable
        //Label1.Text = "You have selected: " + slcItem;
        string sqlSelect = " select distinct Student.RollNo,FullName,ClassCode,Status from StudentStatus,Student,Semester where Student.RollNo= StudentStatus.RollNo and Name = '" + slcItem +"'";
        sda = new SqlDataAdapter(sqlSelect, App.ConnectionString);
        dt= new DataTable();
        sda.Fill(dt);
        //bind dt to gridview
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //Display total Student to Label1
        Label1.Text = "List All Students OF " + slcItem;
     
       
    }
   
   
    protected void Button2_Click(object sender, EventArgs e)
    {

        if (Page.IsPostBack)
        {
            


            DropDownList1.SelectedIndex = 0;
            string slcItem = DropDownList1.SelectedItem.ToString();
            //slcItem = DropDownList1.SelectedItem.ToString();
            ////display to the lable
            //Label1.Text = "You have selected: " + slcItem;
            string sqlSelect = " select distinct Student.RollNo,FullName,ClassCode,Status from StudentStatus,Student,Semester where Student.RollNo= StudentStatus.RollNo and Name = '" + slcItem + "' and FullName like '%" + TextBox1.Text + "%'";
            sda = new SqlDataAdapter(sqlSelect, App.ConnectionString);
            dt = new DataTable();
            sda.Fill(dt);
            //bind dt to gridview
            GridView1.DataSource = dt;
            GridView1.DataBind();
           



            //dv = new DataView(ds.Tables["Student"]);
            //dv.RowFilter = "FullName like '%" + TextBox1.Text + "%' ";
            //dv = new DataView();
            //GridView1.DataSource = dv;
            //GridView1.DataBind();
           

        }
    }
   
   
}