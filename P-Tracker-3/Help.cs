using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Tracker_3
{
    class Help
    {
        public static void Pages()
        {
            Console.WriteLine();
            Console.WriteLine($"Welcome to Tournament Tracker Help Me! Pages");
            Console.WriteLine();
            Console.WriteLine("This Tracker keeps track of any kind of tournament. You enter how many teams" +
                "you want to have if you create new teams by selecting option A. If this is your first time" +
                "here please press A to create a new tournament. ");

            Console.WriteLine();
            Console.WriteLine("To exit these help pages press enter");
            Console.ReadLine();
            Console.WriteLine("The Menu is below again");
        }
    }
}
