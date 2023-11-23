using ProjetArchitecture.MarsRover;
using ProjetArchitecture.Topology;
using System;
using System.Text;

namespace ProjetArchitecture.MissionControl
{
    public class Carte
    {
        private Rover rover;
        private Planet planet;

        public Carte(Rover rover, Planet planet)
        {
            this.rover = rover;
            this.planet = planet;
            RefreshUI();
        }

        public void RefreshUI()
        {
            StringBuilder mapDisplay = new StringBuilder();
            string border = " | ";
            string ground = "_";
            //string obstacle = "x"; 

            int planetX = planet.Width * 2 + 1;
            int planetY = planet.Height * 2 + 1;

            int roverX = rover.Position.X + planet.Width;
            int roverY = -rover.Position.Y + planet.Height;

            string[,] map = new string[planetX, planetY];

            // Map Generation
            for (int y = 0; y < planetY; y++)
            {
                for (int x = 0; x < planetX; x++)
                {
                    if (y == roverY && x == roverX)
                    {
                        map[x, y] = RoverOrientationSymbol(rover.Orientation);
                    }
                    else
                    {
                        map[x, y] = ground;
                    }
                    mapDisplay.Append(border + map[x, y]);
                }
                mapDisplay.AppendLine(border);
            }

            // Display
            Console.WriteLine(mapDisplay.ToString());
        }

        private string RoverOrientationSymbol(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.W: return "<";
                case Orientation.E: return ">";
                case Orientation.N: return "↑";
                case Orientation.S: return "↓";
                default: return "?";
            }
        }
    }
}
