using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker.Classes
{
    class Matches
    {
        public string name { get; set; }
        public Team teamOne { get; set; }
        public Team teamTwo { get; set; }

        public Matches TeamToMatch(Team one, Team two)
        {
            Matches match = new Matches();
            match.teamOne = one;
            match.teamTwo = two;
            return match;
        }
        public Matches EnterMatch(Team one, Team two)
        {
            Matches match = new Matches();
            //Team one = new Team();
            //Team two = new Team();

            one = teamOne.CreateWriteToTeam();
            two = teamTwo.CreateWriteToTeam();

            match = TeamToMatch(one, two);
            return match;
        }

        public void DisplayMatch(Matches match)
        {
            Console.WriteLine("Match between:");
            Console.WriteLine(match.teamOne.name);
            Console.WriteLine(match.teamOne.score);
            Console.WriteLine("and");
            Console.WriteLine(match.teamTwo.name);
            Console.WriteLine(match.teamTwo.score);
        }
    }
}
