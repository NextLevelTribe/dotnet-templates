using System;

namespace CleanArchitecture.Web.Features.Weather.GetWeatherForecast;

public sealed record class WeatherForecast(DateOnly Date, int TemperatureC, int TemperatureF, string Summary);
