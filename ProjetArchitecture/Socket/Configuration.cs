namespace ProjetArchitecture.Configuration;

using System.Net;
using System.Text;


public class Configuration
{
    private static IPAddress Ip => IPAddress.Parse("127.0.0.1");
    private static int Port => 18061;

    public IPEndPoint EndPoint => new(Ip, Port);
    public Encoding Encoding => Encoding.UTF8;
}