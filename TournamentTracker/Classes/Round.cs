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

        public Round MatchToRound(Matches one, Matches two)
        {
            Round round = new Round();
            round.matchOne = one;
            round.matchTwo = two;
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
