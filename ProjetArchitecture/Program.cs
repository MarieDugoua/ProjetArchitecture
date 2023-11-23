using ProjetArchitecture.Command;
using ProjetArchitecture.MarsRover;
using ProjetArchitecture.Topology;


public class Program
{
    public static void Main()
    {
        Planet mars = new Planet(10, 10);
        Navigator navigator = new Navigator(mars);
        Rover rover = new Rover(new Position(0, 0), Orientation.N, navigator);

        mars.AddObstacle(new Obstacle(0, 1));

        Console.WriteLine("Rover is ready to move! Input your commands:");
        Console.WriteLine("A - Advance");
        Console.WriteLine("R - Reverse");
        Console.WriteLine("L - Turn Left");
        Console.WriteLine("T - Turn Right");
        Console.WriteLine("Q - Quit");

        while (true)
        {
            Console.Write("Enter command: ");

            string input = Console.ReadLine().ToUpper();
            Console.WriteLine();
            string[] commande;
            commande = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (string lettre in commande)
            {
                switch (lettre)
                {
                    case "A":
                        rover.ExecuteCommand(Command.Advance);

                        break;
                    case "R":
                        rover.ExecuteCommand(Command.Reverse);
                        break;
                    case "L":
                        rover.ExecuteCommand(Command.TurnLeft);
                        break;
                    case "T":
                        rover.ExecuteCommand(Command.TurnRight);
                        break;
                    case "Q":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        continue;
                }
            }

            Console.WriteLine($"Current State: {rover}");
        }
    }
}