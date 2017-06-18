using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    struct Date
    {
        private int year;
        private int month;
        private int day;

        public Date(int year, int month, int day)
        {
            this.year = year;
            this.day = day;
            this.month = month;

            string monthName = new DateTime(year, month, day).ToString("MMM", CultureInfo.InvariantCulture);

            printInformation(monthName, day, year);
        }

        public Date(string dateString)
        {
            string[] tokens = dateString.Split('/', ' ');

            int[] dateItems = Array.ConvertAll<string, int>(tokens, int.Parse);

            month = dateItems[0];
            day = dateItems[1];
            year = dateItems[2];

            string monthName = new DateTime(year, month, day).ToString("MMM", CultureInfo.InvariantCulture);

            printInformation(monthName, day, year);

        }

        public void printInformation(string monthName, int day, int year)
        {
            Console.WriteLine("\nToday is {0} {1}, {2}", monthName, day, year);
        }
    }
}
