using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker.Classes
{
    class Round
    {
        public string name { get; set; }
        public Matches matchOne { get; set; }
        public Matches matchTwo { get; set; }

        // can enter teams and match names and round names and assign teams to matches then to rounds
        public Round ConvertMatchesToRound(Round round, Matches one, Matches two)
        {
            round.matchOne = one;
            round.matchTwo = two;

            return round;
        }
        public Round MatchToRound(Matches one, Matches two)
        {
            Round round = new Round();
            round.matchOne = one;
            round.matchTwo = two;
            return round;
        }

        public Round EnterNameOfRound(Round round)
        {
            Console.WriteLine("Please enter a name for the match");
            string roundName = Console.ReadLine();
            roundName = roundName.ToUpper();
            roundName = ErrorChecking.EnsureEmptyLines(roundName);
            roundName = ErrorChecking.EnsureLength(roundName);
            round.name = roundName;
            return round;
        }
        public Round EnterRound()
        {
            Round round = new Round();
            Matches matchOne = new Matches();
            Matches matchTwo = new Matches();

            matchOne = matchOne.EnterMatch();
            matchTwo = matchTwo.EnterMatch();
            round = MatchToRound(matchOne, matchTwo);
            return round;
            
        }

        public void DisplayRound(Round round)
        {
            Console.WriteLine("Round between:");
            Console.WriteLine(round.matchOne.teamOne.name);
            Console.WriteLine(round.matchOne.teamOne.score);
            Console.WriteLine();
            Console.WriteLine(round.matchOne.teamTwo.name);
            Console.WriteLine(round.matchOne.teamTwo.score);
            Console.WriteLine("and");
            Console.WriteLine(round.matchTwo.teamOne.name);
            Console.WriteLine(round.matchTwo.teamOne.score);
            Console.WriteLine();
            Console.WriteLine(round.matchTwo.teamTwo.name);
            Console.WriteLine(round.matchTwo.teamTwo.score);
            Console.WriteLine();
        }
    }
}
