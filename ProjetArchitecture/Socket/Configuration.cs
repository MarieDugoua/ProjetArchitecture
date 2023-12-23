namespace ProjetArchitecture.Socket;

using System.Net;
using System.Text;


public class Configuration
{
    private static IPAddress Ip;
    private static int Port;
    public IPEndPoint EndPoint => new(Ip, Port);
    public Encoding Encoding => Encoding.UTF8;

    public Configuration(String ip,int port)
    {
        Ip = IPAddress.Parse(ip);
        Port = port;
    }

    
}