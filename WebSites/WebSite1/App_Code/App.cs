using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for App
/// </summary>
public class App
{
	public App()
	{
		//
		// TODO: Add constructor logic here
		
	}
    //return the connection String
    public static string ConnectionString
    {
        get {
            return @"Data Source=IBRAHIM;Initial Catalog=StudentDB;Integrated Security=True";
            }
    }
}