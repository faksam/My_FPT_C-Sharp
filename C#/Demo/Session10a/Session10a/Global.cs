using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session10a
{
    class Global
    {
        public static string ConnectionString
        {
            get
            {
                return "data source = KHJ; database = SampleExam; integrated security = true"; 

            }
        }
    }
}
