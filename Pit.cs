using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public class Pit : Obstacle
    {
        public override Obstacles ObstacleType { get; init; } = Obstacles.Pit;

        public override void DisplayDialogue()
        {
            Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
        }

        public override void Interaction(Player player)
        {
            Console.WriteLine("You have fallen in a pit.");
            player.Alive = false;
        }
    }
}
