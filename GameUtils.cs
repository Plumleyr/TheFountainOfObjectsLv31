using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public class GameUtils
    {

        public static void DisplayElaspedTime(DateTime startTime)
        {
            DateTime endTime = DateTime.Now;
            TimeSpan timeLeft = endTime - startTime;

            Console.WriteLine($"This run lasted {timeLeft.Hours} hours, {timeLeft.Minutes} minutes and {timeLeft.Seconds} seconds.");
        }

        public static void DisplayStartingDialogue(Game game)
        {
            Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects.");
            Console.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.");
            Console.WriteLine("You must navigate the Caverns with your other senses.");
            Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.\n");
            Console.WriteLine($"Row: {game.Cave.Entrance.Row}, Col: {game.Cave.Entrance.Col} is the entrance of the Cave. Don't Forget!\n");
        }

        public static CaveSizes SelectCaveSize()
        {
            CaveSizes[] caveSizesArr = Enum.GetValues<CaveSizes>();

            Console.WriteLine("Hello! What size map would you like to play? Enter an integer shown below:");

            int input;
            do
            {
                for (int i = 0; i < caveSizesArr.Length; i++)
                {
                    Console.WriteLine($"{i}: {caveSizesArr[i]}");
                }
                input = int.TryParse(Console.ReadLine() ?? "-1", out int value) ? value : -1;
                if(input < 0 || input >= caveSizesArr.Length)
                {
                    Console.WriteLine($"Please enter a valid integer from 0 to {caveSizesArr.Length}");
                }

            } while (input < 0 || input >= caveSizesArr.Length);

            Console.Clear();
            return (CaveSizes)input;
        } 

        public static GameStatus CheckGameStatus(Game game)
        {
            if (!game.Player.Alive)
                return GameStatus.Lost;

            if (game.Player.RestoredFountain && game.Player.Position.Row == game.Cave.Entrance.Row && game.Player.Position.Col == game.Cave.Entrance.Col)
                return GameStatus.Won;

            return GameStatus.InProgress;
        }

        public static void DisplayMoves(List<(Moves move, int moveValue)> movesList)
        {
            for (int i = 0; i < movesList.Count; i++)
            {
                Console.WriteLine($"{movesList[i].moveValue}: {movesList[i].move}");
            }
        }

        public static void DisplayEndMessage(GameStatus gameStatus)
        {
            if (gameStatus == GameStatus.Won)
            {
                Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\r\nYou win!");
            }

            if (gameStatus == GameStatus.Lost)
            {
                Console.WriteLine("YOU DIED! You have failed to reactivate the Fountain of Objects.");
            }
        }
    }
}
