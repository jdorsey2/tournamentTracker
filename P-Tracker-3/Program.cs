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

namespace Tracker
{
    class Program
    { /// <summary>
    /// /////////////////////////////////// after tournament round is done need to set the scores to zero
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            //######### Determines array sizes ###########################################

            int numberTeams = 0;
            bool keepGoing = true;
            int originalNumber = 0;
            int newNumberOfTeams = 0;
            int sizeFirstArray = 0;
            while (keepGoing)       // error checking 
            {
                keepGoing = false;

                Menu.SuperMenu();
                string inputMain = Console.ReadLine();
                inputMain = inputMain.ToUpper();
                inputMain = ErrorChecking.EnsureLength(inputMain);
                inputMain = ErrorChecking.EnsureEmptyLines(inputMain);
                
                if (inputMain == "A")
                {
                    string size = "";
                    Console.WriteLine("Please enter how many teams there are, only enter an even number");

                    size = Console.ReadLine();
                    size = ErrorChecking.EnsureDigit(size);         // from ErrorChecking.cs
                    size = ErrorChecking.EnsureLength(size);    // from ErrorChecking.cs
                    numberTeams = Int32.Parse(size);
                    numberTeams = ErrorChecking.EnsureEven(numberTeams);  // from ErrorChecking.cs

                    originalNumber = numberTeams;
                    sizeFirstArray = numberTeams;

              //******************************* Calculates number of tournaments ****************************************
                    int counter = 0;
                    int numberOneLess = 0;
                    int leftOutAmount = 0;
                    bool cannotCompete = false;
                    
                    bool flag = true;
                    while (flag)
                    {
                        numberOneLess = numberTeams - 1;

                        if (numberTeams == 1)
                        {
                            break;
                        }

                        if (numberTeams % 2 == 0)
                        {
                            numberTeams = numberTeams / 2;
                            counter++;

                        }
                        else if ((numberOneLess) % 2 == 0)
                        {
                            numberOneLess = numberOneLess / 2;
                            counter++;
                            leftOutAmount++;
                            cannotCompete = true;       // if there is one team left over because odd number of teams: so cannot com
                            numberTeams = numberOneLess;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    if (leftOutAmount % 2 == 0) // add it to the counter amount
                    {
                        counter = counter + leftOutAmount;
                        leftOutAmount = 0;
                        cannotCompete = false;

                    }else if (leftOutAmount > 2) // set odd number 3 or greater to add matching teams to counter with one being left over
                    {
                        leftOutAmount = leftOutAmount - 1;
                    }
                    if (cannotCompete == true)
                    {
                        Console.WriteLine($"you entered {originalNumber} teams, in the course of the game play, you will have {leftOutAmount} team(s) left out,");
                        Console.WriteLine("at least one team will have to play an extra time to account for this");
                    }
                    Console.WriteLine();
                    Console.WriteLine($"With {originalNumber} teams, you can play {counter} rounds");

                    int numberPossibleRounds = counter; // decrement after each round of tournaments: have finish display when it reaches 0/1

                    //**************************** Calculate number of teams for next round ***********************************
                    // needs to be moved to a different menu, it is out of its proper scope

                    //newNumberOfTeams = originalNumber;
                    //int newTeamsLessOne = newNumberOfTeams - 1;

                    //if (newNumberOfTeams != 1)
                    //{
                    //    if (newNumberOfTeams % 2 == 0)
                    //    {
                    //        newNumberOfTeams = newNumberOfTeams / 2;
                    //        originalNumber = newNumberOfTeams;
                    //    }
                    //    if (newTeamsLessOne % 2 == 0)
                    //    {
                    //        newNumberOfTeams = (newTeamsLessOne / 2) + 1;
                    //        originalNumber = newNumberOfTeams;
                    //    }
                    //}else
                    //{
                    //    Console.WriteLine("Please enter a value greater than one");
                    //}











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
                    //Help.Pages();
                }else
                {
                    Console.WriteLine("Please select either A, B, C, or D");
                    keepGoing = true;
                }
            }

            //######### Global Variables ################################################
            
            
            Team[] teams = new Team[sizeFirstArray]; // change the variable that sizes these arrays

            for (int i = 0; i < teams.Length; i++)
            {
                teams[i] = new Team();
            }
            // *************************************************************************************** change size of array to ...when each round is played size should half
            newNumberOfTeams = sizeFirstArray / 2;
            Play[] playsArray = new Play[newNumberOfTeams];    // matches teams into competing teams so their is half as many objects
            Team[] winnerSeries = new Team[newNumberOfTeams];

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
                input = ErrorChecking.EnsureLength(input);
                input = ErrorChecking.EnsureEmptyLines(input);
                if (input == "A") // help topics
                {

                }else if (input == "B")   // managing first round
                {
                    while (true)
                    {
                        string teamsInput = "";

                        Menu.PlayingFirstRoundSubMenu();
                        teamsInput = Console.ReadLine();
                        teamsInput = ErrorChecking.EnsureDigit(teamsInput);
                        teamsInput = ErrorChecking.EnsureLength(teamsInput);
                        if (teamsInput == "1")                                  // enter team names
                        {
                            // put more details in later (members, etc)
                            for (int i = 0; i < teams.Length; i++)
                            {
                                teams[i].EnterName(teams[i]);               // Method from Team.cs
                            }
                        }
                        else if (teamsInput == "2")                    // match teams
                        {

                            Console.WriteLine("Please select from the following teams: ");
                            for (int i = 0; i < teams.Length; i++)
                            {
                                teams[i].DisplayName(teams[i]);                                 // from Team.cs
                                Console.WriteLine("-------------------------------");
                            }

                            Console.WriteLine($"length: {teams.Length}");
                            playsArray = Rounds.MatchTeams(teams);

                        }
                        else if (teamsInput == "3") //enter scores
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
                        else if (teamsInput == "4") // calculate winner
                        {
                            for (int i = 0; i < playsArray.Length; i++)
                            {
                                winnerSeries[i] = playsArray[i].CompareScores(playsArray[i].teamOne, playsArray[i].teamTwo); // from Play.cs
                            }
                            Console.WriteLine("scores are now calculated"); // include conditional statements so it doesn't always display

                        }
                        else if (teamsInput == "5") // display menu
                        {
                            string displayInput = "";
                            while (true)
                            {
                                Console.WriteLine("A: display teams");
                                Console.WriteLine("B: display matches");
                                Console.WriteLine("C: display winners");
                                Console.WriteLine("D: exit to Main Menu");
                                displayInput = Console.ReadLine();
                                displayInput = displayInput.ToUpper();
                                displayInput = ErrorChecking.EnsureLength(displayInput);
                                displayInput = ErrorChecking.EnsureEmptyLines(displayInput);

                                if (displayInput == "A") // display teams
                                {
                                    Console.WriteLine("Here is a list of all teams: ");
                                                             for (int i = 0; i<teams.Length; i++)
                                                                {
                                                                    teams[i].DisplayTeam(teams[i]);                                 // from Team.cs
                                            Console.WriteLine("-------------------------------");
                                                                }
                                        Console.WriteLine("################################################################");
                                }
                                else if (displayInput == "B") // display matches
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

                                        Console.WriteLine("Here is the breakdown according to who plays who: ");

                                        Team[] teamArray = new Team[2]; // new array of teams for storage
                                        for (int j = 0; j < teamArray.Length; j++)
                                        {
                                            teamArray[j] = new Team();
                                        }

                                        while (!ArrayIsNull)
                                        {
                                            ArrayIsNull = true;
                                            for (int k = 0; k < playsArray.Length; k++)
                                            {
                                                teamArray = playsArray[k].ConvertFromPlayToTeamArray(playsArray[k]);    // from Play.cs

                                                for (int j = 0; j < teamArray.Length; j++)
                                                {
                                                    teamArray[j].DisplayTeam(teamArray[j]);                      // from Team.cs
                                                }
                                                Console.WriteLine("------------------------------------------");
                                            }
                                        }
                                    }
                                }
                                else if (displayInput == "C") // display winners
                                {
                                    for (int i = 0; i < winnerSeries.Length; i++)
                                    {
                                        Console.WriteLine("Winners are: ");
                                        Console.WriteLine($"Name: {winnerSeries[i].name}");
                                        Console.WriteLine($"Score: {winnerSeries[i].score}");
                                    }
                                    Console.WriteLine($"length: {winnerSeries.Length}");
                                }
                                else if (displayInput == "D") // exit
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter one of the options provided");
                                } 
                            }

                        }else if (teamsInput == "6") // exit to main menu
                        {
                            break;
                        }else
                        {
                            Console.WriteLine("Please select one of the sub-menu options");
                        }
                    }

                }   
                else if (input == "C")  //  Managing successive rounds
                {
                    string matchInput = "";

                    while (true)
                    {
                        Menu.successiveRoundsSubMenu();
                        matchInput = Console.ReadLine();

                        if (matchInput == "1")
                        {
                            playsArray = Rounds.MatchTeams(winnerSeries);

                        }
                        else if (matchInput == "2")
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
                        else if (matchInput == "3")
                        {

                        }
                        else if (matchInput == "4")
                        {

                        }
                        else if (matchInput == "5")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter one of the options displayed");
                        } 
                    }

                } 
                else if (input == "D") //Find name/team
                {
                    
                }
                else if (input == "E") // graphical display
                {
                    Graphical.Display(playsArray);

                } // graphical display
                else if (input == "F") // update/delete team
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

                } // update/delete team
                else if (input == "G") // to save
                {

                }
                else if (input == "H") // to exit program
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
