using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Session04
{
    class BookList : BookOperation

    {
        private ArrayList bList;
        //default constructor
        public BookList()
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
