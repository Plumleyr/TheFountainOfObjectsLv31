using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public class Game
    {
        public Player Player { get; private set; } = new();

        public Cave Cave { get; private set; } = new(4, 4);

        public GameStatus GameStatus { get; private set; } = GameStatus.InProgress;

        public void CheckGameStatus()
        {
            if (!Player.Alive)
                GameStatus = GameStatus.Lost;

            if (Player.RestoredFountain && Player.Row == 0 && Player.Col == 0)
                GameStatus = GameStatus.Won;
        }

        public void Run()
        {
            Cave.SetRooms();

            Console.WriteLine("Row: 0, Col: 0 is Top Left of the Cave.");

            while (GameStatus == GameStatus.InProgress)
            {
                var movesList = Move.AvailableMoves(Cave.CaveRooms, Player);

                bool validResponse = false;


                Room currRoom = Cave.CaveRooms[Player.Row, Player.Col];

                if (currRoom.Obstacle.ObstacleType == Obstacles.Pit)
                {
                    currRoom.Obstacle.Interaction(Player);
                    CheckGameStatus();
                }

                while (!validResponse && GameStatus == GameStatus.InProgress)
                {
                    Cave.CheckAdjRooms(currRoom);

                    Console.WriteLine($"{Player.Name} you are in the room at (Row = {Player.Row}, Column = {Player.Col})");
                    Console.WriteLine("Choose which Moves you'd like to go:");
                    for (int i = 0; i < movesList.Count; i++)
                    {
                        Console.WriteLine($"{i}: {movesList[i]}");
                    }

                    int input = int.TryParse(Console.ReadLine(), out int value) ? value : -1;

                    if (input >= 0 && input < movesList.Count)
                    {
                        Console.Clear();
                        Move.MovePlayer(movesList[input], Player, currRoom.Obstacle);
                        CheckGameStatus();

                        validResponse = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please choose a valid move.");
                    }
                }
            }

            if(GameStatus == GameStatus.Won)
            {
                Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\r\nYou win!");
            }
            
            if(GameStatus == GameStatus.Lost)
            {
                Console.WriteLine("YOU DIED! You have failed to reactivate the Fountain of Objects.");
            }
        }
    }

    public enum GameStatus
    {
        InProgress,
        Won,
        Lost
    }
}
