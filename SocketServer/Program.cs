using System.Net.Sockets;
using ProjetArchitecture.Socket;

var configuration = new Configuration();
var socketServer = new SocketServer.SocketServer(configuration, new ConsoleLogger());

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