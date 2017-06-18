using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program1
    {
        public static int option;
        
        static void Main(string[] args)
        {
           Console.WriteLine("Please enter 1 to input date with spaces or 2 to input date with forward slashes.");
           option = Convert.ToInt16(Console.ReadLine());

            if (option == 1)
            {

                string dateString;
                Console.WriteLine("Please enter a date separated by spaces (YYYY MM DD).");
                dateString = Console.ReadLine();
                string[] tokens = dateString.Split('/', ' ');


                int tempMonth = Convert.ToInt32(tokens[1]);
                int tempDay = Convert.ToInt32(tokens[2]);
                int tempYear = Convert.ToInt32(tokens[0]);

                Date date = new Date(tempYear, tempMonth, tempDay);
            }

            else if (option == 2)
            {
                string dateString;
                Console.WriteLine("Please enter a date separated by forward slashes (MM/DD/YYYY).");
                dateString = Console.ReadLine();       
                Date date = new Date(dateString);
            }
        }
    }
}
