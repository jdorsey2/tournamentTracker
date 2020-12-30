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
            Classes.Round round = new Classes.Round();
            Classes.Matches match = new Classes.Matches();
            Classes.Team team = new Classes.Team();
            //round = round.EnterRound();
            round.DisplayRound(round);

            Console.ReadLine();

        }
    }
}
