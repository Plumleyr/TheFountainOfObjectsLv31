using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsLv31
{
    public abstract class Obstacle
    {
        public abstract Obstacles ObstacleType { get; init; }

        public abstract void DisplayDialogue();

        public abstract void Interaction(Player player);
    }

    public enum Obstacles
    {
        Fountain,
        Pit,
        None
    }
}
