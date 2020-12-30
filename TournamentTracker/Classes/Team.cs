using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker.Classes
{
    class Team
    {

        public string name { get; set; }
        public int score { get; set; }

        public Team()
        {
            name = "";
            score = 0;
        }

        public Team(string Name, int Score)
        {
            this.name = Name;
            this.score = Score;
        }

        public void CopyToTeam(Team team) // write to team object without user input here
        {
            name = team.name;
            score = team.score;
        }

        public Team CreateWriteToTeam() // write to team from user defined input
        {
            Team team = new Team();
            string Name = "";
            string ScoreInt = "";
            int Score = 0;

            Console.WriteLine("Please enter name");
            Name = Console.ReadLine();
            Name = Name.ToUpper();
            Name = ErrorChecking.EnsureLength(Name);
            Name = ErrorChecking.EnsureEmptyLines(Name);
            team.name = Name;

            Console.WriteLine("Please enter score");
            ScoreInt = Console.ReadLine();
            ScoreInt = ErrorChecking.EnsureEmptyLines(ScoreInt);
            ScoreInt = ErrorChecking.EnsureLength(ScoreInt);
            ScoreInt = ErrorChecking.EnsureDigit(ScoreInt);
            Score = Int32.Parse(ScoreInt);
            team.score = Score;

            return team;
        }

        public string EnterName()
        {
            string Name = "";

            Console.WriteLine("Please enter name");
            Name = Console.ReadLine();
            Name = Name.ToUpper();
            Name = ErrorChecking.EnsureLength(Name);
            Name = ErrorChecking.EnsureEmptyLines(Name);
            name = Name;
            return name;
        }

        public int EnterScore()
        {
            string ScoreInt = "";

            Console.WriteLine("Please enter score");
            ScoreInt = Console.ReadLine();
            ScoreInt = ErrorChecking.EnsureEmptyLines(ScoreInt);
            ScoreInt = ErrorChecking.EnsureLength(ScoreInt);
            ScoreInt = ErrorChecking.EnsureDigit(ScoreInt);
            score = Int32.Parse(ScoreInt);
            return score;
        }
        public void DisplayTeam(Team team)
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {team.name}");
            Console.WriteLine($"Score: {team.score}");
            Console.WriteLine();
        }
    }
}
