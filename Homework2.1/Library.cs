using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2._1
{
    class Library
    {
        Book booksHead;
        Member membersHead;

        internal Member MembersHead
        {
            get { return membersHead; }
            set { membersHead = value; }
        }
        
        //Uye eklemek icin kullanilir
        public void addMember(Member member)
        {
            if (membersHead == null)
                membersHead = member;
            //membersHead = new Member(member.IdentityNo, member.FirstName,member.LastName,member.Address);
            else
            {
                Member current = membersHead;

                while (current.Next != null)
                {
                    current = current.Next;
                }
                //current.Next = new Member(member.IdentityNo, member.FirstName, member.LastName, member.Address);
                current.Next = member;
            }
        }

        //Uyeleri goruntuler
        public void displayMember()
        {
            Member iterator = membersHead;
            while (iterator != null)
            {
                Console.WriteLine(iterator.IdentityNo + "\t" + iterator.FirstName + "\t" + iterator.LastName + "\t" + iterator.Address);
                iterator = iterator.Next;
            }
        }

        //Uye id sine gore uye siler
        public void deleteMember(int identityNo)
        {
            if (membersHead == null)
                throw new Exception("List is empty");
            else if (membersHead.IdentityNo == identityNo)
            {
                membersHead = membersHead.Next;
            }
            else
            {
                Member iterator = membersHead.Next;
                Member prev = membersHead;
                while (prev != null)
                {
                    if (iterator.IdentityNo == identityNo)
                    {
                        prev.Next = iterator.Next;
                        break;
                    }
                    prev = iterator;
                    iterator = iterator.Next;
                }
            }
        }

        //Uye isim soyismine gore arama yapar
        public Member searchMember(string firstName, string lastName)
        {
            Member iterator = membersHead;
            while (iterator != null)
            {
                if (iterator.FirstName.CompareTo(firstName) == 0 && iterator.LastName.CompareTo(lastName) == 0)
                {
                    return iterator;
                }
                iterator = iterator.Next;
            }
            return null;
        }

        //Kitaplari sirali ekler
        public void addSortBook(Book book)
        {
            if (booksHead == null)
                booksHead = book;
            else if (book.Title.CompareTo(booksHead.Title) < 0)
            {
                book.Next = booksHead;
                booksHead = book;
            }
            else
            {
                Book iterator = booksHead.Next;
                Book prev = booksHead;

                while (iterator != null)
                {
                    if (book.Title.CompareTo(iterator.Title) <= 0)
                    {
                        prev.Next = book;
                        book.Next = iterator;
                        break;
                    }
                    prev = iterator;
                    iterator = iterator.Next;
                }
                if (iterator == null)
                    prev.Next = book;
            }
        }

        //Kitaplari goruntuler
        public void displayBook()
        {
            Book iterator = booksHead;
            while (iterator != null)
            {
                Console.WriteLine(iterator.Isbn + "\t" + iterator.Title + "\t" + iterator.Author +"\t"+iterator.Type+"\t" + iterator.Amount);
                iterator = iterator.Next;
            }
        }

        //ISBN ye gore kitapları listler
        public void displayBook(string isbn)
        {
            Book iterator = booksHead;
            while (iterator != null)
            {
                if (iterator.Isbn.CompareTo(isbn) == 0)
                {
                    Console.WriteLine(iterator.Isbn + "\t" + iterator.Title + "\t" + iterator.Author + "\t" + iterator.Type + "\t" + iterator.Amount);
                    iterator = iterator.Next;
                }
                iterator = iterator.Next;
            }
        }

        //Title a gore kitap aramasi yapar
        public Book searchBook(string title)
        {
            Book iterator = booksHead;

            while (iterator != null)
            {
                if (iterator.Title.CompareTo(title) == 0)
                {
                    return iterator;
                }
                iterator = iterator.Next;
            }
            return null;
        }

        //ISBN ye gore silme islemi yapar
        public void deleteBook(string isbn)
        {
            if (booksHead == null)
                throw new Exception("dont find");
            else if (booksHead.Isbn.CompareTo(isbn) == 0)
            {
                booksHead = booksHead.Next;
            }
            else
            {
                Book iterator = booksHead.Next;
                Book prev = booksHead;

                while (prev != null)
                {
                    if (iterator.Isbn.CompareTo(isbn) == 0)
                    {
                        prev.Next = iterator.Next;
                        break;
                    }
                    prev = iterator;
                    iterator = iterator.Next;
                }
            }
        }

        //Ekli olann kitaplarin turunu donderir
        public void getBooksType()
        {
            if (booksHead == null)
                Console.WriteLine("There are no book");
            else
            {
                bool flag = true;
                Book iterator = booksHead;
                while (iterator != null)
                {
                    if (flag)
                    {
                        Console.WriteLine(iterator.Type);
                        flag = false;
                    }
                    if (iterator.Next != null && iterator.Type.CompareTo(iterator.Next.Type) != 0)
                            flag = true;
  
                    iterator = iterator.Next;
                }
            }
        }

        //Aranilan turden olan kitaplari goruntuler
        public void searchBookType(string type)
        {
            Book iterator = booksHead;

            while (iterator != null)
            {
                if(iterator.Type.CompareTo(type) == 0)
                    Console.WriteLine(iterator.Isbn + "\t" + iterator.Title + "\t" + iterator.Author + "\t" + iterator.Type + "\t" + iterator.Amount);
                iterator = iterator.Next;
            }
        }

        //Uyeye kitap ekler
        public void addBookToMember(Member member, Book book, DateTime date)
        {
            if (book.Amount == 0)
                Console.WriteLine("Book amount is not enough!!");
            else
            {
                book.Amount = book.Amount - 1;
                BooksOfMember booksOfMember = new BooksOfMember(book, date);
                booksOfMember.Next = member.MBooksHead;
                member.MBooksHead = booksOfMember;
            }
            
            
        }

        //Belirtilen uyedeki kitaplari goruntuler
        public void displayBooksOfMember(Member member)
        {
            if (member.MBooksHead == null)
                Console.WriteLine("Member doesnt have book!!!");
            else
            {
                Console.WriteLine("ISBN"+"\t"+"Kitap Adi");
                BooksOfMember iterator = member.MBooksHead;
                while (iterator != null)
                {
                    Console.WriteLine(iterator.Book.Isbn+"\t"+iterator.Book.Title);
                    iterator = iterator.Next;
                }
            }
        }

        //Uyeden kitap siler
        public void deleteBookThanMember(Member member, Book book)
        {         
            if (member.MBooksHead == null)
                Console.WriteLine("2Member doesnt have book!!!");
            else if (member.MBooksHead.Book.Isbn.CompareTo(book.Isbn) == 0)
            {
                member.MBooksHead = member.MBooksHead.Next;
            }
            else
            {
                BooksOfMember iterator = member.MBooksHead.Next;
                BooksOfMember prev = member.MBooksHead;
                while (iterator != null)
                {
                    if (iterator.Book.Isbn.CompareTo(book.Isbn) == 0)
                    {
                        prev.Next = iterator.Next;
                        break;
                    }
                    prev = iterator;
                    iterator = iterator.Next;
                }
            }
        }

        //Tarihi gecikmis kitaplari goruntuler
        public void LateDays15()
        {
            DateTime today = DateTime.Today; //Bugunun tarihini belirler
            Member itrMember = membersHead; //Uyelerde ilerlemek icin iterator
            Console.WriteLine("Isim Soyisim" + "\t" + "Kitab Ismi");
            while (itrMember != null)
            {
                BooksOfMember itrBook = itrMember.MBooksHead; //Uyelerin kitaplarinda ilerlemek icin iterator
                while (itrBook != null)
                {
                    double exraction = (today - itrBook.Date).TotalDays; //Odunc verilen gun sayisini hesaplar
                    if (exraction > 15)
                    {
                        Console.WriteLine(itrMember.FirstName+" "+itrMember.LastName+"\t" + itrBook.Book.Title);
                        //Console.WriteLine(itrBook.Book.Isbn + "\t" + itrBook.Book.Title);
                    }
                    itrBook = itrBook.Next;
                }
                itrMember = itrMember.Next;
            }
            
        }
    }
}
