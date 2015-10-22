using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanakTransact
{
   interface ItTransaction
    {
         void openTransaction();
         double amount();
       
    }
}
