using CleanArchitecture.Web.Features.Weather.GetWeatherForecast;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Web.Features.Weather;

internal static class DependencyInjection
{
    internal static IServiceCollection AddWeatherFeature(this IServiceCollection services)
    {
        _ = services.AddHttpClient<WeatherApiClient>(client =>
        {
            // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
            // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
            client.BaseAddress = new("https+http://apiservice");
        });

        return services;
    }
}
