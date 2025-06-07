using CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Presentation;
using Microsoft.AspNetCore.Builder;

namespace CleanArchitecture.ApiService.Features.Weather;

internal static class Endpoints
{
    internal static WebApplication MapWeatherFeatureEndpoints(this WebApplication app)
    {
        return app.MapGetWeatherForecastEndpoints();
    }
}
