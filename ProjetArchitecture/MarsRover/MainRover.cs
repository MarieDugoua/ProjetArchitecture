namespace ProjetArchitecture.MarsRover;

using ProjetArchitecture.Command;

public class MainRover
{
    public MainRover() { }
    public void ExecuteCommand(Command command, Rover rover)
    {
        rover.ExecuteCommand(command);
    }

    public string returnPosition(Rover rover)
    {
        return rover.ToString();
    }
}