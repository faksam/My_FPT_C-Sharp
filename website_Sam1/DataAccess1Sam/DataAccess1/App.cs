using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess1
{
    class App
    {
        // make a property for the connection string
       public static string ConnectionString
        {
            get
            {
                return @" data source=IBRAHIM; database=StudentDB; integrated security=true;";
                
            }
        }
    }
}
