using System;

namespace CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Application;

internal readonly record struct WeatherForecastModel(DateOnly Date, int TemperatureC, string Summary);
