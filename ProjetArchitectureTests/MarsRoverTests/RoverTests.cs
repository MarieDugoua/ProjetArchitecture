namespace ProjetArchitectureTests.MarsRoverTests;
using ProjetArchitecture.MarsRover;
using ProjetArchitecture.Topology;
using ProjetArchitecture.Command;

[TestClass]
public class RoverTests
{
    private Rover rover;

    [TestInitialize]
    public void TestInitialize()
    {
        Position pos = new Position(0, 0);
        Planet planet = new Planet(10, 10);
        Navigator navigator = new Navigator(planet);
        rover = new Rover(pos, Orientation.N, navigator);
    }

    [TestMethod]
    public void ExecuteForwardCommandTest()
    {
        rover.ExecuteCommand(Command.Advance);
        Assert.AreEqual((rover.Position.X, rover.Position.Y), (0, 1));
        Assert.AreEqual(rover.Orientation, Orientation.N);
    }

    [TestMethod]
    public void ExecuteBackwardCommandTest()
    {
        rover.ExecuteCommand(Command.Reverse);
        Assert.AreEqual((rover.Position.X, rover.Position.Y), (0, 9));
        Assert.AreEqual(rover.Orientation, Orientation.N);
    }

    [TestMethod]
    public void ExecuteLeftCommandTest()
    {
        rover.ExecuteCommand(Command.TurnLeft);
        Assert.AreEqual((rover.Position.X, rover.Position.Y), (0, 0));
        Assert.AreEqual(rover.Orientation, Orientation.W);
    }

    [TestMethod]
    public void ExecuteRightCommandTest()
    {
        rover.ExecuteCommand(Command.TurnRight);
        Assert.AreEqual((rover.Position.X, rover.Position.Y), (0, 0));
        Assert.AreEqual(rover.Orientation, Orientation.E);
    }
}

