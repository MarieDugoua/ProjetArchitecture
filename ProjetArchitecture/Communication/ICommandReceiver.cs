namespace ProjetArchitecture.Communication;

public interface ICommandReceiver
{
    Task ListenAndSendResponseAsync(Func<string, string> whatToDoOnRequest, CancellationToken token);
}