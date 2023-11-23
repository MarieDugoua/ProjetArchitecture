var configuration = new Configuration.Configuration();
using var socketClient = new SocketClient.SocketClient(configuration);

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