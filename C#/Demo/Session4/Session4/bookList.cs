using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Session4
{
    class bookList : BookOperation
    {
        private ArrayList bList;
        //default constructor
        public bookList()
        {
            bList = new ArrayList();
        }
        //sort booklist by price as descending
        public void DoSort()
        {
            bList.Sort();
            PrintBook();
        }

        #region BookOperation Members

        public void AddBook(Book b)
        {
            bList.Add(b);
        }
        public void PrintBook()
        {
            for (int i = 0; i < bList.Count; i++)
            {
                Book b = (Book)bList[i];
                Console.WriteLine(b);
            }
        }
        #endregion
    }
}
