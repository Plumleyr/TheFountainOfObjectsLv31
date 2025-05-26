using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public class Player
    {
        public string Name = "Adventurer";

        public bool RestoredFountain { get; set; } = false;

        public bool Alive { get; set; } = true;

        public int Row { get; set; } = 0;

        public int Col { get; set; } = 0;
    }
}
