using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2._1
{
    class Book
    {
        Book next;
        internal Book Next
        {
            get { return next; }
            set { next = value; }
        }

        string isbn;
        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        
        string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        
        string author;
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        
        string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        
        int amount;
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        string date;
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public Book(string isbn, string title, string author, string type, int amount)
        {
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.type = type;
            this.amount = amount;
        }
    }
}
