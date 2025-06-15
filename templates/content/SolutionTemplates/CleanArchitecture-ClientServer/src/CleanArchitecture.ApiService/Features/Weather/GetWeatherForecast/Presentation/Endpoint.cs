using CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Adapters;
using Microsoft.AspNetCore.Builder;

namespace CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Presentation;

internal static class Endpoint
{
    internal static WebApplication MapGetWeatherForecastEndpoint(this WebApplication app)
    {
        _ = app.MapGet("/weatherforecast", (WebApiAdapter adapter) =>
        {
            ResponseVM[] response = adapter.Handle();
            return response;
        })
        .WithName("GetWeatherForecast");

        return app;
    }
}
