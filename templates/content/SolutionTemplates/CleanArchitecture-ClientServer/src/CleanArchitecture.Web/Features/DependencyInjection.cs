using CleanArchitecture.Web.Features.Weather;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Web.Features;

internal static class DependencyInjection
{
    internal static IServiceCollection AddFeatures(this IServiceCollection services)
    {
        _ = services.AddWeatherFeature();
        return services;
    }
}
