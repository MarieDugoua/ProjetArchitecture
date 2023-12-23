using ProjetArchitecture.MarsRover;
using ProjetArchitecture.Socket;
using ProjetArchitecture.Topology;


public class MainConsole
{
    static async Task Main(string[] args)
    {
        Planet mars = new Planet(10, 10);
        mars.AddObstacle(new Obstacle(0, 1));
        Navigator navigator = new Navigator(mars);
        Rover rover = new Rover(new Position(0, 0), Orientation.N, navigator);

        var configuration = new Configuration("127.0.0.1", 8080);
        var logger = new ConsoleLogger();

       // var myConsole = new ProjetArchitecture.MissionControl.Console(rover, socketServer);
        System.Console.WriteLine("Rover is initialized and ready.");

        /*await socketServer.ListenAndSendResponseAsync(
            request =>
            {
                myConsole.OnDataReceived(request);
                return "Processed";
            },
            CancellationToken.None);*/
    }
}

class ConsoleLogger : ILogger
{
    public void LogMessage(string message)
    {
        System.Console.WriteLine(message);
    }
}