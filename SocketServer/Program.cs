
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using ProjetArchitecture.Communication;
using ProjetArchitecture.Socket;

var communicationConfig = new CommunicationConfig();
var logger = new ConsoleLogger(); // ou un autre logger de votre choix

using var socketServer = new SocketServer.SocketServer(new Configuration(communicationConfig.ServerIp, communicationConfig.ServerPort), logger);


await socketServer.ListenAndSendResponseAsync(
    request => new string(request.Reverse().ToArray()),
    CancellationToken.None);

class ConsoleLogger : ILogger
{
    /// <inheritdoc />
    public void LogMessage(string message)
    {
        Console.WriteLine(message);
    }
}