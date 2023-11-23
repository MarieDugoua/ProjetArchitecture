namespace ProjetArchitecture.Communication;

public interface ICommandSender
{
    Task<string> SendAndWaitForResponseAsync(string message);
}