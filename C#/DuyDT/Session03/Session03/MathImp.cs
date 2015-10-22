using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session03
{
    class MathImp : MathOperation
    {
        #region MathOperation Members

        public int DoAdd(int x, int y)
        {
            return x + y;
        }

        public int DoSub(int x, int y)
        {
            return x - y;
        }

        #endregion
    }
}
