using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program4
{
    class Program
    {
        public static void Main(string[] args)
        {

                Console.WriteLine("Please enter the amount of numbers you would like to sort: ");
                string howMany = Console.ReadLine();

                Console.WriteLine("Please enter the " + howMany + " numbers you would like to sort: ");
                string numbers = Console.ReadLine();
                Console.WriteLine('\n');

                double[] numbersToSort = Array.ConvertAll(numbers.Split(' '), double.Parse);


                SortNumbers(numbersToSort, 0, numbersToSort.Length - 1);

                foreach (double v in numbersToSort)
                {
                    Console.Write(v + " ");
                }
                Console.WriteLine('\n');
        }

        public static void SortNumbers(double[] numbersToSort, int first, int last)
        {
            if (first < last)
            {
                int pivot = (int)Split(numbersToSort, first, last);
                SortNumbers(numbersToSort, first, pivot - 1);
                SortNumbers(numbersToSort, pivot + 1, last);
            }
        }

        public static double Split(double[] numbersToSort, int first, int last)
        {
            int pivot = (int)numbersToSort[last];
            int pIndex = first;

            for (int i = first; i < last; i++)
            {
                if ((int)numbersToSort[i] <= pivot)
                {
                    var temp = numbersToSort[i];
                    numbersToSort[i] = numbersToSort[pIndex];
                    numbersToSort[pIndex] = temp;
                    pIndex++;
                }
            }

            var anotherTemp = numbersToSort[pIndex];
            numbersToSort[pIndex] = numbersToSort[last];
            numbersToSort[last] = anotherTemp;
            return pIndex;
        }
    }
}
