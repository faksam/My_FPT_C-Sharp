using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session10
{
    class Colors
    {
        private int colorId;
        private string colorName;
        public int ColorId
        {
            get;
            set;
        }
        public string ColorName
        {
            get;
            set;
        }
        public Colors(int colorId, string colorName)
        {
            ColorId = colorId;
            ColorName = colorName;
        }
    }
}
