using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2_ClassLibrary
{
    public class Book
    {
        public int bNumber;
        public string title;
        public string authors;
        public string publisher;
        public List<Copy> k;
        public Book()
        {
        }

        public Book(int bNumber, string title, string authors, string publisher)
        {
            this.bNumber = bNumber;
            this.title = title;
            this.authors = authors;
            this.publisher = publisher;
            k = new List<Copy>();
        }
        
        public String ToString()
        {
            return bNumber.ToString() + "\t" + title + "\t" + publisher + "\t" + authors;
        }
    }

    public class BookList
    {
        public List<Book> q;

        public BookList()
        {
            q = new List<Book>();
        }
        public Book searchBookByNumber(String a)
        {
            foreach (Book b in q)
            {
                if (b.bNumber.ToString().Trim().Equals(a.Trim()))
                {
                    return b;
                }
            }
            return null;
        }

    }
}
