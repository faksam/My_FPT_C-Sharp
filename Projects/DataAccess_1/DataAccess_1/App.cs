using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess_1
{
    class App
    {
        //make a properity for connection string
        public static string connectionString
        {
            get
            {
                return @" data source=IBRAHIM; database=StudentDB; integrated security=true;";
            }
        }
    }
}
