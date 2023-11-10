using ProjetAarchitecture.Commandes;
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
        internal void ExecuteCommand(Commands command)
        {
            switch (command)
            {
                case Commands.Advance:
                    Position = _navigator.Move(Position, Orientation);
                    break;
                case Commands.Reverse:
                    Position = _navigator.Move(Position, Orientation, true);
                    break;
                case Commands.TurnLeft:
                    Orientation = (Orientation)(((int)Orientation + 3) % 4);
                    break;
                case Commands.TurnRight:
                    Orientation = (Orientation)(((int)Orientation + 1) % 4);
                    break;
            }
        }

        public override string ToString()
        {
            return $"Position: ({Position.X}, {Position.Y}), Orientation: {Orientation}";
        }
    }
}
