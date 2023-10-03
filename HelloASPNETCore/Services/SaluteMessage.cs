namespace HelloASPNETCore.Services;

public class SaluteMessage: IMessage
{
    public int GetNumberTimes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public string GetMessage() => "Hello from SaluteMessage";
}

public class RealSaluteMessage : IMessage
{
    private readonly ITimeService timeService;
    private readonly IConfiguration configuration;

    public RealSaluteMessage(ITimeService timeService, 
                             IConfiguration configuration)
    {
        this.timeService = timeService;
        this.configuration = configuration;
    }

    public string GetMessage()  
    {

        var a = configuration["Settings:a"];

        if (timeService.GetTime().Hour < 12)
        {
            return $"{a} {timeService.GetNumberTimes} {configuration["Saluto"]} from RealSaluteMessage";
        } else
        {
            return $"{a} {timeService.GetNumberTimes} {configuration["Saluto"]} from RealSaluteMessage";
        }

    }   
}
