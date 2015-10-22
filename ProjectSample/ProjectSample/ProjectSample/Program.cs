using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectSample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SqlConnection MyConnection = new SqlConnection("Data Source=FAKSAM;Initial Catalog=Project_CNET;Integrated Security=True");
            //SqlCommand MyCommand;

            Application.Run(new ParentView());

        }
    }
}
