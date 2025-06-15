using CleanArchitecture.Web.Features.ToDo.GetToDos;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Web.Features.ToDo;

internal static class ConfigureApplicationExtensions
{
    internal static IServiceCollection AddToDoFeature(this IServiceCollection services)
    {
        _ = services.AddHttpClient<ToDoApiClient>(client =>
        {
            // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
            // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
            client.BaseAddress = new("https+http://apiservice");
        });

        return services;
    }
}
