using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public class CaveUtils
    {
        private static readonly Random rand = new();

        public static (int Rows, int Cols) GetDimensions(CaveSizes size) => size switch
        {
            CaveSizes.Small => (4, 4),
            CaveSizes.Medium => (6, 6),
            CaveSizes.Large => (8, 8),
            _ => throw new ArgumentOutOfRangeException(nameof(size), "Unsupported cave size.")
        };

        public static Position EntranceLocation(Cave cave)
        {
            int maxRow = cave.Rows - 1;
            int maxCol = cave.Cols - 1;
            int middleRow = cave.Rows / 2;
            int middleCol = cave.Cols / 2;

            Position[] potentialEntrances =
            [
                new Position(0, 0),                    // top-left
                new Position(0, middleCol),           // top-middle
                new Position(0, maxCol),              // top-right
                new Position(middleRow, 0),           // middle-left
                new Position(middleRow, maxCol),      // middle-right
                new Position(maxRow, 0),              // bottom-left
                new Position(maxRow, maxCol),         // bottom-right
            ];

            Position entrance = potentialEntrances[rand.Next(potentialEntrances.Length)];
            return entrance;
        }

        public static Position FountainLocation(Cave cave)
        {
            int fountainMiddleRow = cave.Rows / 2;
            int fountainMiddleCol = cave.Cols / 2;
            int fountainRow = rand.Next(fountainMiddleRow - 1, fountainMiddleRow + 1);
            int fountainCol = rand.Next(fountainMiddleCol - 1, fountainMiddleCol + 2);

            return new Position(fountainRow, fountainCol);
        }

        public static List<Position> PitLocation(Cave cave)
        {

            // Made sure to skip the surrounding areas of the entrance so game isn't unwinnable. The Out of Bounds positions don't matter since pit locations can only be in bounds.
            List<Position> excludedPositions = 
            [
                cave.Entrance,
                cave.Fountain,
                new Position(cave.Entrance.Row - 1, cave.Entrance.Col),
                new Position(cave.Entrance.Row + 1, cave.Entrance.Col),
                new Position(cave.Entrance.Row, cave.Entrance.Col - 1),
                new Position(cave.Entrance.Row, cave.Entrance.Col + 1),
            ];

            List<Position> pitLocationList = [];

            int pitRow;
            int pitCol;

            while(pitLocationList.Count < (int)cave.CaveSize)
            {
                pitRow = rand.Next(cave.Rows);
                pitCol = rand.Next(cave.Cols);
                var pos = new Position(pitRow, pitCol);

                if (!excludedPositions.Contains(pos))
                {
                    pitLocationList.Add(new Position(pitRow, pitCol));
                    excludedPositions.Add(new Position(pitRow, pitCol));
                }
            }
            return pitLocationList;
        }
    }
}
