using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab1
{
    class Publish
    {
       private ArrayList aList;

        public Publish()
        {
            aList = new ArrayList();
        }

        
        public void add(search b)
        {
            aList.Add(b);
        }

       
        public search SearchByCode(string code)
        {
            search b = null;
            foreach (search isearch in aList)
            {
                if (isearch.Code.Contains(code))
                    return (b = isearch);
            }
            return b;
        }

       
        public void PrintAll()
        {
                     foreach (search b in aList)
            {
                Console.WriteLine("{0}  {1}  {2}", b.Code, b.Name,b.Special);
            }
        }
    }
}
