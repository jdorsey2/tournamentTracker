/*
 * Displays Pictoral Graph, 
 * Something to have fun with, it doesn't work yet
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Tracker_3
{
    class Graphical
    {
        static void DisplayBox(string name)
        {
            Console.WriteLine($" ________________");
            Console.WriteLine($"|                |");
            Console.WriteLine($"|     {name}      |");
            Console.WriteLine($"|________________|");
           
        }

        static void DisplayConnector()
        {
            Console.WriteLine("              ");
            Console.WriteLine("______________");
            Console.WriteLine("______________");
            Console.WriteLine("              ");
        }
        public static void Display(Play[] play) // need to set the index of play to teamExists index to get accurate result
        {
            // index of play will be half of teamExists
            //for (int i = 0; i < play.Length; i++)
            //{
            //    if (play[i].exist == true)
            //    {
            //       DisplayBox(play[i].teamOne.name);
            //       DisplayBox(play[i].teamTwo.name);
            //    }
            //}






            // dynamic boxes: amount of boxes respond to amount of array sizes?
            // if (exists) {print a box}
             // {there exists a team}
               // if (teamExists[0] is true) {call a method which prints a box}
               // if (teamExists[1] is true) {call a method which prints a connector and a box}
            //Console.WriteLine(" ________________");
            //Console.WriteLine("|                |______________");
            //Console.WriteLine("|                |______________|");
            //Console.WriteLine("|________________|              |");
            //Console.WriteLine("                                |");
            //Console.WriteLine(" ________________               |");
            //Console.WriteLine("|                |______________|");
            //Console.WriteLine("|                |______________|");
            //Console.WriteLine("|________________|              |");
            //Console.WriteLine("                                |");
            //Console.WriteLine(" ________________               |");
            //Console.WriteLine("|                |______________|");
            //Console.WriteLine("|                |______________|");
            //Console.WriteLine("|________________|              |");
            //Console.WriteLine("                                |");
            //Console.WriteLine(" ________________               |");
            //Console.WriteLine("|                |______________|");
            //Console.WriteLine("|                |______________|");
            //Console.WriteLine("|________________|");
        }
    }
}
