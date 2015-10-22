using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session05
{
    class MyList
    {
        //an array of whole number
        private int[] a;
        //current number of items
        private int cnt;
        public MyList(int MAX)
        {
            //allocate for with MAX items
            a = new int[MAX];
            cnt = 0;

        }
        //append an item to a
        public void AddItem(int item)
        {
            //if a not full
            if (cnt < a.Length)
                a[cnt++] = item;
            else Console.WriteLine("Array is full, adding failed");
        }
        //visit all items of a, action on each item depends on delegate
        public void VisitAll(MyPrint mp)
        {
            for (int i = 0; i < cnt; i++)
                mp(a[i]);
        }

    }
}
