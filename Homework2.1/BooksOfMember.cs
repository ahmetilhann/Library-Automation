using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2._1
{
    class BooksOfMember //her uye icin sahip olduklari kitaplari tutar
    {
        BooksOfMember next;

        internal BooksOfMember Next
        {
            get { return next; }
            set { next = value; }
        }
        Book book;

        internal Book Book
        {
            get { return book; }
            set { book = value; }
        }
        DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public BooksOfMember(Book book, DateTime date)
        {
            this.book = new Book(book.Isbn, book.Title, book.Author, book.Type, book.Amount);
            this.date = new DateTime(date.Year,date.Month,date.Day);
            this.next = null;
        }

    }
}
