using DemoBlazorWASM.Services;
using DemoMVC.Core.Interfaces;
using DemoMVC.Core.Interfaces.Movies;
using LibreriaComponentiBlazor;
using LibreriaComponentiBlazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Polly;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("genres", client =>
{
    client.BaseAddress = new Uri("https://localhost:7263/");
})
.AddTransientHttpErrorPolicy (builder =>
builder.WaitAndRetryAsync(new[]
{
    TimeSpan.FromSeconds(1),
    TimeSpan.FromSeconds(5),
    TimeSpan.FromSeconds(10)
}));


builder.Services.AddScoped<IEventiPubblici, GestioneEventiFuturi>();
builder.Services.AddScoped<IWeatherForecasts, WeatherService>();
builder.Services.AddScoped<IGenresData, ServizioDatiGeneri>();

await builder.Build().RunAsync();
