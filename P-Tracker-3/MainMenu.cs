/*
 * Main Menu of Program and sub-menus
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Tracker_3
{
    class MainMenu
    {
        public static void Display()
        {
            Console.WriteLine();
            Console.WriteLine("#####################");
            Console.WriteLine("##### Main Menu: ####");
            Console.WriteLine("#####################");
            Console.WriteLine();
            Console.WriteLine("Please Select an option: To start select A first to set up teams, then select B to enter scores");
            Console.WriteLine("*******************************************************************************************************************************************************************************************************************");
            Console.WriteLine("A. Setup a tournament------B. Enter scores------C. Calculate winner------D. Display------F. Find Name/Team------G. Graphical Display------U. Update/Delete teams------S. To Save------E. To Exit this Program");
            Console.WriteLine();
            Console.WriteLine("*******************************************************************************************************************************************************************************************************************");
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
            Console.WriteLine("-----------------------------");
            Console.WriteLine("2. To Delete a team");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("3. To Go back to the Main Menu");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("________________________________________________________________");
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
            Console.WriteLine("******************************************************************************************************");
            Console.WriteLine("A. Display All Teams------B. Display Matched Teams------C. Display Winners------E. Exit to Main Menu");
            Console.WriteLine();
            Console.WriteLine("*******************************************************************************************************");
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
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("A. Enter All Teams------B. Match Teams Together------C. Exit to Main Menu");
            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine();
        }
    }
}
