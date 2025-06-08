using CleanArchitecture.ApiService.Features.ToDo;
using CleanArchitecture.ApiService.Features.Weather;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.ApiService.Features;

internal static class ConfigureApplicationExtensions
{
    internal static IServiceCollection AddFeatures(this IServiceCollection services)
    {
        _ = services.AddWeatherFeature()
            .AddToDoFeature();

        return services;
    }

    internal static WebApplication MapFeaturesEndpoints(this WebApplication app)
    {
        _ = app.MapWeatherFeatureEndpoints()
            .MapToDoFeatureEndpoints();

        return app;
    }
}
