using System;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = 0;
            string outputString = "";

            Console.WriteLine("Please enter a value for n to see all prime numbers between 2 and n: ");
            n = Convert.ToDouble(Console.ReadLine());

            GetPrimeNumbers(n, outputString);
         }

        public static void GetPrimeNumbers(double n, string outputString)
        {
            int i=0;
            int j=0;
            double check = 0;
            while (i <= n)
            {
                for (i = 2; i <= n; i++)
                {
                    for (j = 1; j <= i; j++)
                    {
                        if (i%j == 0)
                        {
                            check++;
                        }
                    }
                    if (check == 2)
                    {
                        outputString += (i + " ");
                    }
                    check = 0;
                }
            }
            Console.WriteLine("Prime numbers between 2 and " + n + " are: " + outputString);
        }
    }
}

