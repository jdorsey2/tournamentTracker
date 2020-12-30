using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter how many teams there are, only enter an even number");

            string sizeTeams = Console.ReadLine();
            sizeTeams = Classes.ErrorChecking.EnsureDigit(sizeTeams);         // from ErrorChecking.cs
            sizeTeams = Classes.ErrorChecking.EnsureLength(sizeTeams);    // from ErrorChecking.cs
            int numberTeams = Int32.Parse(sizeTeams);
            numberTeams = Classes.ErrorChecking.EnsureEven(numberTeams);  // from ErrorChecking.cs
          
            int originalNumber = numberTeams;

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

            }
            else if (leftOutAmount > 2) // set odd number 3 or greater to add matching teams to counter with one being left over
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
       
    // **************************************************************************************************************
            int numberRounds = counter; // s

            // numberRounds is the amount of times you press the calculate winner button: decrement after calculating winner
            // if (numberRounds > 0) then you can calculate winner, else error : no more matches
            // after calculation of winner: numberRounds--;

            // ***************************************************************************************************
            Classes.Team[] originalTeams = new Classes.Team[originalNumber];

            for (int i = 0; i < originalTeams.Length; i++)
            {
                originalTeams[i] = new Classes.Team();
            }

            int numberOfMatches = originalNumber / 2;
            Classes.Matches[] originalMatches = new Classes.Matches[numberOfMatches];
            for (int i = 0; i < originalMatches.Length; i++)
            {
                originalMatches[i] = new Classes.Matches();
            }

            int numberOfWinners = numberOfMatches;
            Classes.Team[] originalWinners = new Classes.Team[numberOfWinners];
            for (int i = 0; i < originalWinners.Length; i++)
            {
                originalWinners[i] = new Classes.Team();
            }
            
            while (true)
            {
                Classes.Menu.TestDisplayMainMenu();
                string input = Console.ReadLine();
                input = input.ToUpper();
                input = Classes.ErrorChecking.EnsureEmptyLines(input);
                input = Classes.ErrorChecking.EnsureLength(input);

                if (input == "A") // enter team names
                {
                    for (int i = 0; i < originalTeams.Length; i++)
                    {
                        originalTeams[i] = originalTeams[i].EnterTeamName(originalTeams[i]);
                    }
                }else if (input == "B") //name team matches
                {
                    for (int i = 0; i < originalMatches.Length; i++)
                    {
                        originalMatches[i] = originalMatches[i].EnterNameMatch(originalMatches[i]);
                    }
                }else if (input == "C") //enter team matches
                {
                    for (int i = 0; i < originalMatches.Length; i++)
                    {
               
                        Classes.Matches inputMatch = new Classes.Matches();

                        Console.WriteLine("Please enter name of match you want to put teams into");
                        Console.WriteLine("Select from the following:");
                        for (int x = 0; x < originalMatches.Length; x++)
                        {
                            Console.WriteLine(originalMatches[x].name);
                        }
                        Console.WriteLine();
                        string matchInput = Console.ReadLine();
                        matchInput = matchInput.ToUpper();
                        matchInput = Classes.ErrorChecking.EnsureEmptyLines(matchInput);
                        matchInput = Classes.ErrorChecking.EnsureLength(matchInput);

                        inputMatch = inputMatch.SearchForMatch(matchInput, originalMatches);

                        Classes.Team inputOneTeam = new Classes.Team();
                        Console.WriteLine("Enter two teams you want to match");
                        Console.WriteLine("Please select from the following");
                        for (int x = 0; x < originalTeams.Length; x++)
                        {
                            Console.WriteLine(originalTeams[x].name);
                        }
                        Console.WriteLine();
                        string teamOneInput = Console.ReadLine();
                        teamOneInput = teamOneInput.ToUpper();
                        teamOneInput = Classes.ErrorChecking.EnsureEmptyLines(teamOneInput);
                        teamOneInput = Classes.ErrorChecking.EnsureLength(teamOneInput);

                        inputOneTeam = inputOneTeam.SearchForTeam(teamOneInput, originalTeams);

                        Classes.Team inputTwoTeam = new Classes.Team();
                        Console.WriteLine("enter second team");
                        string teamTwoInput = Console.ReadLine();
                        teamTwoInput = teamTwoInput.ToUpper();
                        teamTwoInput = Classes.ErrorChecking.EnsureEmptyLines(teamTwoInput);
                        teamTwoInput = Classes.ErrorChecking.EnsureLength(teamTwoInput);

                        inputTwoTeam = inputTwoTeam.SearchForTeam(teamTwoInput, originalTeams);

                        inputMatch = inputMatch.ConvertTeamToMatch(inputMatch, inputOneTeam, inputTwoTeam);
                       
                        originalMatches[i] = inputMatch;
                    }

                    
                }else if (input == "D") // enter scores
                {
                    Console.WriteLine("Please enter scores by match");
                    for (int i = 0; i < originalMatches.Length; i++)
                    {
                        originalMatches[i] = originalMatches[i].EnterScoreOfTeamsbyMatch(originalMatches[i]);
                    }
                    Console.WriteLine("Please enter scores by team");
                    for (int i = 0; i < originalTeams.Length; i++)
                    {
                       
                        originalTeams[i] = originalTeams[i].EnterTeamScore(originalTeams[i]);
                    }    
                }else if (input == "E") // calculate winner
                {
                    for (int i = 0; i < originalMatches.Length; i++)
                    {
                        originalWinners[i] = originalMatches[i].CompareScores(originalMatches[i].teamOne, originalMatches[i].teamTwo);
                    }
                }else if (input =="F") // display
                {
                    while (true)
                    {
                        Console.WriteLine("1. Display Teams. 2. Display Matches. 3. Display Winners. 4. Exit");
                        string displayInput = Console.ReadLine();
                        displayInput = Classes.ErrorChecking.EnsureEmptyLines(displayInput);
                        displayInput = Classes.ErrorChecking.EnsureLength(displayInput);
                        displayInput = Classes.ErrorChecking.EnsureDigit(displayInput);

                        if (displayInput == "1")
                        {
                            for (int i = 0; i < originalTeams.Length; i++)
                            {
                                originalTeams[i].DisplayTeam(originalTeams[i]);
                            }
                        }
                        else if (displayInput == "2")
                        {
                            for (int i = 0; i < originalMatches.Length; i++)
                            {
                                originalMatches[i].DisplayMatch(originalMatches[i]);
                            }
                        }
                        else if (displayInput == "3")
                        {
                            for (int i = 0; i < originalWinners.Length; i++)
                            {
                                originalWinners[i].DisplayTeam(originalWinners[i]);
                            }

                        }else if (displayInput == "4")
                        {
                            break;
                        }else
                        {
                            Console.WriteLine("Please enter one of the options");
                        }
                    }
                }
            }
            








            // **** Displays one round**************************************************
            // start
            //Classes.Round round = new Classes.Round();
            //Classes.Matches match = new Classes.Matches();
            //Classes.Matches matchTwo = new Classes.Matches();
            //Classes.Team team = new Classes.Team();
            //Classes.Team teamTwo = new Classes.Team();
            //Classes.Team teamThree = new Classes.Team();
            //Classes.Team teamFour = new Classes.Team();


            //team = team.CreateWriteToTeam();
            //teamTwo = teamTwo.CreateWriteToTeam();
            //teamThree = teamThree.CreateWriteToTeam();
            //teamFour = teamFour.CreateWriteToTeam();
            //match = match.TeamToMatch(team, teamTwo);
            ////match = match.EnterMatch();
            //matchTwo = match.TeamToMatch(teamThree, teamFour);
            //round = round.MatchToRound(match, matchTwo);

            // end
            // ************Displays one round ********************************************


            Console.ReadLine();

        }
    }
}
