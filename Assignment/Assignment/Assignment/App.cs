using System;
using System.Collections.Generic;
using System.Web;

namespace Assignment
{
     class App
    {
        public static string ConnectionString
        {
            get
            {
                return @" data source=IBRAHIM; database=StudentDB; integrated security=true;";
            }
        }
    }
}