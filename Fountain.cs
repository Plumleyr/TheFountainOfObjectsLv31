using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public class Fountain : Obstacle
    {
        public override Obstacles ObstacleType { get; init; } = Obstacles.Fountain;

        public override void DisplayDialogue()
        {
            Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
        }

        public override void Interaction(Player player)
        {
            player.RestoredFountain = true;
            Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
            Console.WriteLine("Get back to the entrance to escape!");
        }
    }
}
