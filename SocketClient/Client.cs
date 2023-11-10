using System.Net.Sockets;
using Configuration;
using ProjetAarchitecture.Communication;

namespace SocketClient;

public class SocketClient : ICommandSender, IDisposable
{
    private readonly Configuration.Configuration _configuration;
    private readonly Socket _client;

    public SocketClient(Configuration.Configuration configuration)
    {
        _configuration = configuration;
        _client = new(
            configuration.EndPoint.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _client.Dispose();
    }

    /// <inheritdoc />
    public async Task<string> SendAndWaitForResponseAsync(string message)
    {
        await _client.ConnectAsync(_configuration.EndPoint);

        try
        {
            var bytesToSend = _configuration.Encoding.GetBytes(message);

            await _client.SendAsync(bytesToSend);

            var receiveBuffer = new byte[300];
            var received = await _client.ReceiveAsync(receiveBuffer, SocketFlags.None);
            return _configuration.Encoding.GetString(receiveBuffer, 0, received);
        }
        finally
        {
            await _client.DisconnectAsync(true);
        }
    }
}