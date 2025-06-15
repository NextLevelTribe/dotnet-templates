#if (IncludeSampleContent)
using CleanArchitecture.ApiService.Features.ToDo;
#endif
using CleanArchitecture.ApiService.Features.Weather;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.ApiService.Features;

internal static class ConfigureApplicationExtensions
{
    internal static IServiceCollection AddFeatures(this IServiceCollection services)
    {
        _ = services.AddWeatherFeature();
        #if (IncludeSampleContent)
        _ = services.AddToDoFeature();
        #endif
        return services;
    }

    internal static WebApplication MapFeaturesEndpoints(this WebApplication app)
    {
        _ = app.MapWeatherFeatureEndpoints();
        #if (IncludeSampleContent)
        _ = app.MapToDoFeatureEndpoints();
        #endif

        return app;
    }
}
