using ProjetAarchitecture.Topologie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAarchitecture.MarsRover
{
    public class Navigator
    {
        private readonly Planet _planet;

        public Navigator(Planet planet)
        {
            _planet = planet;
        }
    }
}
