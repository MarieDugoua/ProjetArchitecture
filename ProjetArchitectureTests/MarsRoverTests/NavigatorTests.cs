namespace ProjetArchitectureTests.MarsRoverTests;
using ProjetArchitecture.MarsRover;
using ProjetArchitecture.Topology;

[TestClass]
public class NavigatorTests
{
    private Planet planet;
    private Navigator navigator;

    [TestInitialize]
    public void TestInitialize()
    {
        planet = new Planet(10, 10);
        navigator = new Navigator(planet);
    }

    [TestMethod]
    public void MoveForwardTest()
    {
        Position pos = new Position(0, 0);
        Position newPos = navigator.Move(pos, Orientation.N);
        Assert.AreEqual((newPos.X, newPos.Y), (0, 1));
    }

    [TestMethod]
    public void MoveBackwardTest()
    {
        Position pos = new Position(0, 0);
        Position newPos = navigator.Move(pos, Orientation.S);
        Assert.AreEqual((newPos.X, newPos.Y), (0, 9));
    }

    [TestMethod]
    public void MoveLeftTest()
    {
        Position pos = new Position(0, 0);
        Position newPos = navigator.Move(pos, Orientation.W);
        Assert.AreEqual((newPos.X, newPos.Y), (9, 0));
    }

    [TestMethod]
    public void MoveRightTest()
    {
        Position pos = new Position(0, 0);
        Position newPos = navigator.Move(pos, Orientation.E);
        Assert.AreEqual((newPos.X, newPos.Y), (1, 0));
    }
}
