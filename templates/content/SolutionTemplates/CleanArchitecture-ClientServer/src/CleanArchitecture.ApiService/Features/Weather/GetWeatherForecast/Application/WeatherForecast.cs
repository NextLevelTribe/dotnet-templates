using System;

namespace CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Application;

internal readonly record struct WeatherForecast(DateOnly Date, int TemperatureC, string Summary);
