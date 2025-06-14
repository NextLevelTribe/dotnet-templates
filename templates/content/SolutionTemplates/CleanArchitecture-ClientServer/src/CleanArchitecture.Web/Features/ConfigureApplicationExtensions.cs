using CleanArchitecture.Web.Features.ToDo;
using CleanArchitecture.Web.Features.Weather;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Web.Features;

internal static class ConfigureApplicationExtensions
{
    internal static IServiceCollection AddFeatures(this IServiceCollection services)
    {
        _ = services.AddWeatherFeature()
            .AddToDoFeature();

        return services;
    }
}
