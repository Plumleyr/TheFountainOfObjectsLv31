using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public class Game
    {
        public Player Player { get; private set; } 

        public Cave Cave { get; private set; }

        public GameStatus GameStatus { get; private set; } = GameStatus.InProgress;

        public  Game()
        {
            Cave = new(GameUtils.SelectCaveSize());
            Player = new(Cave.Entrance.Row, Cave.Entrance.Col);
        }

        public void Run()
        {
            GameUtils.DisplayStartingDialogue(this);
            Console.WriteLine($"{Cave.Fountain.Row}, {Cave.Fountain.Col}");

            while (GameStatus == GameStatus.InProgress)
            {
                var movesList = Move.AvailableMoves(Cave, Player);
                Room currRoom = Cave.CaveRooms[Player.Position.Row, Player.Position.Col];

                if (currRoom.Obstacle.ObstacleType == Obstacles.Pit)
                {
                    currRoom.Obstacle.Interaction(Player);
                    GameStatus = GameUtils.CheckGameStatus(this);
                }

                bool validResponse = false;

                while (!validResponse && GameStatus == GameStatus.InProgress)
                {
                    Cave.CheckAdjRooms(currRoom);

                    Console.WriteLine($"{Player.Name} you are in the room at (Row = {Player.Position.Row}, Column = {Player.Position.Col})");

                    Console.WriteLine("Choose which Moves you'd like to go:");
                    GameUtils.DisplayMoves(movesList);

                    int input = int.TryParse(Console.ReadLine(), out int value) ? value : -1;

                    if (input >= 0 && input < movesList.Count)
                    {
                        Console.Clear();
                        Move.MovePlayer(movesList[input], Player, currRoom.Obstacle);
                        GameStatus = GameUtils.CheckGameStatus(this);

                        validResponse = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please choose a valid move.");
                    }
                }
            }

            GameUtils.DisplayEndMessage(GameStatus);
        }
    }

    public enum GameStatus
    {
        InProgress,
        Won,
        Lost
    }
}
