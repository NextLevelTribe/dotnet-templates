using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.ApiService.Features.ToDo.GetAllToDoItems.Presentation;

internal static class Endpoint
{
    internal static WebApplication MapGetAllToDoItemsEndpoints(this WebApplication app)
    {
        _ = app.MapGet("/todoitems", async Task<IResult> (ToDoDbContext db) => TypedResults.Ok(await db.ToDos.ToArrayAsync()))
            .WithName("GetAllToDoItems");

        return app;
    }
}
