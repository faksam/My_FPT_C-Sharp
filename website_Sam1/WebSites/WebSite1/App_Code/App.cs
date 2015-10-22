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
            return @"data source=(local); database= StudentDB; Integrated security=true";
            }
    }
}