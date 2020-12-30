using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker.Classes
{
    class SeriesRounds // describes on round of a tournament with greater than two matches
    {
        public string name { get; set; }
        public Round roundOne { get; set; }
        public Round roundTwo { get; set; }
        public Round roundThree { get; set; }
        public Round roundFour { get; set; }
        public Round roundFive { get; set; }
        public Round roundSix { get; set; }
        public Round roundSeven { get; set; }
        public Round roundEight { get; set; }
        public Round roundNine { get; set; }
        public Round roundTen { get; set; }
    }
}
