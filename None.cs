using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public class None : Obstacle
    {
        public override Obstacles ObstacleType { get; init; } = Obstacles.None;

        public override void DisplayDialogue()
        {
            Console.Write("");
        }

        public override void Interaction(Player player)
        {
            Console.Write("");
        }
    }
}
