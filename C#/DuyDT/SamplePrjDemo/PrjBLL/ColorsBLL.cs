using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrjEntities;
using PrjDAL;
namespace PrjBLL
{
    public class ColorsBLL
    {
        private ColorsDAL cd;
        public ColorsBLL(string connectionString)
        {
            cd = new ColorsDAL(connectionString);
        }
        public List<Colors> GetAllColors()
        {
            return cd.GetAllColors();
        }
        public string InsertColor(string name)
        {
            Colors c = new Colors();
            c.ColorName = name;
            bool rs = cd.InsertColor(c);
            string s = "New row has been added";
            if (!rs)
                s = "Adding failed";
            return s;
        }
    }
}
