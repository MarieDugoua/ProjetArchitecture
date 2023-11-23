namespace ProjetArchitecture.MarsRover;

using ProjetArchitecture.Topology;

public class Navigator
{
    private readonly Planet _planet;

    public Navigator(Planet planet)
    {
        _planet = planet;
    }
    public Position Move(Position currentPosition, Orientation orientation, bool reverse = false)
    {
        Position nextPosition = new Position(currentPosition.X, currentPosition.Y);
        switch (orientation)
        {
            case Orientation.N:
                nextPosition.Y += reverse ? -1 : 1;
                break;
            case Orientation.E:
                nextPosition.X += reverse ? -1 : 1;
                break;
            case Orientation.S:
                nextPosition.Y += reverse ? 1 : -1;
                break;
            case Orientation.W:
                nextPosition.X += reverse ? 1 : -1;
                break;
        }

        nextPosition = _planet.AdjustPosition(nextPosition);

        if (_planet.HasObstacleAt(nextPosition))
        {
            return currentPosition;
        }

        return nextPosition;
    }
}