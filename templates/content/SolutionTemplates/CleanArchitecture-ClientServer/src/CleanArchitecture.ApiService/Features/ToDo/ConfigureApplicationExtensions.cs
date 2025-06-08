using CleanArchitecture.ApiService.Features.ToDo.AddNewToDoItem.Adapters;
using CleanArchitecture.ApiService.Features.ToDo.AddNewToDoItem.Application;
using CleanArchitecture.ApiService.Features.ToDo.AddNewToDoItem.Infrastructure;
using CleanArchitecture.ApiService.Features.ToDo.AddNewToDoItem.Presentation;
using CleanArchitecture.ApiService.Features.ToDo.DeleteToDoItem.Presentation;
using CleanArchitecture.ApiService.Features.ToDo.GetAllToDoItems.Presentation;
using CleanArchitecture.ApiService.Features.ToDo.GetCompletedToDoItems.Presentation;
using CleanArchitecture.ApiService.Features.ToDo.GetToDoItemById.Presentation;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;
using CleanArchitecture.ApiService.Features.ToDo.UpdateToDoItem.Presentation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.ApiService.Features.ToDo;

internal static class ConfigureApplicationExtensions
{
    internal static IServiceCollection AddToDoFeature(this IServiceCollection services)
    {
        _ = services.AddDbContext<ToDoDbContext>(opt => opt.UseInMemoryDatabase("TodoList"))
            .AddDatabaseDeveloperPageExceptionFilter() // Enables displaying database-related exceptions.
            .AddScoped<WebApiAdapter>()
            .AddScoped<UseCase>()
            .AddScoped<IRepository, Repository>();

        return services;
    }

    internal static WebApplication MapToDoFeatureEndpoints(this WebApplication app)
    {
        return app.MapGetAllToDoItemsEndpoints()
            .MapGetCompletedToDoItemsEndpoint()
            .MapGetToDoItemByIdEndpoint()
            .MapAddNewToDoItemEndpoint()
            .MapUpdateToDoItemEndpoint()
            .MapDeleteToDoItemEndpoint();
    }
}
