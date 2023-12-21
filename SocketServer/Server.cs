using System.Net.Sockets;
using ProjetArchitecture.Communication;
using ProjetArchitecture.Socket;

namespace SocketServer;

public class SocketServer : ICommandReceiver, IDisposable
{
    private readonly Configuration _configuration;
    private readonly ILogger _logger;
    private readonly Socket _server;

    public SocketServer(Configuration configuration, ILogger logger)
    {
        _configuration = configuration;
        _logger = logger;
        _server = new(
            configuration.EndPoint.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _server.Dispose();
    }

    /// <inheritdoc />
    public async Task ListenAndSendResponseAsync(Func<string, string> whatToDoOnRequest, CancellationToken token)
    {
        _server.Bind(_configuration.EndPoint);
        _server.Listen(100);



        while (!token.IsCancellationRequested)
        {
            var handler = await _server.AcceptAsync(token);
            var receiveBuffer = new byte[300];

            var received = await handler.ReceiveAsync(receiveBuffer, SocketFlags.None);
            var request = _configuration.Encoding.GetString(receiveBuffer, 0, received);

            var response = whatToDoOnRequest(request);

            _logger.LogMessage($"Received {request}, sent {response}");

            var bytesToSend = _configuration.Encoding.GetBytes(response);
            await handler.SendAsync(bytesToSend);
        }
    }
}