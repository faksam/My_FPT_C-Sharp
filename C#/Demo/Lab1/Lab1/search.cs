using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Lab1
{

    class search
    {
          
            private string code;
            private string name;
            private string special;
            public string Name
            {
                get { return this.name; }
                set { name = value; }
            }

            public string Code
            {
                get { return this.code; }
                set { code = value; }
            }


            public string Special
            {
                get { return this.special; }
                set { special = value; }
            }
            public search(string code, string name, string special)
            {
                Code = code;
                Name = name;
                Special = special;

            }
        }
    }

