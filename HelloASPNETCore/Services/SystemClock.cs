namespace HelloASPNETCore.Services;

public class SystemClock : ITimeService
{
    private int counter = 0;

    public DateTime GetTime()
    {
        counter++;
        return DateTime.Now;
    }

    public int GetNumberTimes { get => counter; }
}

public class MockClock : ITimeService
{
    private int counter = 0;

    public DateTime GetTime()
    {
        counter++;
        return new DateTime(2021, 1, 1, 10, 0, 0);
    }

    public int GetNumberTimes { get => counter; }
}
