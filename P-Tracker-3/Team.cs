/*
 * Team class is the fundamental structure of a Team
 * access to data members and reading and writing to Team object
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Tracker_3
{
    class Team
    {
        string _name;
        int _score;
        bool _advance;

        public string name
        {
            get => _name;
            set => _name = value;
        }
        public int score
        {
            get => _score;
            set => _score = value;
        }

        public bool advance
        {
            get => _advance;
            set => _advance = value;
        }

        public void EnterName(Team team)
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                keepGoing = false;

                Console.WriteLine("enter name or enter \"QUIT\" twice to go back to the sub-menu");
                string wordOne = Console.ReadLine();
                wordOne = wordOne.ToUpper();

                if (wordOne == "QUIT")
                {
                    wordOne = "";
                    break;
                }
                
                if (wordOne == "" || wordOne == " " || wordOne == "  ")
                {
                    keepGoing = true;
                    Console.WriteLine("Please enter a value, or enter \"QUIT\" twice to exit");
                }

                if (wordOne.Length > 25)
                {
                    keepGoing = true;
                    Console.WriteLine("Please limit to under 25 characters");
                }
                
                team.name = wordOne; 
            }
        }

        public void EnterScores(Team team)
        {
            Console.WriteLine("score: ");
            string numberScore = Console.ReadLine();
            numberScore = ErrorChecking.EnsureDigit(numberScore);
            team.score = Int32.Parse(numberScore);
        }
        
        public void DisplayName(Team team)
        {
            Console.WriteLine(team.name);
        }
        public void DisplayTeam(Team team)
        {
            Console.WriteLine($"name: {team.name}");
            Console.WriteLine($"score: {team.score}");
        }
    }
}
