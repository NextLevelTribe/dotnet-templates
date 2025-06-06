using System;

namespace CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Adapters;

internal readonly record struct WebApiVM(DateOnly Date, int TemperatureC, int TemperatureF, string Summary);
