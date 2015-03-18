using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ozellikler
//Kitap ve uye ekleme siralama, silme, arama yapabilir
//Uyeler kutuphanede bulunan kitap sayisi kadar kitap alabilir
//Geciken listesi olusturmak icin kitabi odunc verilen tarihi kullanicidan alir. Listeleme yapilan gune gore hesaplama yapar
//Bir uye birden fazla kitaba sahip olabilir
//Uyeler kitap alip birakabilir
//Kitap tur bilgileri goruntulenip iligili basliktan arama yapilarak ayni turden kitaplara erisilebilir

namespace Homework2._1
{
    class Test
    {
        static void Main(string[] args)
        {

            Library lib = new Library();

            //Tanimli kitaplar
            Book book1 = new Book("978-975-17-3133-1", "matlab", "john tomas", "egitim", 2);
            Book book2 = new Book("978-975-17-3133-2", "matematik", "ihsan gelecek", "egitim", 1);
            Book book3 = new Book("978-975-17-3133-3", "siir kitabi", "furkan soysal", "edebiyat", 3);

            //Kitap ekleme
            lib.addSortBook(book1);
            lib.addSortBook(book2);
            lib.addSortBook(book3);

            //Tanimli uyeler
            Member mem1 = new Member(1581, "ahmet", "ilhan", "elazig");
            Member mem2 = new Member(1582, "merve", "demir", "denizli");
            Member mem3 = new Member(1583, "ihsan", "onal", "ankara");

            //Uye ekleme
            lib.addMember(mem1);
            lib.addMember(mem2);
            lib.addMember(mem3);

            //Odunc verilen tarihler
            DateTime date1 = new DateTime(2014, 11, 01);
            DateTime date2 = new DateTime(2014, 10, 02);
            DateTime date3 = new DateTime(2014, 10, 03);

            //Uye kitap ekleme
            lib.addBookToMember(mem1, book1, date1);
            lib.addBookToMember(mem1, book2, date2);
            lib.addBookToMember(mem1, book3, date3);
            lib.addBookToMember(mem2, book1, date2);


            int choice;
            do
            {
                Console.WriteLine("1- Uye Ekleme");
                Console.WriteLine("2- Kitap Ekleme");
                Console.WriteLine("3- Kitap Silme");
                Console.WriteLine("4- Uye Silme");
                Console.WriteLine("5- Kitap Arama");
                Console.WriteLine("6- Uye Arama");
                Console.WriteLine("7- Kitaplari Isim Sirasina Gore Listele");
                Console.WriteLine("8- Kitaplari Tur Sirasina Gore Listele");
                Console.WriteLine("9- Uyeleri Listele");
                Console.WriteLine("10- Uyeye Kitap Ver");
                Console.WriteLine("11- Uyeden Kitap Al");
                Console.WriteLine("12- Belirli Uyenin Sahip Olduğu Kitaplar");
                Console.WriteLine("13- Suresi Gecmis Kitaplar");
                Console.WriteLine("**************************");
                Console.Write("Menuden seciminizi yapiniz(cikis:0): ");
                choice = Int32.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Uye bilgileri giriniz:");
                    Console.Write("Kimlik no:");
                    int id = Int32.Parse(Console.ReadLine());
                    Console.Write("Isim:");
                    string firstName = Console.ReadLine();
                    Console.Write("Soyisim:");
                    string lastName = Console.ReadLine();
                    Console.Write("Adres:");
                    string addres = Console.ReadLine();
                    Member member = new Member(id, firstName, lastName, addres);
                    lib.addMember(member);
                    Console.WriteLine("**********\t");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Kitap bilgileri giriniz");
                    Console.Write("ISBN: ");
                    string isbn = Console.ReadLine();
                    Console.Write("Adi: ");
                    string title = Console.ReadLine();
                    Console.Write("Yazari: ");
                    string author = Console.ReadLine();
                    Console.Write("Turu:");
                    string type = Console.ReadLine();
                    Console.Write("Adet(miktari): ");
                    int amount = Int32.Parse(Console.ReadLine());
                    lib.addSortBook(new Book(isbn, title, author, type, amount));
                    Console.WriteLine("**********\t");
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Kitap listesi:");
                    lib.displayBook();
                    Console.Write("Silinecek kitabin ismi: ");
                    string dltBook = Console.ReadLine();
                    Console.WriteLine(lib.searchBook(dltBook).Title + " Kitabi silindi.");
                    lib.deleteBook(lib.searchBook(dltBook).Isbn);
                    Console.WriteLine("Yeni Liste");
                    lib.displayBook();
                    Console.WriteLine("**********\t");
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Uye listesi:");
                    lib.displayMember();
                    Console.WriteLine("\nSilinecek Uyenin");
                    Console.Write("Isim: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Soyisim: ");
                    string lastName = Console.ReadLine();
                    lib.deleteMember(lib.searchMember(firstName, lastName).IdentityNo);
                    Console.WriteLine("\nYeni Uye Listesi:");
                    lib.displayMember();
                    Console.WriteLine("**********\t");
                }
                else if (choice == 5)
                {
                    Console.Write("Kitap ismi giriniz: ");
                    string title = Console.ReadLine();
                    Book book = lib.searchBook(title);
                    Console.WriteLine("ISBN: " + book.Isbn);
                    Console.WriteLine("Adi: " + book.Title);
                    Console.WriteLine("Yazari: " + book.Author);
                    Console.WriteLine("Tur: " + book.Type);
                    Console.WriteLine("Kalan adet: " + book.Amount);
                    Console.WriteLine("**********\t");
                }

                else if (choice == 6)
                {
                    Console.Write("Uye ismi giriniz: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Uye soyisim giriniz: ");
                    string lastName = Console.ReadLine();
                    Member member = lib.searchMember(firstName, lastName);
                    Console.WriteLine("ID: " + member.IdentityNo);
                    Console.WriteLine("Adi Soyadi: " + member.FirstName + " " + member.LastName);
                    Console.WriteLine("Adresi " + member.Address);
                    Console.WriteLine("Kitaplari: ");
                    lib.displayBooksOfMember(member);
                    Console.WriteLine("**********\t");
                }
                else if (choice == 7)
                {
                    Console.WriteLine("Kitaplari Isim Sirasina Gore Listesi");
                    lib.displayBook();
                    Console.WriteLine("**********\t");
                }
                else if (choice == 8)
                {
                    Console.WriteLine("Kitap Turleri Listesi");
                    lib.getBooksType();
                    Console.WriteLine("\nTure gore siralama icin tur ismi igiriniz.");
                    string type = Console.ReadLine();
                    lib.searchBookType(type);
                    Console.WriteLine("**********\t");

                }

                else if (choice == 9)
                {
                    Console.WriteLine("Uye listesi");
                    lib.displayMember();
                    Console.WriteLine("**********\t");
                }

                else if (choice == 10)
                {
                    Console.WriteLine("Listede ekli olan kitap ve uye secilmelidir");
                    Console.Write("Uye isim: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Uye soyisim: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Kitap ismi: ");
                    string bookName = Console.ReadLine();
                    Console.WriteLine("Verilen tarih bilgileri giriniz");
                    Console.Write("Gun: ");
                    int day = Int32.Parse(Console.ReadLine());
                    Console.Write("Ay: ");
                    int mount = Int32.Parse(Console.ReadLine());
                    Console.Write("Year: ");
                    int year = Int32.Parse(Console.ReadLine());
                    DateTime date = new DateTime(year, mount, day);
                    lib.addBookToMember(lib.searchMember(firstName, lastName), lib.searchBook(bookName), date);
                    Console.WriteLine("**********\t");
                }
                else if (choice == 11)
                {
                    Console.WriteLine("Uyeden Kitap silmek icin bul");
                    Console.Write("Uye isim: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Uye soyisim: ");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Uyede bulunan kitaplar");
                    lib.displayBooksOfMember(lib.searchMember(firstName, lastName));
                    Console.Write("Silmek istediginiz kitap adi: ");
                    string title = Console.ReadLine();
                    lib.deleteBookThanMember(lib.searchMember(firstName, lastName), lib.searchBook(title));
                    Console.WriteLine("**********\t");
                }
                else if (choice == 12)
                {
                    Console.WriteLine("Uyedeki kitaplar");
                    Console.Write("Uye isim: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Uye soyisim: ");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Uyede bulunan kitaplar");
                    lib.displayBooksOfMember(lib.searchMember(firstName, lastName));
                    Console.WriteLine("**********\t");
                }

                else if (choice == 13)
                {
                    Console.WriteLine("Suresi gecmis kitaplari goruntule");
                    lib.LateDays15();
                    Console.WriteLine("**********\t");
                }

            } while (choice != 0);     
        }
    }
}
