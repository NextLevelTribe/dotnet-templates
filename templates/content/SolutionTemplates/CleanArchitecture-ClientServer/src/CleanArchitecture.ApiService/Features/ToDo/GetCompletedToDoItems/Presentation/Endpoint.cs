using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.ApiService.Features.ToDo.GetCompletedToDoItems.Presentation;

internal static class Endpoint
{
    internal static WebApplication MapGetCompletedToDoItemsEndpoint(this WebApplication app)
    {
        _ = app.MapGet("/todoitems/complete", GetCompletedToDoItems)
            .WithName("GetCompletedToDoItems");

        return app;
    }

    private static async Task<IResult> GetCompletedToDoItems(ToDoDbContext db)
    {
        return TypedResults.Ok(await db.ToDos.Where(t => t.IsComplete).ToArrayAsync());
    }
}
