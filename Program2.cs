using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Please enter a student score to get it's letter grade: ");
            var input = Console.ReadLine();


            double score = Convert.ToDouble(input);
            DetermineLetterGrade(score);

        }

        public static void DetermineLetterGrade(double score)
        {
            if (score >= 90 && score <= 100)
            {
                Console.WriteLine("Score of " + score + " recieves letter grade: A");
            }
            else if (score >= 80 && score < 90)
            {
                Console.WriteLine("Score of " + score + " recieves letter grade: B");
            }
            else if (score >= 70 && score < 80)
            {
                Console.WriteLine("Score of " + score + " recieves letter grade: C");
            }
            else
            if (score >= 60 && score < 70)
            {
                Console.WriteLine("Score of " + score + " recieves letter grade: D");
            }
            else if (score >= 0 && score < 60)
            {
                Console.WriteLine("Score of " + score + " recieves letter grade: F");
            }
            else
            {
                Console.WriteLine("You have entered an invalid score.\n");
            }
            Console.WriteLine("Please enter a student score to get it's letter grade: ");
            var inputFromConsole = Console.ReadLine();


            double input = Convert.ToDouble(inputFromConsole);
            DetermineLetterGrade(input);
        }
    }
}
