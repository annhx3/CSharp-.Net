using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Pt2
{
    public class Book
    {
        private static string title;
        private static string author;
        private static double price;
        private static string isbn;

        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string ISBN { get; set; }

        public Book(string title, string author, double price, string isbn)
        {
            Title = title;
            Author = author;
            Price = price;
            ISBN = isbn;
        }


        public static void printInformation(Book book)
        {
            title = book.Title;
            author = book.Author;
            price = book.Price;
            isbn = book.ISBN;
            Console.WriteLine("{0} written by {1} is {2} dollars, with ISBN {3}", title, author, price, isbn);
        }
    }
}
