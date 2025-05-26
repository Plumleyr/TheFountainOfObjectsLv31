using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public class Cave(int rows, int cols)
    {
        public Room[,] CaveRooms { get; set; } = new Room[rows, cols];

        public void SetRooms()
        {

            var(pitRow, pitCol) = PitLocation();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 2 && j == 2)
                        CaveRooms[i, j] = new Room(i, j, new Fountain());
                    else if (i == pitRow && j == pitCol)
                        CaveRooms[i, j] = new Room(i, j, new Pit());
                    else
                        CaveRooms[i, j] = new Room(i, j, new None());
                }
            }
        }

        public (int pitRow, int pitCol) PitLocation()
        {
            Random rand = new();

            int pitRow;
            int pitCol;

            do
            {
                pitRow = rand.Next(rows);
                pitCol = rand.Next(cols);

            } while ((pitRow == 0 && pitCol == 0) || (pitRow == 2 && pitCol == 2));

            return (pitRow, pitCol);
        }

        public void CheckAdjRooms(Room currRoom)
        {
            int currRow = currRoom.Row;
            int currCol = currRoom.Col;

            List<Room> adjRooms = [];

            if (currRow + 1 < CaveRooms.GetLength(0)) adjRooms.Add(CaveRooms[currRow + 1, currCol]);
            if (currRow - 1 >= 0) adjRooms.Add(CaveRooms[currRow - 1, currCol]);
            if (currCol + 1 < CaveRooms.GetLength(1)) adjRooms.Add(CaveRooms[currRow, currCol + 1]);
            if (currCol - 1 >= 0) adjRooms.Add(CaveRooms[currRow, currCol - 1]);

            foreach (var room in adjRooms)
            {
                if (room.Obstacle.ObstacleType != Obstacles.Fountain)
                {
                    room.Obstacle.DisplayDialogue();
                }
            }
        }
    }
}
