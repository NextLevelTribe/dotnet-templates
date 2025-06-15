#if (IncludeSampleContent)
using CleanArchitecture.Web.Features.ToDo;
#endif
using CleanArchitecture.Web.Features.Weather;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Web.Features;

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
}
