using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Question2
{
    public partial class Question2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Y12S2B1;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            string min = txtMin.Text;
            string max = txtMax.Text;
            getSearch(min, max);
            lbCount.Visible = true;
            Label1.Visible = true;
        }

        private void getSearch(string min, string max)
        {
            if (min.Equals("") && max.Equals(""))
            {
                string cmd = "select Cameras.Model,Makers.MakerName,Cameras.Lens,Cameras.Aperture,Cameras.Resolution,Cameras.ShutterSpeed,"
                    + "Cameras.Zoom,Cameras.Price from Cameras,Makers where Cameras.MakerID = Makers.MakerID order by Cameras.Price";
                displayData(cmd);
            }
            else
            {
                if ((!min.Equals("") && max.Equals("")))
                {
                    string cmd = "select Cameras.Model,Makers.MakerName,Cameras.Lens,Cameras.Aperture,Cameras.Resolution,"
                        + "Cameras.ShutterSpeed,Cameras.Zoom,Cameras.Price from Cameras,Makers where Cameras.MakerID = Makers.MakerID and Cameras.Price >= " + min + "order by Cameras.Price";
                    displayData(cmd);
                }
                else
                {
                    if ((min.Equals("") && !max.Equals("")))
                    {
                        string cmd = "select Cameras.Model,Makers.MakerName,Cameras.Lens,Cameras.Aperture,Cameras.Resolution,"
                        + "Cameras.ShutterSpeed,Cameras.Zoom,Cameras.Price from Cameras,Makers where Cameras.MakerID = Makers.MakerID and Cameras.Price <= " + max + "order by Cameras.Price desc";    
                        displayData(cmd);
                    }
                    else
                    {
                        if ((!min.Equals("") && !max.Equals("")))
                        {
                            string cmd = "select Cameras.Model,Makers.MakerName,Cameras.Lens,Cameras.Aperture,Cameras.Resolution,"
                       + "Cameras.ShutterSpeed,Cameras.Zoom,Cameras.Price from Cameras,Makers where Cameras.MakerID = Makers.MakerID and Cameras.Price >= "+min+ " and Cameras.Price <= " + max+ "order by Cameras.Price";
                            displayData(cmd);
                        }
                    }
                }
            }
        }

        private void displayData(string cmd)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataView dv = new DataView(ds.Tables[0]);
                GridView1.DataSource = dv;
                GridView1.DataBind();
                lbCount.Text = GridView1.Rows.Count.ToString();
            }
            catch (Exception)
            { }
        }
    }
}