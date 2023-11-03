using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAarchitecture.Topologie
{
    public class Obstacle
    {
        public Position Position { get; }

        public Obstacle(int x, int y)
        {
            Position = new Position(x, y);
        }
    }
}
