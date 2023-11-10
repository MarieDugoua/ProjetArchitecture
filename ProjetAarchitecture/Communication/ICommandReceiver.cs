using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAarchitecture.Communication
{
    public interface ICommandReceiver
    {
       
        Task ListenAndSendResponseAsync(Func<string, string> whatToDoOnRequest, CancellationToken token);
    }
}
