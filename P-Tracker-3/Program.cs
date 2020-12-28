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
    { /// <summary>
    /// /////////////////////////////////// after tournament round is done need to set the scores to zero
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            //######### Determines array sizes ###########################################

            int rounds = 0;
            int numberTeams = 0;
            bool keepGoing = true;

            while (keepGoing)       // error checking 
            {
                keepGoing = false;

                Menu.SuperMenu();
                string inputMain = Console.ReadLine();
                inputMain = inputMain.ToUpper();
                
                if (inputMain == "A")
                {
                    string size = "";
                    Console.WriteLine("Please enter how many teams there are, only enter an even number");
                    size = Console.ReadLine();

                    size = ErrorChecking.EnsureDigit(size);         // from ErrorChecking.cs
                    size = ErrorChecking.EnsureLength(size);    // from ErrorChecking.cs
                    numberTeams = Int32.Parse(size);
                    numberTeams = ErrorChecking.EnsureEven(numberTeams);  // from ErrorChecking.cs

                    string round = "";
                    Console.WriteLine("Please enter how many rounds the tournament will last");
                    round = Console.ReadLine();

                    round = ErrorChecking.EnsureDigit(round);
                    round = ErrorChecking.EnsureLength(round);
                    rounds = Int32.Parse(round);

                }
                else if (inputMain == "B")
                {
                    keepGoing = true;
                    Console.WriteLine();
                    Console.WriteLine("This option is currently not available, please create a new tournament");
                    Console.WriteLine();
                    //load program
                }else if (inputMain == "C")
                {
                    Environment.Exit(0);
                }else if (inputMain == "D")
                {
                    keepGoing = true;
                    Help.Pages();
                }else
                {
                    Console.WriteLine("Please select either A, B, C, or D");
                    keepGoing = true;
                }
            }

            //######### Global Variables ################################################
            
            int numberMatches = numberTeams / 2;  // one on one matches necessitates dividing by 2

            // take number of rounds and divide each successive one by 2 to be used a length of winnerSeries array for each tournamemnt
           
            //int newNumberTeams = numberTeams;
            //int[] roundsSizeArray = new int[rounds]; // roundsSizeArray gives us the size of the teams for each round
            //for (int i = 0; i < rounds; i++)    // divides number of teams into two for each round, 
            //{                                    // now i can use roundsSizeArray instead of numberTeams
            //    newNumberTeams = newNumberTeams / 2;
            //    roundsSizeArray[i] = newNumberTeams;  // figure out how to put numberTeams in array and numberMatches
                
            //}
             

            Team[] teams = new Team[numberTeams];

            for (int i = 0; i < teams.Length; i++)
            {
                teams[i] = new Team();
            }
            // *************************************************************************************** change size of array to ...when each round is played size should half
            Play[] playsArray = new Play[numberMatches];    // matches teams into competing teams so their is half as many objects
            Team[] winnerSeries = new Team[numberMatches];

            for (int i = 0; i < playsArray.Length; i++)   //playArray is a collection of Play(s) which is a collection of Team(s)
            {
                playsArray[i] = new Play();
                winnerSeries[i] = new Team();
            }
            

            // ########## Main Menu with implementation ##################################

            while (true)
            {
                string input = "";
                Menu.Display();
                input = Console.ReadLine();
                input = input.ToUpper();

                if (input == "A")   // Enter all teams 
                {
                    while (true)
                    {
                        string teamsInput = "";

                        Menu.EnterTeamsSubMenu();
                        teamsInput = Console.ReadLine();
                        teamsInput = ErrorChecking.EnsureDigit(teamsInput);
                        teamsInput = ErrorChecking.EnsureLength(teamsInput);
                        if (teamsInput == "1")
                        {
                            // put more details in later (members, etc)
                            for (int i = 0; i < teams.Length; i++)
                            {
                                teams[i].EnterName(teams[i]);               // Method from Team.cs
                            }
                        }
                        else if (teamsInput == "2")
                        {

                            Console.WriteLine("Please select from the following teams: ");
                            for (int i = 0; i < teams.Length; i++)
                            {
                                teams[i].DisplayName(teams[i]);                                 // from Team.cs
                                Console.WriteLine("-------------------------------");
                            }

                            // Match Teams in competitions
                            Console.WriteLine($"length: {teams.Length}");
                            playsArray = Rounds.MatchTeams(teams);

                        }
                        else if (teamsInput == "3") //exit to main menu
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
                    Console.WriteLine("scores are now calculated"); // include conditional statements so it doesn't always display
                }
                else if (input == "D")
                {
                    while (true)
                    {
                        Menu.DisplaySubMenu();
                        string displayInput = "";
                        displayInput = Console.ReadLine();
                        displayInput = ErrorChecking.EnsureDigit(displayInput);
                        displayInput = ErrorChecking.EnsureLength(displayInput);

                        if (displayInput == "1") // display all teams
                        {
                            Console.WriteLine("Here is a list of all teams: ");
                            for (int i = 0; i < teams.Length; i++)
                            {
                                teams[i].DisplayTeam(teams[i]);                                 // from Team.cs
                                Console.WriteLine("-------------------------------");
                            }
                            Console.WriteLine("################################################################");

                        }
                        else if (displayInput == "2") // display matched teams
                        {
                            bool ArrayIsNull = false;
              // ***************************************************************************************************
                            for (int i = 0; i < playsArray.Length; i++) // need to add error checking if teams are null or playsarray are null then don't do the following, otherwise the program crashes if no team names are entered and they are not matched
                            {
                                if (playsArray[i].teamOne.score == 0)        // testing for any scores not entered yet
                                {
                                    
                                    Console.WriteLine("please enter a score or create a team and try again");
                                    ArrayIsNull = true;
                                    break;
                                }
                                if (playsArray[i].teamTwo.score == 0)
                                {
                                    Console.WriteLine("please enter a score or create a team and try again");
                                    ArrayIsNull = true;
                                    break;
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
                        else if (displayInput == "3") // winners
                        {
                            for (int i = 0; i < winnerSeries.Length; i++)
                            {
                                Console.WriteLine("Winners are: ");
                                Console.WriteLine($"Name: {winnerSeries[i].name}");
                                Console.WriteLine($"Score: {winnerSeries[i].score}");
                            }
                            Console.WriteLine($"length: {winnerSeries.Length}");
                        }
                        else if (displayInput == "4") // exit to main menu
                        {
                            break;
                        }
                        else
                        {
                            // error
                        }
                    }

                }else if (input == "E") // enter another round of tournaments
                {
                    string matchInput = "";
                    
                    Console.WriteLine("1. Match Teams");
                    Console.WriteLine("2. Enter Scores");
                    matchInput = Console.ReadLine();

                    if (matchInput == "1")
                    {
                        playsArray = Rounds.MatchTeams(winnerSeries);

                    }if (matchInput == "2")
                    {
                        bool nullFlag = false;
                        for (int i = 0; i < playsArray.Length; i++)
                        {
                            if (playsArray[i].teamOne.name == null || playsArray[i].teamTwo.name == null)
                            {
                                nullFlag = true;
                            }
                            else
                            {
                                Console.Write($"{playsArray[i].teamOne.name}: ");
                                teams[i].EnterScores(playsArray[i].teamOne);                     // from Team.cs

                                Console.Write($"{playsArray[i].teamTwo.name}: ");
                                teams[i].EnterScores(playsArray[i].teamTwo);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter one of the options displayed");
                    }

                    
                    

                    
                }
                else if (input == "F") // find team name
                {

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
                        Menu.UpdateMenu();
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
                else if (input == "Q") //exit
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
