using CleanArchitecture.ApiService.Features.Weather;
using Microsoft.AspNetCore.Builder;

namespace CleanArchitecture.ApiService.Features;

internal static class Endpoints
{
    internal static WebApplication MapFeaturesEndpoints(this WebApplication app)
    {
        return app.MapWeatherFeatureEndpoints();
    }
}
