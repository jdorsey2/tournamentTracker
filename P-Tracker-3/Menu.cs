/*
 * Main Menu of Program and sub-menus
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker
{
    class Menu
    {
        public static void SuperMenu()
        {
            Console.WriteLine("Welcome to Tournament Tracker");
            Console.WriteLine();
            Console.WriteLine("Please select an option to continue: ");
            Console.WriteLine("A. To Create a new Tracker");
            Console.WriteLine("B. To load a previous Tracker");
            Console.WriteLine("C. To Exit program");
            Console.WriteLine("D. For a Tutorial on how to use Tournament Tracker");
        }
        public static void Display()
        {
            Console.WriteLine();
            Console.WriteLine("#####################");
            Console.WriteLine("##### Main Menu: ####");
            Console.WriteLine("#####################");
            Console.WriteLine();
            Console.WriteLine("Please Select an option:");
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("A. Set Up Tips and Help");
            Console.WriteLine("B. Playing the First Round");
            Console.WriteLine("C. Managing successive rounds");
            Console.WriteLine("D. Find Name/Team");
            Console.WriteLine("E. Graphical Display");
            Console.WriteLine("F. Update/Delete teams");
            Console.WriteLine("G. To Save");
            Console.WriteLine("H. To Exit this Program");
            Console.WriteLine("**************************************************************************************************");
            Console.WriteLine();
        }

        public static void UpdateMenu()
        {
            Console.WriteLine("#######################################");
            Console.WriteLine("#### Sub-Menu: Update/Delete teams ####");
            Console.WriteLine("#######################################");
            Console.WriteLine();
            Console.WriteLine("Please select an operation to perform");
            Console.WriteLine("***************************************");
            Console.WriteLine("1. To Update a team");
            Console.WriteLine("2. To Delete a team");
            Console.WriteLine("3. To Go back to the Main Menu");
            Console.WriteLine("****************************************");
            Console.WriteLine();
        }

        
        public static void PlayingFirstRoundSubMenu()
        {
            Console.WriteLine();
            Console.WriteLine("####################################################");
            Console.WriteLine("##### Sub-Menu: Playing the First Round Options ####");
            Console.WriteLine("####################################################");
            Console.WriteLine();
            Console.WriteLine("Please Select an option");
            Console.WriteLine("***************************************");
            Console.WriteLine("1. Enter Team names");
            Console.WriteLine("2. Match Teams Together");
            Console.WriteLine("3. Enter Scores");
            Console.WriteLine("4. Calculate Winner");
            Console.WriteLine("5. Display, teams, matches and winner");
            Console.WriteLine("7. continue to next round");
            Console.WriteLine("6. Exit to Main Menu");
            Console.WriteLine("***************************************");
        }

        public static void successiveRoundsSubMenu()
        {
            Console.WriteLine();
            Console.WriteLine("##############################################");
            Console.WriteLine("##### Sub-Menu: Successive Rounds Options ####");
            Console.WriteLine("##############################################");
            Console.WriteLine();
            Console.WriteLine("Please Select an option");
            Console.WriteLine("***************************************");
            Console.WriteLine("1. Match the Winners together for a new round");
            Console.WriteLine("2. Enter Scores");
            Console.WriteLine("3. Calculate Winner");
            Console.WriteLine("4. Display, teams, matches and winners");
            Console.WriteLine("5. Exit to Main Menu");
            Console.WriteLine("***************************************");
        }
    }
}
