using ProjetArchitecture.MarsRover;
using ProjetArchitecture.Topology;

namespace ProjetArchitecture.MissionControl;

class MainClass
{
    static void Main(string[] args)
    {
        Planet mars = new Planet(10, 10);
        mars.AddObstacle(new Obstacle(0, 1)); 

        Navigator navigator = new Navigator(mars);

        Rover rover = new Rover(new Position(0, 0), Orientation.N, navigator);

        Console myConsole = new Console(rover, yourCommunicationObject);
        myConsole.RunCommand();

        System.Console.WriteLine("Rover is initialized and ready.");
    }
}