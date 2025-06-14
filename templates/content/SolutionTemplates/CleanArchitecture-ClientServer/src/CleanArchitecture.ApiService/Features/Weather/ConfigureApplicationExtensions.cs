using CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Presentation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.ApiService.Features.Weather;

internal static class ConfigureApplicationExtensions
{
    internal static IServiceCollection AddWeatherFeature(this IServiceCollection services)
    {
        _ = services.AddScoped<GetWeatherForecast.Application.UseCase>();
        _ = services.AddScoped<GetWeatherForecast.Application.IWeatherService, GetWeatherForecast.Infrastructure.WeatherService>();
        _ = services.AddScoped<GetWeatherForecast.Adapters.WebApiAdapter>();

        return services;
    }

    internal static WebApplication MapWeatherFeatureEndpoints(this WebApplication app)
    {
        return app.MapGetWeatherForecastEndpoint();
    }
}
