using ProjetArchitecture.MarsRover;
using ProjetArchitecture.Communication;


namespace ProjetArchitecture.MissionControl
{
    public class Console
    {
        private List<char> commands = new List<char>();
        private readonly Rover myRover;
        private readonly ICommandReceiver client;
        private Carte carte;

        public Console(Rover myRover, ICommandReceiver client)
        {
            this.myRover = myRover;
            this.client = client;
            carte = new Carte(myRover);

            Task.Run(() => client.ListenAndSendResponseAsync(ProcessCommand, new CancellationToken()));
        }

        private string ProcessCommand(string command)
        {
            System.Console.WriteLine("Command received: " + command);
            var result = RunCommand(command, true);
            return result ? "Command executed successfully" : "Command execution failed";
        }

        public void OnDataReceived(string data)
        {
            System.Console.WriteLine("Data received in console: " + data);
            RunCommand(data, true);
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
                        System.Console.WriteLine($"Incorrect command '{direction}', the rover did not move");
                        continue;
                }

                if (wantMap)
                {
                    carte.RefreshUI();
                }
            }
            return true;
        }

        private void SetCommand(string command)
        {
            commands.Clear();
            foreach (char currentChar in command.ToUpper())
            {
                if (Char.IsLetter(currentChar))
                {
                    commands.Add(currentChar);
                }
            }
        }

        public bool RunCommand(string command, bool wantMap)
        {
            if (command.Equals("stop", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            SetCommand(command);
            return Run(wantMap);
        }
    }
}
