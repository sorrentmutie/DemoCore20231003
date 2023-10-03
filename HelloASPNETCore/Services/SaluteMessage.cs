namespace HelloASPNETCore.Services;

public class SaluteMessage: IMessage
{
    public int GetNumberTimes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public string GetMessage() => "Hello from SaluteMessage";
}

public class RealSaluteMessage : IMessage
{
    private readonly ITimeService timeService;

    public RealSaluteMessage(ITimeService timeService)
    {
        this.timeService = timeService;
    }

    public string GetMessage()  
    {
        if(timeService.GetTime().Hour < 12)
        {
            return $"{timeService.GetNumberTimes}  Good Morning from RealSaluteMessage";
        } else
        {
            return $"{timeService.GetNumberTimes} Good Evening from RealSaluteMessage";
        }

    }   
}
