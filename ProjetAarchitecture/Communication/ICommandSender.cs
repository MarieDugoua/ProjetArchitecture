using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAarchitecture.Communication
{
    public interface ICommandSender
    {
        Task<string> SendAndWaitForResponseAsync(string message);
    }
}

