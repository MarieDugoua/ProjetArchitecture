using ProjetArchitecture.MarsRover;
using ProjetArchitecture.Topology;

namespace ProjetArchitecture.MissionControl;

public class Carte
{
    public Carte(Rover rover)
    {
        this.UI(rover);
    }

    public void UI(Rover rover)
    {
        // Initialization
        string right = ">";
        string left = "<";
        string up = "↑";
        string down = "↓";

        string border = " | ";
        string rock = "x";  // This variable isn't used in your Java code. 
                            // You might want to integrate it or remove it.
        string ground = "o";

        int planetX = rover.GetPlanet().Width * 2 + 1;
        int planetY = rover.GetPlanet().Height * 2 + 1;

        int roverX = rover.Position.X + rover.GetPlanet().Width;
        int roverY = -rover.Position.Y + rover.GetPlanet().Height;

        string[,] map = new string[planetX, planetY];

        // Map Generation
        for (int i = 0; i < planetY; i++)
        {
            for (int j = 0; j < planetX; j++)
            {
                if (i == roverY && j == roverX)
                {
                    switch (rover.Orientation)
                    {
                        case Orientation.W:
                            map[j, i] = left;
                            break;
                        case Orientation.E:
                            map[j, i] = right;
                            break;
                        case Orientation.N:
                            map[j, i] = up;
                            break;
                        case Orientation.S:
                            map[j, i] = down;
                            break;
                    }
                }
                else
                {
                    map[j, i] = ground;
                }
            }
        }

        // Display
        for (int i = 0; i < planetX; i++)
        {
            for (int j = 0; j < planetY; j++)
            {
                Console.Write(border + map[j, i]);
            }
            Console.WriteLine(border);
        }
    }
}
