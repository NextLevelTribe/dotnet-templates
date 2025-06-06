using System;

namespace CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Application;

internal sealed class UseCase(IWeatherService weatherService)
{
    private readonly IWeatherService _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));

    internal WeatherForecastModel[] Handle()
    {
        return _weatherService.GetWeatherForecasts();
    }
}
