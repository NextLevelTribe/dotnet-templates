using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;
using CleanArchitecture.Domain.ToDo.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.ApiService.Features.ToDo.AddNewToDoItem.Presentation;

internal static class Endpoint
{
    internal static WebApplication MapAddNewToDoItemEndpoint(this WebApplication app)
    {
        _ = app.MapPost("/todoitems", async Task<IResult> (ToDoItem toDo, ToDoDb db) =>
        {
            _ = db.ToDos.Add(toDo);
            _ = await db.SaveChangesAsync();

            return TypedResults.Created($"/todoitems/{toDo.Id}", toDo);
        })
        .WithName("AddNewToDoItem");

        return app;
    }
}
