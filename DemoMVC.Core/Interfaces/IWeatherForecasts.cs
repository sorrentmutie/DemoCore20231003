using LibreriaComponentiBlazor.Shared;

namespace DemoMVC.Core.Interfaces;

public interface IWeatherForecasts
{
    Task<WeatherForecast[]?> GetForecasts();
}
