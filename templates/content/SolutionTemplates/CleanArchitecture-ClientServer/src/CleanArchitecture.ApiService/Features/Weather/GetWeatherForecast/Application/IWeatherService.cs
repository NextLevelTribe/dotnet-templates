namespace CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Application;

internal interface IWeatherService
{
    public WeatherForecast[] GetWeatherForecasts();
}