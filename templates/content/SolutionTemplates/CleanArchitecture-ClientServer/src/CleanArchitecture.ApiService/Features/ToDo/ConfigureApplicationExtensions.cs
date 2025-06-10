using CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Presentation;
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
            .AddScoped<CreateToDoItem.Application.UseCase>()
            .AddScoped<CreateToDoItem.Application.IRepository, CreateToDoItem.Infrastructure.Repository>()
            .AddScoped<CreateToDoItem.Adapters.WebApiAdapter>()
            .AddScoped<DeleteToDoItem.Application.UseCase>()
            .AddScoped<DeleteToDoItem.Application.IRepository, DeleteToDoItem.Infrastructure.Repository>()
            .AddScoped<GetAllToDoItems.Application.UseCase>()
            .AddScoped<GetAllToDoItems.Application.IRepository, GetAllToDoItems.Infrastructure.Repository>()
            .AddScoped<GetAllToDoItems.Adapters.WebApiAdapter>();

        return services;
    }

    internal static WebApplication MapToDoFeatureEndpoints(this WebApplication app)
    {
        return app.MapGetAllToDoItemsEndpoints()
            .MapGetCompletedToDoItemsEndpoint()
            .MapGetToDoItemByIdEndpoint()
            .MapCreateTodoItemEndpoint()
            .MapUpdateToDoItemEndpoint()
            .MapDeleteToDoItemEndpoint();
    }
}
