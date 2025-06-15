using System;
using System.Linq;
using CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Application;

namespace CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Infrastructure;

internal class WeatherService : IWeatherService
{
    private static readonly string[] _summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

    public WeatherForecast[] GetWeatherForecasts()
    {
        WeatherForecast[] forecast = [.. Enumerable.Range(1, 5).Select(index =>
               new WeatherForecast
               (
                   DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                   Random.Shared.Next(-20, 55),
                   _summaries[Random.Shared.Next(_summaries.Length)]
               ))];

        return forecast;
    }
}