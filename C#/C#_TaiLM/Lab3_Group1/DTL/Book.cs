using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3_Group1.DTL
{
    class Book
    {
        int bookNumber;

        public int BookNumber
        {
            get { return bookNumber; }
            set { bookNumber = value; }
        }

        string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        string authors;

        public string Authors
        {
            get { return authors; }
            set { authors = value; }
        }
        string publisher;

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public Book()
        {
        }
        public Book(int bkNu, string bkTi, string bkA, string bkP)
        {
            bookNumber = bkNu;
            title = bkTi;
            authors = bkA;
            publisher = bkP;
        }
        public void display()
        {
            Console.WriteLine("     {0}  -  {1}  -  {2}  -  {3}", bookNumber, title, authors, publisher);
        }
    }
}
