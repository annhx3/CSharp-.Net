using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Pt2
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Please enter how many books, followed by a space and then enter 1 or 2 for the corresponding option");

            string numAndOption = Console.ReadLine();

            string[] splitNumOption = numAndOption.Split(' ');

            int num = Convert.ToInt32(splitNumOption[0]);
            int option = Convert.ToInt32(splitNumOption[1]);
            List<Book> bookList = new List<Book>();

            for (var count = 1; num > 0; num--)
            {
               
                Console.WriteLine("Please enter the book title for book number {0}:", count);
                string title = Console.ReadLine();
                
                Console.WriteLine("Please enter the book author for book number {0}:", count);
                string author = Console.ReadLine();

                Console.WriteLine("Please enter the book price for book number {0}:", count);
                double price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Please enter the book ISBN for book number {0}:", count);
                string isbn = Console.ReadLine();

                Book book = new Book(title, author, price, isbn);
                bookList.Add(book);

                count++;
            }

            
            
            if (option == 1)
            {
                var newList = bookList.OrderBy(b => b.Price);
                foreach (var book in newList)
                {
                    Book.printInformation(book);
                }
            }

            else if (option == 2)
            {

                var newList = bookList.OrderBy(b => b.Title);
                foreach (var book in newList)
                {
                    Book.printInformation(book);
                }
            }
        }
    }
}
