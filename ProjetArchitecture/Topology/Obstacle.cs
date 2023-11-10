namespace ProjetArchitecture.Topology;

// Obstacle Class: Represents an obstacle's position.
public class Obstacle
{
    public Position Position { get; }

    public Obstacle(int x, int y)
    {
        Position = new Position(x, y);
    }
}
