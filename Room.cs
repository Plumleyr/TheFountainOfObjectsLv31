using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public class Room(int row, int col, Obstacle obstacle)
    {
        public int Row { get; init; } = row;

        public int Col { get; init; } = col;

        public Obstacle Obstacle { get; init; } = obstacle;
    }
}
