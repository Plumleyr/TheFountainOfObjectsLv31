using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public static class Move
    {
        public static void MovePlayer(Moves Moves, Player player, Obstacle obstacle)
        {
            switch (Moves)
            {
                case Moves.Up:
                    player.Row--;
                    break;
                case Moves.Right:
                    player.Col++;
                    break;
                case Moves.Down:
                    player.Row++;
                    break;
                case Moves.Left:
                    player.Col--;
                    break;
                case Moves.EnableFountain:
                    obstacle.Interaction(player);
                    break;
                default:
                    break;
            };
        }

        public static List<Moves> AvailableMoves(Room[,] cave, Player player)
        {
            Moves[] moves = Enum.GetValues<Moves>();

            List<Moves> MovesList = [];

            // This works whilst Moves enum is in order of { Up = 0, Down = 1, Left = 2, Right = 3, EnableFountain = 4 } as the values correlate to the Moves the player would move in the col / row of the cave.
            int[] dRows = [-1, 1, 0, 0];
            int[] dCols = [0, 0, -1, 1];

            int maxRows = cave.GetLength(0);
            int maxCols = cave.GetLength(1);

            for(int i = 0; i < 4; i++)
            {
                int newRow = dRows[i] + player.Row;
                int newCol = dCols[i] + player.Col;

                if(newRow >= 0 && newRow < maxRows && newCol >= 0 && newCol < maxCols)
                {
                    MovesList.Add(moves[i]);
                }

            }

            if(player.Row == 2 && player.Col == 2 && !player.RestoredFountain)
            {
                MovesList.Add(Moves.EnableFountain);
            }

            return MovesList;
        }

    }

    public enum Moves
    {
        Up,
        Down,
        Left,
        Right,
        EnableFountain
    }
}
