using DemoMVC.Core.Interfaces;
using LibreriaComponentiBlazor.Shared;
using System.Net.Http.Json;

namespace DemoBlazorWASM.Services;

public class WeatherService : IWeatherForecasts
{
    private readonly HttpClient httpClient;

    public WeatherService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<WeatherForecast[]?> GetForecasts()
    {
        var data = await httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        return data;
    }
}
