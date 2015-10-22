using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //get information of weather in hanoi vietnam
        ws.GlobalWeather gw = new ws.GlobalWeather();
        string weather = gw.GetWeather("Ha Noi", "Viet Nam");
        Response.Write(weather);
    }
}