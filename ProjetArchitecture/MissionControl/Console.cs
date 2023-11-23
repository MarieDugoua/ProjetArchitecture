﻿using ProjetArchitecture.MarsRover;
using ProjetArchitecture.Communication;
using ProjetArchitecture.Command;

namespace ProjetArchitecture.MissionControl;

// Entity
public class Console : IDataCallback
{
    private List<char> commands = new List<char>();
    private readonly Rover myRover;
    // client
    private readonly ICommunication client;  // Adjusted for your project structure

    public Console(Rover _myRover, ICommunication _client)
    {
        myRover = _myRover;
        client = _client;  // Dependency injected

        // test client socket
        client.SetDataCallback(this);
        client.Listening();
    }

    public void OnDataReceived(string data)
    {
        System.Console.WriteLine("Data received in console: " + data);
    }

    private bool Run(bool wantMap)
    {
        foreach (char direction in commands)
        {
            switch (direction)
            {
                case 'F':
                    myRover.ExecuteCommand(Command.Command.Advance);
                    break;
                case 'B':
                    myRover.ExecuteCommand(Command.Command.Reverse);
                    break;
                case 'R':
                    myRover.ExecuteCommand(Command.Command.TurnRight);
                    break;
                case 'L':
                    myRover.ExecuteCommand(Command.Command.TurnLeft);
                    break;
                default:
                    System.Console.WriteLine("Incorrect command, the rover did not move");
                    break;
            }
        }
        if (wantMap)
        {
            PrintMap(myRover);
        }
        return true;
    }

    private void SetCommand(string command)
    {
        List<char> result = new List<char>();
        foreach (char currentChar in command.ToUpper())  // Ensure uppercase for consistency
        {
            if (Char.IsLetter(currentChar))
            {
                result.Add(currentChar);
            }
        }
        commands = result;
    }

    public bool RunCommand(string command, bool wantMap)
    {
        if (command.Equals("stop", StringComparison.OrdinalIgnoreCase))  // Case-insensitive comparison
        {
            return false;
        }
        SetCommand(command);
        return Run(wantMap);
    }

    private void PrintMap(IRover myRover)
    {
        Carte carte = new Carte(myRover);
    }
}
