using System;

namespace CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Adapters;

internal readonly record struct ResponseVM(DateOnly Date, int TemperatureC, int TemperatureF, string Summary);
