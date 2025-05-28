using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public class Cave
    {
        public CaveSizes CaveSize { get; init; }
        public Room[,] CaveRooms { get; private set; }
        public Position Entrance { get; private set; }
        public Position Fountain { get; private set; }
        public int Rows { get; }
        public int Cols { get; }
        
        public Cave(CaveSizes caveSize)
        {
            CaveSize = caveSize;
            (Rows, Cols) = CaveUtils.GetDimensions(CaveSize);
            CaveRooms = new Room[Rows, Cols];
            Fountain = CaveUtils.FountainLocation(this);
            Entrance = CaveUtils.EntranceLocation(this);
            SetRooms();
        }

        private void SetRooms()
        {

            var pitLocationList = CaveUtils.PitLocation(this);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (pitLocationList.Contains(new Position(i, j)))
                        CaveRooms[i, j] = new Room(i, j, new Pit());
                    else if (i == Fountain.Row && j == Fountain.Col)
                        CaveRooms[i, j] = new Room(i, j, new Fountain());
                    else
                        CaveRooms[i, j] = new Room(i, j, new None());
                }
            }
        }

        public void CheckAdjRooms(Room currRoom)
        {
            int currRow = currRoom.Position.Row;
            int currCol = currRoom.Position.Row;

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

    public enum CaveSizes
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }
}
