using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Tracker_3
{
    class Rounds
    {
        public static Team[] CalculateWinners(Play[] playsInput)
        {
            int index = playsInput.Length / 2;
            Team[] teamArray = new Team[index];
            for (int i = 0; i < teamArray.Length; i++)
            {
                teamArray[i] = new Team();
            }

            for (int i = 0; i < playsInput.Length; i++)
            {
                teamArray[i] = playsInput[i].CompareScores(playsInput[i].teamOne, playsInput[i].teamTwo);
            }

            return teamArray;
        }

        public static Play[] MatchTeams(Team[] teams)
        {
            Team teamOne = new Team();
            Team teamTwo = new Team();
            Play playRecord = new Play();
            Play[] playArray = new Play[teams.Length/2];
            for (int i = 0; i < playArray.Length; i++)
            {
                playArray[i] = new Play();
            }
            string name = "";

            for (int i = 0; i < playArray.Length; i++)
            {
                Console.WriteLine("please enter team name to match or enter \"QUIT\" to exit");
                name = Console.ReadLine();
                name = name.ToUpper();
                name = playRecord.EnterTeam(name);
                teamOne = playRecord.CheckTeamsName(teams, name);

                Console.WriteLine("Please enter team name to match or enter \"QUIT\" to exit");         // from Play.cs
                name = Console.ReadLine();
                name = name.ToUpper();
                name = playRecord.EnterTeam(name);
                teamTwo = playRecord.CheckTeamsName(teams, name);

                playRecord = playRecord.ConvertTeamsToPlay(teamOne, teamTwo); // from Play.cs

                playArray[i] = playRecord;
            }
            return playArray;
        }
    }
}
