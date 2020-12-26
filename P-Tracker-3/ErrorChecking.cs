﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Tracker_3
{
    class ErrorChecking
    {
        public static string EnsureDigit()
        {
            bool keepGoing = true;
            string input = "";

            while (keepGoing)
            {
                keepGoing = false;
                bool isDigit = true;
                input = Console.ReadLine();

                foreach (char letter in input)
                {
                    if (char.IsPunctuation(letter) || char.IsLetter(letter))
                    {
                        isDigit = false;
                        keepGoing = true;
                    }
                } 
                if (isDigit == false)
                {
                    Console.WriteLine("Please try again, enter only digits");
                }
            }
            return input;
        }

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
                        Console.WriteLine("Please enter a digit only");
                        input = Console.ReadLine();
                    }
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
                    Console.WriteLine("Please limit the length to under 25");
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
