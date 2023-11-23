namespace ProjetArchitectureTests.TopologyTests;
using ProjetArchitecture.Topology;

[TestClass]
public class PlanetTests
{
    private Planet planet;
    private int width;
    private int height;
    private List<Obstacle> obstacles = new List<Obstacle>();

    [TestInitialize]
    public void TestInitialize()
    {
        Obstacle obstacle = new Obstacle(2, 5);
        obstacles.Add(obstacle);
        planet = new Planet(10, 10, obstacles);
        width = planet.Width;
        height = planet.Height;
    }

    [TestMethod]
    public void AdjustPositionTest()
    {
        //Avance verticalement de 1
        Position pos = new Position(3, 9);
        Position newPos = planet.AdjustPosition(pos);
        Assert.AreEqual((newPos.X, newPos.Y), (3, 9));
    }

    [TestMethod]
    public void HasObstacleAtTestFalse()
    {
        Position pos = new Position(8, 1);
        bool res = obstacles.Any(p => p.Position.X == pos.X && p.Position.Y == pos.Y);
        Assert.IsTrue(!res);
    }

    [TestMethod]
    public void HasObstacleAtTestTrue()
    {
        Position pos = new Position(2, 5);
        bool res = obstacles.Any(p => p.Position.X == pos.X && p.Position.Y == pos.Y);
        Assert.IsTrue(res);
    }

    [TestMethod]
    public void AddObstacleTest()
    {
        Obstacle obs = new Obstacle(6, 6);
        obstacles.Add(obs);
        bool res = obstacles.Any(p => p.Position.X == obs.Position.X && p.Position.Y == obs.Position.Y);
        Assert.IsTrue(res);
    }
}