using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class Index : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    SqlConnection sqlConn = null;
    string connectionString = WebConfigurationManager.ConnectionStrings["QLDiemConnection"].ConnectionString;

    protected void Button1_Click(object sender, EventArgs e)
    {
        string fullName = TextBox1.Text;
        string sqlSelect = "";
        if (CheckBox1.Checked)
        {

            sqlSelect = "select s.RollNo,s.FullName,s.BirthDate,c.ClassCode,c.TimeSlot,m.SubjectCode,m.Mark ";
            sqlSelect += " from Class c inner join Student s on c.ClassCode = s.ClassCode ";
            sqlSelect += " inner join Mark m on m.RollNo = s.RollNo ";
            sqlSelect += " where s.FullName like '%" + fullName + "%'";

        }
        else
        {
            sqlSelect = "select s.RollNo,s.FullName,s.BirthDate,c.ClassCode,c.TimeSlot ";
            sqlSelect += " from Class c inner join Student s on c.ClassCode = s.ClassCode ";
            sqlSelect += " where s.FullName like '%" + fullName + "%'";
        }
        sqlConn = new SqlConnection(connectionString);
        SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, sqlConn);
        sqlConn.Open();
        SqlDataAdapter sda = new SqlDataAdapter(sqlCmdSelect);
        DataSet ds = new DataSet();
        sda.Fill(ds, "studentmark");
        GridView1.DataSource = ds.Tables["studentmark"];
        GridView1.DataBind();
        sqlConn.Close();
        //get total rows
        int totalRow = ds.Tables["studentmark"].Rows.Count;
        if (totalRow > 0)
        {
            if (CheckBox1.Checked)
            {
                double sum = 0;
                    for (int i = 0; i < totalRow; i++)
                     {
                        double m = double.Parse(GridView1.Rows[i].Cells[6].Text);
                        sum += m;
                     }
                    Label1.Text = "Average mark: " + Math.Round((sum / totalRow), 2);
            }
            else
            {
                Label1.Text = "Total students: " + totalRow;
            }
        }
            
        else
            Label1.Text = "Could not find any matched data";

      
    }
}