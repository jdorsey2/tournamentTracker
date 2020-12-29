using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker
{
    class ErrorChecking
    {
        public static string EnsureDigit(string input)
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;

                foreach (char letter in input) 
                {
                    if (char.IsPunctuation(letter) || char.IsLetter(letter))
                    {
                        keepGoing = true;
                    }
                }
                if (keepGoing == true)
                {
                    Console.WriteLine("Please enter a digit only");
                    input = Console.ReadLine();
                }
            }
            return input;
        }

        
        public static string EnsureLength(string input)
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;
                if (input.Length > 25)
                {
                    keepGoing = true;
                    Console.WriteLine("Please limit the length to under 25, please try again");
                    input = Console.ReadLine();
                    input = input.ToUpper();
                }
            }
            return input;
        }
        public static string EnsureEmptyLines(string input)
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;

                if (input == "" || input == " " || input == "  ")
                {
                    keepGoing = true;
                    Console.WriteLine("Please enter a value, or enter \"QUIT\" twice to exit");
                    input = Console.ReadLine();
                    input = input.ToUpper();
                }
            }
            return input;
        }
      
        public static int EnsureEven(int input)
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;
                if (input % 2 != 0)
                {
                    Console.WriteLine("Please enter an even number only");
                    input = Int32.Parse(Console.ReadLine());
                    keepGoing = true;
                } 
            }
            return input;
        }
    }
}
