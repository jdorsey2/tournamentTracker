/*
 * Program ID: P_Traccker_3
 * 
 * Purpose: This program is a Tournament Tracker. It tracks the progression of wins over a series of tournaments. 
 * 
 *  Organization: the Team.cs class keeps track of team data, such as name, score and if they are still competing.
 *   The Play.cs class keeps track of which team is playing against which other team. The MainMenu.cs class keeps the
 *   clutter of the menus separate from the Main program. The Graphics.cs class is not functional yet. 
 *   
 *  Description: Using the menu options, you can create teams by entering their name and enter their scores as they 
 *   progress in the tournament. You need to calculate who won after each round, then enter new scores after each round. 
 * 
 * Revision History:
 *  Created by Jason Dorsey, on 20 December, 2020
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Tracker_3
{
    class Program
    {
        public static Team EnterAndCheckTeam(Team[] teams)  // used under option A, when matching teams
        {                                                  // allows for user to enter name of team and it checks if it exists and returns a Team
            Team team = new Team();
            bool goingFlag = true;
            string teamName = "";

            while (goingFlag)
            {
                goingFlag = false;
                Console.WriteLine("Please enter the name of a team to be matched, or enter \"QUIT\" twice to go back to the sub-menu");
                teamName = Console.ReadLine();
                teamName = teamName.ToUpper();

                if (teamName == "QUIT")
                {
                    break;
                }
                if (teamName.Length > 25)
                {
                    goingFlag = true;
                    Console.WriteLine("Please enter a name less than 25 letters long");
                }
                if (teamName == "" || teamName == " ")
                {
                    goingFlag = true;
                    Console.WriteLine("Please enter a team name first, please press enter");
                    break;
                }
            }

            for (int i = 0; i < teams.Length; i++)          // check if name exists
            {
                if (teamName == teams[i].name)
                {
                    team = teams[i];
                }
            }
            return team;
        }

        static void Main(string[] args)
        {
            //######### Determines array sizes ###########################################

            string size = "";
            bool keepGoing = true;

            while (keepGoing)       // error checking 
            {
                keepGoing = false;
                bool isNumber = true;

                Console.WriteLine("Please enter how many teams there are");
                size = Console.ReadLine();

                foreach (char letter in size)
                {
                    if (char.IsPunctuation(letter) || char.IsLetter(letter))
                    {
                        keepGoing = true;
                        isNumber = false;
                    }
                }

                if (size.Length > 25)
                {
                    keepGoing = true;
                    Console.WriteLine("Please limit the length to under 25");
                }

                if (isNumber == false)
                {
                    Console.WriteLine("Please try again, enter only digits");
                }
            }

            //######### Global Variables ################################################

            int numberTeams = Int32.Parse(size);
            int numberMatches = numberTeams / 2;            // one on one matches necessitates dividing by 2

            Team[] teams = new Team[numberTeams];

            for (int i = 0; i < teams.Length; i++)
            {
                teams[i] = new Team();
            }

            Play[] playsArray = new Play[numberMatches];    // matches teams into competing teams so their is half as many objects
            Team[] winnerSeries = new Team[numberMatches];

            for (int i = 0; i < playsArray.Length; i++)   //playArray is a collection of Play(s) which is a collection of Team(s)
            {
                playsArray[i] = new Play();
                winnerSeries[i] = new Team();
            }
            string input = "";

            // ########## Main Menu with implementation ##################################

            while (true)
            {
                MainMenu.Display();
                input = Console.ReadLine();
                input = input.ToUpper();

                if (input == "A")   // Enter all teams 
                {
                    bool nullValue = false;
                    string teamsInput = "";

                    while (true)
                    {
                        MainMenu.EnterTeamsSubMenu();
                        teamsInput = Console.ReadLine();
                        teamsInput = teamsInput.ToUpper();
                        if (teamsInput == "A")
                        {
                            // put more details in later (members, etc)
                            for (int i = 0; i < teams.Length; i++)
                            {
                                teams[i].EnterName(teams[i]);               // Method from Team.cs
                            }
                        }
                        else if (teamsInput == "B")
                        {

                            Console.WriteLine("Please select from the following teams: ");
                            for (int i = 0; i < teams.Length; i++)
                            {
                                teams[i].DisplayName(teams[i]);                                 // from Team.cs
                                Console.WriteLine("-------------------------------");
                            }

                            // Match Teams in competitions
                            Team teamOne = new Team();
                            Team teamTwo = new Team();
                            Play playRecord = new Play();

                            for (int i = 0; i < playsArray.Length; i++)         // series of plays or matches stored in playArray
                            {
                                teamOne = EnterAndCheckTeam(teams);           // as defined in class Program above
                                teamTwo = EnterAndCheckTeam(teams);
                                playRecord = playRecord.ConvertTeamsToPlay(teamOne, teamTwo); // from Play.cs

                                playsArray[i] = playRecord;
                            }
                        }
                        else if (teamsInput == "C") //exit to main menu
                        {
                            break;

                        }
                        else
                        {
                            Console.WriteLine("Please select one of the sub-menu options");
                        }
                    }

                }
                else if (input == "B")  // enter scores for each team
                {
                    bool nullFlag = false;
                    for (int i = 0; i < teams.Length; i++)
                    {
                        if (teams[i].name == null)
                        {
                            nullFlag = true;
                        }
                        else
                        {
                            Console.Write($"{teams[i].name}: ");
                            teams[i].EnterScores(teams[i]);                     // from Team.cs
                        }
                    }

                    if (nullFlag == true)
                    {
                        Console.WriteLine("Please enter a team name before entering score");
                    }

                    if (nullFlag == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please verify scores: ");
                        Console.WriteLine();

                        for (int i = 0; i < teams.Length; i++)
                        {
                            teams[i].DisplayTeam(teams[i]);                     // from Team.cs
                        }
                    }
                }
                else if (input == "C")  // calculates scores and returns winners for one round of tournaments
                {
                    for (int i = 0; i < playsArray.Length; i++)
                    {
                        winnerSeries[i] = playsArray[i].CompareScores(playsArray[i].teamOne, playsArray[i].teamTwo); // from Play.cs
                    }
                    Console.WriteLine("scores are now calculated");
                }
                else if (input == "D")
                {
                    while (true)
                    {
                        MainMenu.DisplaySubMenu();
                        string displayInput = "";
                        displayInput = Console.ReadLine();
                        displayInput = displayInput.ToUpper();

                        if (displayInput == "A") // display all teams
                        {
                            Console.WriteLine("Here is a list of all teams: ");
                            for (int i = 0; i < teams.Length; i++)
                            {
                                teams[i].DisplayTeam(teams[i]);                                 // from Team.cs
                                Console.WriteLine("-------------------------------");
                            }
                            Console.WriteLine("################################################################");

                        }
                        else if (displayInput == "B") // display matched teams
                        {
                            bool ArrayIsNull = false;
                            for (int i = 0; i < teams.Length; i++)
                            {
                                if (teams[i].score == 0)        // testing for any scores not entered yet
                                {
                                    Console.WriteLine("please enter a score or create a team and try again");
                                    ArrayIsNull = true;
                                }
                            }

                            Console.WriteLine("Here is the breakdown according to who plays who: ");

                            Team[] teamArray = new Team[2]; // new array of teams for storage
                            for (int i = 0; i < teamArray.Length; i++)
                            {
                                teamArray[i] = new Team();
                            }

                            while (!ArrayIsNull)
                            {
                                ArrayIsNull = true;
                                for (int i = 0; i < playsArray.Length; i++)
                                {
                                    teamArray = playsArray[i].ConvertFromPlayToTeamArray(playsArray[i]);    // from Play.cs

                                    for (int j = 0; j < teamArray.Length; j++)
                                    {
                                        teamArray[j].DisplayTeam(teamArray[j]);                      // from Team.cs
                                    }
                                    Console.WriteLine("------------------------------------------");
                                }
                            }
                        }
                        else if (displayInput == "C") // winners
                        {
                            for (int i = 0; i < winnerSeries.Length; i++)
                            {
                                Console.WriteLine("Winners are: ");
                                Console.WriteLine($"Name: {winnerSeries[i].name}");
                                Console.WriteLine($"Score: {winnerSeries[i].score}");
                            }
                        }
                        else if (displayInput == "E") // exit to main menu
                        {
                            break;
                        }
                        else
                        {
                            // error
                        }
                    }

                }
                else if (input == "G") // graphical display of results, not working yet
                {
                    Graphical.Display(playsArray);

                }
                else if (input == "U")     // update/delete teams, not working yet
                {
                    string menuInput = "";
                    while (true)
                    {
                        MainMenu.UpdateMenu();
                        menuInput = Console.ReadLine();
                        menuInput = menuInput.ToUpper();
                        if (menuInput == "1")
                        {

                        }
                        else if (menuInput == "2")
                        {

                        }
                        else if (menuInput == "3")
                        {
                            break;

                        }
                        else
                        {
                            // error checking
                        }
                    }
                }
                else if (input == "S") // save, not working yet
                {

                }
                else if (input == "E") //exit
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please make a selection from the menu");
                }

            }
        }
    }
}
