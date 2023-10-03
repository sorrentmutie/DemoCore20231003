using HelloASPNETCore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IMessage, RealSaluteMessage>();
builder.Services.AddTransient<ITimeService, SystemClock>();



var app = builder.Build();

app.UseStaticFiles();
// app.UseWelcomePage();

app.Use(next =>
{
    return
     async context =>
     {
         if (context.Request.Path.StartsWithSegments("/ciao"))
         {
             await context.Response.WriteAsync("Fine delle trasmissioni");
         } else
         {
             await next.Invoke(context);
         }
     };

});

app.Use(next => {
    var message = "Siamo nel secondo middleware";
    var logger = app.Services.GetService<ILogger<Program>>();
    logger?.LogCritical(message);
    return next.Invoke;
});



app.MapGet("/", (IMessage service) =>
{
    //var saluto = configuration["Saluto"];
    

    //return saluto;
    //ITimeService timeService = new MockClock();
    //var message = new RealSaluteMessage(timeService);
   return service.GetMessage();
});

app.Run();
