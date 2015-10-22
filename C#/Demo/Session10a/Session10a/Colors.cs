using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session10a
{
    class Colors
    {
        private int colorID;
        private string colorName;
        public int ColorID
        {
            get;
            set;

        }
        public string ColorName
        {
            get;
            set;

        }
        public Colors(int colorID, string colorName)
        {
            ColorID = colorID;
            ColorName = colorName;
        }
    }
}
