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

        public Team SearchForTeam(string name, Team[] teams)
        {
            Team team = new Team();
            for (int i = 0; i < teams.Length; i++)
            {
                if (name == teams[i].name)
                {
                    team = teams[i];
                }
            }
            return team;
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

        public string EnterName()     // return a string
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

        public int EnterScore()   // return an int
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
// ********************** Takes information in and returns information *************************
    // start
        public Team EnterTeamName(Team team)    // passes a Team and returns a team
        {
            Console.WriteLine("Please enter a name");
            string teamName = Console.ReadLine();
            teamName = teamName.ToUpper();
            teamName = ErrorChecking.EnsureEmptyLines(teamName);
            teamName = ErrorChecking.EnsureLength(teamName);
            team.name = teamName; 
            return team;
        }

        public Team EnterTeamScore(Team team)   // passes a team and returns a team
        {
            Console.WriteLine("Please enter a score");
          
            string ScoreInt = Console.ReadLine();
            ScoreInt = ErrorChecking.EnsureEmptyLines(ScoreInt);
            ScoreInt = ErrorChecking.EnsureLength(ScoreInt);
            ScoreInt = ErrorChecking.EnsureDigit(ScoreInt);
            team.score = Int32.Parse(ScoreInt);
            return team;
        }
            // end
        // ********************** Takes information in and returns information *************************
            
        public void DisplayTeam(Team team)
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {team.name}");
            Console.WriteLine($"Score: {team.score}");
            Console.WriteLine();
        }
    }
}
