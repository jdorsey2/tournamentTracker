/*
 * 
 * sets as a class the relationship between at least two Team objects
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Tracker_3
{
    class Play
    {
        Team _teamOne;
        Team _teamTwo;
        bool _exist;

        public Team teamOne
        {
            get => _teamOne;
            set => _teamOne = value;
        }

        public Team teamTwo
        {
            get => _teamTwo;
            set => _teamTwo = value;
        }

        public bool exist
        {
            get => _exist;
            set => _exist = value;
        }
        public Play ConvertTeamsToPlay(Team one, Team two)  // semantic meaning of Team one and Team two are matched to play each other
        {
            Play newPlay = new Play();
            newPlay.teamOne = one;
            newPlay.teamTwo = two;
            return newPlay;
        }

        public Team[] ConvertFromPlayToTeamArray(Play play)
        {
            Team[] newTeam = new Team[2];
            for (int i = 0; i < newTeam.Length; i++)
            {
                newTeam[i] = new Team();
            }

            newTeam[0] = play.teamOne;
            newTeam[1] = play.teamTwo;

            return newTeam;
        }
        
        void DeleteTeam(Team team)
        {
            team.score = -1;
            exist = false;
        }
        public Team CompareScores(Team one, Team two)
        {
            if (one != null || two != null)
            {
                if (one.score != 0 || two.score != 0)
                {
                    if (one.score > two.score)
                    {
                        DeleteTeam(two);
                        one.advance = true;
                        return one;
                    }
                    else if (one.score < two.score)
                    {
                        DeleteTeam(one);
                        two.advance = true;
                        return two;
                    }
                    else
                    {
                        Console.WriteLine("tie"); // have a tie, need additional functionality (elimination round) to deal with it
                        return one; // fix later when tie functionality is updated
                    }  
                }else
                {
                    Console.WriteLine("Please enter a score");
                    return new Team();
                }
            }else
            {
                Console.WriteLine("Please enter a team name first");
                return new Team();
            }
        }

        public string EnterTeam(string teamName)  // used under option A, when matching teams
        {                                                  // allows for user to enter name of team and it checks if it exists and returns a Team
            bool goingFlag = true;

            while (goingFlag)
            {
                goingFlag = false;
                
                if (teamName == "QUIT")
                {
                    break;
                }
                if (teamName.Length > 25)
                {
                    goingFlag = true;
                    Console.WriteLine("Please enter a name less than 25 letters long");
                }
                //if (teamName == "" || teamName == " ")
                //{
                //    goingFlag = true;
                //    Console.WriteLine("Please enter a team name first, please press enter");
                //    break;
                //}
            }
            return teamName;
        }

        public Team CheckTeamsName(Team[] teams, string teamName)
        {
            Team team = new Team();
            //bool[] exists = new bool[teams.Length];
            //for (int i = 0; i < exists.Length; i++)
            //{
            //    exists[i] = false;
            //}
            for (int i = 0; i < teams.Length; i++)          // check if name exists
            {
                if (teamName == teams[i].name)
                {
                    team = teams[i];
                    //exists[i] = true;

                    //for (int i = 0; i < exists.Length; i++)         // needs more work
                    //{                             // *********************************************************************
                    //    if (exists[i] != true && exists[i + 1] != true)  // if there is not one true exists[i]: if they are all false
                    //    {                      //then do it again, ask for another name which does exist

                    //    }
                    //}

                    return team;
                }
            }
            return team;
        }
    }
}
