namespace ProjetArchitecture.MarsRover
{
    using ProjetArchitecture.Command;
    using ProjetArchitecture.Topology;

    public class MainRover
    {
        private readonly Planet planet = new Planet(4, 8);
        private readonly Rover theRover;

        public MainRover()
        {
            // Initialise le rover avec une position initiale (0, 0) et un navigateur associ� � la plan�te
            theRover = new Rover(new Position(0, 0), Orientation.N, new Navigator(planet));
        }

        public void ExecuteCommand(Command command)
        {
            // Ex�cute la commande sur le rover
            theRover.ExecuteCommand(command);
        }

        public string ReturnPosition()
        {
            // Retourne la position actuelle du rover
            return theRover.ToString();
        }
    }
}
