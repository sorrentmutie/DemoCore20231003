using DemoMVC.Core.Interfaces;
using LibreriaComponentiBlazor.Shared;

namespace DemoBlazorServer.Services;

public class WeatherServerService : IWeatherForecasts
{

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<WeatherForecast[]?> GetForecasts()
    {
        DateTime date = DateTime.Today;

        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = date.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray());
    }
}
