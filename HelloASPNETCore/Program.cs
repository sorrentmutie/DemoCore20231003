using HelloASPNETCore.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IMessage, RealSaluteMessage>();
builder.Services.AddTransient<ITimeService, SystemClock>();


var app = builder.Build();

app.MapGet("/", (IMessage service) =>
{
    //ITimeService timeService = new MockClock();
    //var message = new RealSaluteMessage(timeService);


    return service.GetMessage();
});

app.Run();
