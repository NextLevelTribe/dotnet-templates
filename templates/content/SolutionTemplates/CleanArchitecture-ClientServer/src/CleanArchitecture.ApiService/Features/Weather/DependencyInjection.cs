using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.ApiService.Features.Weather;

internal static class DependencyInjection
{
    internal static IServiceCollection AddWeatherFeature(this IServiceCollection services)
    {
        _ = services.AddScoped<GetWeatherForecast.Application.UseCase>();
        _ = services.AddScoped<GetWeatherForecast.Application.IWeatherService, GetWeatherForecast.Infrastructure.WeatherService>();
        _ = services.AddScoped<GetWeatherForecast.Adapters.WebApiAdapter>();

        return services;
    }
}
