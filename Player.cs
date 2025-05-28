using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public class Player(int startingRow, int startingCol)
    {
        public string Name = "Adventurer";

        public bool RestoredFountain { get; set; } = false;

        public bool Alive { get; set; } = true;

        public Position Position { get; set; } = new(startingRow, startingCol);

        public void MoveBy(int dRow, int dCol)
        {
            Position = new Position(Position.Row + dRow, Position.Col + dCol);
        }
    }
}
