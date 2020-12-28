﻿/*
 * Main Menu of Program and sub-menus
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Tracker_3
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
            Console.WriteLine("Please Select an option: To start select A first to set up teams, then select B to enter scores");
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("A. Setup a tournament");
            Console.WriteLine("B. Enter scores");
            Console.WriteLine("C. Calculate winner");
            Console.WriteLine("D. Display");
            Console.WriteLine("E. To set up another round of tournaments");
            Console.WriteLine("F. Find Name/Team");
            Console.WriteLine("G. Graphical Display");
            Console.WriteLine("U. Update/Delete teams");
            Console.WriteLine("S. To Save");
            Console.WriteLine("Q. To Exit this Program");
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

        public static void DisplaySubMenu()
        {
            Console.WriteLine();
            Console.WriteLine("####################################");
            Console.WriteLine("##### Sub-Menu: Display Options ####");
            Console.WriteLine("####################################");
            Console.WriteLine();
            Console.WriteLine("Please Select an option");
            Console.WriteLine("*************************************");
            Console.WriteLine("1. Display All Teams");
            Console.WriteLine("2. Display Matched Teams");
            Console.WriteLine("3. Display Winners");
            Console.WriteLine("4. Exit to Main Menu");
            Console.WriteLine("**************************************");
            Console.WriteLine();
        }

        public static void EnterTeamsSubMenu()
        {
            Console.WriteLine();
            Console.WriteLine("########################################");
            Console.WriteLine("##### Sub-Menu: Enter Teams Options ####");
            Console.WriteLine("########################################");
            Console.WriteLine();
            Console.WriteLine("Please Select an option");
            Console.WriteLine("***************************************");
            Console.WriteLine("1. Enter All Teams");
            Console.WriteLine("2. Match Teams Together");
            Console.WriteLine("3. Exit to Main Menu");
            Console.WriteLine("***************************************");
        }
    }
}
