using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{


    SqlConnection sqlConn = null;
    string connectionString = WebConfigurationManager.ConnectionStrings["QLDiemConnection"].ConnectionString;
    [WebMethod(Description = "Searchand return list of students", MessageName = "GetStudent")]
    public DataTable GetStudent(string fullname)
    {
        sqlConn = new SqlConnection(connectionString);
        string sqlSelect = "select * from student where fullname like '%" + fullname + "%' ";
        SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, sqlConn);
        sqlConn.Open();
        SqlDataAdapter sda = new SqlDataAdapter(sqlCmdSelect);
        DataSet ds = new DataSet();
        sda.Fill(ds, "student");
        sqlConn.Close();
        return ds.Tables["student"];
    }

    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    
}