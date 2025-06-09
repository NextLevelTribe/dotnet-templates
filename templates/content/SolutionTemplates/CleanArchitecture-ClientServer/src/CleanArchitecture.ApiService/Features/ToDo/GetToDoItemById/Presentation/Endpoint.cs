using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;
using CleanArchitecture.Domain.ToDo.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CleanArchitecture.ApiService.Features.ToDo.GetToDoItemById.Presentation;

internal static class Endpoint
{
    internal static WebApplication MapGetToDoItemByIdEndpoint(this WebApplication app)
    {
        _ = app.MapGet("/todoitems/{id}", GetToDoItemById)
        .WithName("GetToDoItemById");

        return app;
    }

    private static async Task<Results<Ok<ToDoItem>, NotFound>> GetToDoItemById(int id, ToDoDbContext db)
    {
        ToDoItem? toDoItem = await db.ToDos.FindAsync(id);
        if (toDoItem is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(toDoItem);
    }
}
