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
		//
	}
    // return connection string
    public static string connectionString
    {
        get
        {
            return @"Data Source=IBRAHIM;Initial Catalog=SampleExam;Integrated Security=True";
        }
    }
}