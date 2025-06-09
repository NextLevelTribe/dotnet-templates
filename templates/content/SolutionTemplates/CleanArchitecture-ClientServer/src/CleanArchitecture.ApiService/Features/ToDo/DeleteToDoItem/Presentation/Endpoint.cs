using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;
using CleanArchitecture.Domain.ToDo.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CleanArchitecture.ApiService.Features.ToDo.DeleteToDoItem.Presentation;

internal static class Endpoint
{
    internal static WebApplication MapDeleteToDoItemEndpoint(this WebApplication app)
    {
        _ = app.MapDelete("/todoitems/{id}", DeleteToDoItem)
        .WithName("DeleteToDoItem");

        return app;
    }

    private static async Task<Results<NoContent, NotFound>> DeleteToDoItem(int id, ToDoDbContext db)
    {
        ToDoItem? toDoItem = await db.ToDos.FindAsync(id);
        if (toDoItem is null)
        {
            return TypedResults.NotFound();
        }

        _ = db.ToDos.Remove(toDoItem);
        _ = await db.SaveChangesAsync();

        return TypedResults.NoContent();
    }
}
