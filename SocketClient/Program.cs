using ProjetArchitecture.Communication;
using ProjetArchitecture.Socket;
var communicationConfig = new CommunicationConfig();
using var socketClient = new SocketClient.SocketClient(new Configuration(communicationConfig.ServerIp, communicationConfig.ServerPort));



var @continue = true;

while (@continue)
{
    Console.Write("> ");
    var message = Console.ReadLine() ?? string.Empty;
    var response = await socketClient.SendAndWaitForResponseAsync(message);
    Console.WriteLine(response);

    Console.WriteLine("Want to quit ? (y/N)");
    if (Console.ReadKey().KeyChar == 'y') @continue = false;
}