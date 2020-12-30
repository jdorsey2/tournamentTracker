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

        public Matches ConvertTeamToMatch(Matches match, Team one, Team two)
        {                                                             // enter two teams given a match
            match.teamOne = one;                              // can name the match seperately
            match.teamTwo = two;

            return match;
        }
        public Matches TeamToMatch(Team one, Team two)
        {
            Matches match = new Matches();
            match.teamOne = one;
            match.teamTwo = two;
            return match;
        }

        public Matches SearchForMatch(string name, Matches[] matches)
        {
            Matches match = new Matches();

            for (int i = 0; i < matches.Length; i++)
            {
                if (name == matches[i].name)
                {
                    match = matches[i];
                }
            }
            return match;
        }
        public Matches EnterMatch()
        {
            Matches match = new Matches();
            Team one = new Team();
            Team two = new Team();

            one = teamOne.CreateWriteToTeam();
            two = teamTwo.CreateWriteToTeam();

            match = TeamToMatch(one, two);
            return match;
        }
//********************** Takes information in and returns information*************************
        // start
        public Matches EnterNameMatch(Matches match)  // name a specific match between two teams
        {
            Console.WriteLine("Please enter a name for the match");
            string matchName = Console.ReadLine();
            matchName = matchName.ToUpper();
            matchName = ErrorChecking.EnsureEmptyLines(matchName);
            matchName = ErrorChecking.EnsureLength(matchName);
            match.name = matchName;
            return match;
        }
        public Matches EnterNameOfTeamsByMatch(Matches match) // match together two teams by entering name
        {
            Console.WriteLine("Please enter a name");
            string teamName1 = Console.ReadLine();
            teamName1 = teamName1.ToUpper();
            teamName1 = ErrorChecking.EnsureEmptyLines(teamName1);
            teamName1 = ErrorChecking.EnsureLength(teamName1);
            match.teamOne.name = teamName1;

            Console.WriteLine("Please enter a name");
            string teamName2 = Console.ReadLine();
            teamName2 = teamName2.ToUpper();
            teamName2 = ErrorChecking.EnsureEmptyLines(teamName2);
            teamName2 = ErrorChecking.EnsureLength(teamName2);
            match.teamTwo.name = teamName2;

            return match;
        }

        public Matches EnterScoreOfTeamsbyMatch(Matches match)
        {
            Console.WriteLine("Please enter score");
            Console.WriteLine($"Name: {match.teamOne.name}");
            string ScoreInt = Console.ReadLine();
            ScoreInt = ErrorChecking.EnsureEmptyLines(ScoreInt);
            ScoreInt = ErrorChecking.EnsureLength(ScoreInt);
            ScoreInt = ErrorChecking.EnsureDigit(ScoreInt);
            match.teamOne.score = Int32.Parse(ScoreInt);

            Console.WriteLine("Please enter score");
            Console.WriteLine($"Name: {match.teamTwo.name}");
            string Score = Console.ReadLine();
            Score = ErrorChecking.EnsureEmptyLines(Score);
            Score = ErrorChecking.EnsureLength(Score);
            Score = ErrorChecking.EnsureDigit(Score);
            match.teamTwo.score = Int32.Parse(Score);

            return match;
        }
        // end
    // ********************** Takes information in and returns information *************************

        public void DisplayMatch(Matches match)
        {
            Console.WriteLine();
            Console.WriteLine("Match between:");
            Console.WriteLine(match.teamOne.name);
            Console.WriteLine(match.teamOne.score);
            Console.WriteLine();
            Console.WriteLine("and");
            Console.WriteLine();
            Console.WriteLine(match.teamTwo.name);
            Console.WriteLine(match.teamTwo.score);
        }

        public Team CompareScores(Team one, Team two)
        {
            if (one != null || two != null)
            {
                if (one.score != 0 || two.score != 0)
                {
                    if (one.score > two.score)
                    {
                        two.score = -1;
                        return one;
                    }
                    else if (one.score < two.score)
                    {
                        one.score = -1;
                        return two;
                    }
                    else
                    {
                        Console.WriteLine("tie"); // have a tie, need additional functionality (elimination round) to deal with it
                        return one; // fix later when tie functionality is updated
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a score");
                    return new Team();
                }
            }
            else
            {
                Console.WriteLine("Please enter a team name first");
                return new Team();
            }
        }

    }
}
