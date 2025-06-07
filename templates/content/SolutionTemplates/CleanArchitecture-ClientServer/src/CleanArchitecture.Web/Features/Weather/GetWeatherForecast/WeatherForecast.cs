using System;

namespace CleanArchitecture.Web.Features.Weather.GetWeatherForecast;

internal record WeatherForecast(DateOnly Date, int TemperatureC, int TemperatureF, string Summary);
