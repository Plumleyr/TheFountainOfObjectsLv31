using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public class Room(int row, int col, Obstacle obstacle)
    {
        public Position Position { get; init; } = new Position(row, col);

        public Obstacle Obstacle { get; init; } = obstacle;
    }
}
