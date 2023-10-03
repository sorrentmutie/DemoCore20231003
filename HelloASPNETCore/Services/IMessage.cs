namespace HelloASPNETCore.Services;

public interface IMessage
{
    string GetMessage();
}

public interface ITimeService
{
    DateTime GetTime();
    int GetNumberTimes { get; }
}