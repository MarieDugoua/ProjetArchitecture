using ProjetAarchitecture.Topologie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAarchitecture.MarsRover
{
    public class Rover
    {
        public Position Position { get; private set; }
        public Orientation Orientation { get; private set; }
        private readonly Navigator _navigator;

        public Rover(Position initialPosition, Orientation orientation, Navigator navigator)
        {
            Position = initialPosition;
            Orientation = orientation;
            _navigator = navigator;
        }
    }
}
