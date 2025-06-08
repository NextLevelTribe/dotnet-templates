using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;
using CleanArchitecture.Domain.ToDo.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CleanArchitecture.ApiService.Features.ToDo.UpdateToDoItem.Presentation;

internal static class Endpoint
{
    // A PUT request requires the client to send the entire updated entity, not just the changes.
    // To support partial updates, use HTTP PATCH.
    internal static WebApplication MapUpdateToDoItemEndpoint(this WebApplication app)
    {
        _ = app.MapPut("/todoitems/{id}", async Task<Results<NoContent, NotFound>> (int id, ToDoItem inputToDoItem, ToDoDbContext db) =>
        {
            ToDoItem? toDoItem = await db.ToDos.FindAsync(id);
            if (toDoItem is null)
            {
                return TypedResults.NotFound();
            }

            toDoItem.Name = inputToDoItem.Name;
            toDoItem.IsComplete = inputToDoItem.IsComplete;

            _ = await db.SaveChangesAsync();

            return TypedResults.NoContent();
        })
        .WithName("UpdateToDoItem");

        return app;
    }
}
