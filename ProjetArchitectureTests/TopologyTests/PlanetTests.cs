namespace ProjetArchitectureTests.TopologyTests;
using ProjetArchitecture.Topology;

[TestClass]
public class PlanetTests
{
    private Planet planet;
    private int width;
    private int height;
    private List<Obstacle> obstacles;

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
        Position pos = new Position(0, 1);
        Position newPos = planet.AdjustPosition(pos);
        Assert.AreEqual((newPos.X, newPos.Y), (0, 1));

        //Avance horizontalement de 1
        pos = new Position(1, 0);
        newPos = planet.AdjustPosition(pos);
        Assert.AreEqual((newPos.X, newPos.Y), (1, 1));
    }

    [TestMethod]
    public void HasObstacleAtTest()
    {
        Position pos = new Position(8, 1);
        bool res = obstacles.Any(p => p.Position.X == pos.X && p.Position.Y == pos.Y);
        if(!res)
        {
            Console.WriteLine("Aucun obtsacle à la position (8, 1).");
        }
        else
        {
            Console.WriteLine("Il y a une erreur.");
        }

        pos = new Position(2, 5);
        res = obstacles.Any(p => p.Position.X == pos.X && p.Position.Y == pos.Y);
        if(res)
        {
            Console.WriteLine("Il y a un obstacle à la position (2, 5).");
        }
        else
        {
            Console.WriteLine("Il y a une erreur.");
        }
    }

    [TestMethod]
    public void AddObstacleTest()
    {
        Obstacle obs = new Obstacle(6, 6);
        obstacles.Add(obs);
        bool res = obstacles.Any(p => p.Position.X == obs.Position.X && p.Position.Y == obs.Position.Y);
        if (res)
        {
            Console.WriteLine("L'obstacle a bien été ajouté.");
        }
        else
        {
            Console.WriteLine("Il y a une erreur. L'obstacle n'a pas été ajouté.");
        }
    }
}