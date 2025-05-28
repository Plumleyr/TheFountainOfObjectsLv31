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
                    player.MoveBy(-1, 0);
                    break;
                case Moves.Right:
                    player.MoveBy(0, 1);
                    break;
                case Moves.Down:
                    player.MoveBy(1, 0);
                    break;
                case Moves.Left:
                    player.MoveBy(0, -1);
                    break;
                case Moves.EnableFountain:
                    obstacle.Interaction(player);
                    break;
                default:
                    break;
            };
        }

        public static List<(Moves move, int moveValue)> AvailableMoves(Cave cave, Player player)
        {
            Moves[] moves = Enum.GetValues<Moves>();

            List<(Moves move, int moveValue)> MovesList = [];

            // This works whilst Moves enum is in order of { Up = 0, Down = 1, Left = 2, Right = 3, ...} as the values correlate to the Moves the player would move in the col / row of the cave.
            int[] dRows = [-1, 1, 0, 0];
            int[] dCols = [0, 0, -1, 1];

            int maxRows = cave.Rows;
            int maxCols = cave.Cols;

            for(int i = 0; i < 4; i++)
            {
                int newRow = dRows[i] + player.Position.Row;
                int newCol = dCols[i] + player.Position.Col;

                //makes sure move is inbounds if not won't display the direction
                if(newRow >= 0 && newRow < maxRows && newCol >= 0 && newCol < maxCols)
                {
                    MovesList.Add((moves[i], (int)moves[i]));
                }

            }

            //if player is in the room with the fountain displays fountain move
            if(player.Position.Row == cave.Fountain.Row && player.Position.Col == cave.Fountain.Col && !player.RestoredFountain)
            {
                MovesList.Add((Moves.EnableFountain, (int)Moves.EnableFountain));
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
