using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.UpdateToDoItem.Adapters;
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
        _ = app.MapPut("/todoitems/", UpdateToDoItem)
        .WithName("UpdateToDoItem");

        return app;
    }

    private static async Task<Results<NoContent, NotFound>> UpdateToDoItem(RequestVM requestVM, WebApiAdapter adapter)
    {
        bool success = await adapter.Handle(requestVM, default);
        if (!success)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.NoContent();
    }
}
