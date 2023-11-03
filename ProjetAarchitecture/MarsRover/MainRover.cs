using ProjetAarchitecture.Commandes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAarchitecture.MarsRover
{
    public class MainRover
    {
        public MainRover() { }
        public void ExecuteCommand(Commands command, Rover rover) {
            rover.ExecuteCommand(command);
        }    

        public string returnPosition(Rover rover)
        {
            return rover.ToString();
        }
    }
}
