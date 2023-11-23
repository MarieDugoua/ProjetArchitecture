using ProjetArchitecture.MarsRover;
using ProjetArchitecture.Topology;

namespace ProjetArchitecture.MissionControl;

class MainClass
{
    static void Main(string[] args)
    {
        // Initialize the planet and obstacles
        Planet mars = new Planet(10, 10);
        mars.AddObstacle(new Obstacle(0, 1));  // Example obstacle

        // Create the navigator
        Navigator navigator = new Navigator(mars);

        // Initialize the rover with a starting position and orientation
        Rover rover = new Rover(new Position(0, 0), Orientation.N, navigator);

        // Optionally, initialize the console for command processing
        // This step might require modifications based on how you've set up your communication classes
        // Console console = new Console(rover, yourCommunicationObject);

        // If you have a method to start command processing or a user interface, call it here
        // For example: console.RunCommandProcessing();

        Console.WriteLine("Rover is initialized and ready.");
        // Additional initialization or application logic goes here
    }
}
