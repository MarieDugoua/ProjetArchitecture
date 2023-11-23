namespace ProjetArchitecture.MarsRover;

using ProjetArchitecture.Command;
using ProjetArchitecture.Topology;

public class Rover
{
    public Position Position { get; private set; }
    public Planet Planet { get; private set; }
    public Orientation Orientation { get; private set; }
    private readonly Navigator _navigator;

    public Rover(Position initialPosition, Orientation orientation, Navigator navigator)
    {
        Position = initialPosition;
        Orientation = orientation;
        _navigator = navigator;
    }
    internal void ExecuteCommand(Command command)
    {
        switch (command)
        {
            case Command.Advance:
                Position = _navigator.Move(Position, Orientation);
                break;
            case Command.Reverse:
                Position = _navigator.Move(Position, Orientation, true);
                break;
            case Command.TurnLeft:
                Orientation = (Orientation)(((int)Orientation + 3) % 4);
                break;
            case Command.TurnRight:
                Orientation = (Orientation)(((int)Orientation + 1) % 4);
                break;
        }
    }

    public override string ToString()
    {
        return $"Position: ({Position.X}, {Position.Y}), Orientation: {Orientation}";
    }
}