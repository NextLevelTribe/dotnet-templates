using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.GetAllToDoItems.Adapters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.ApiService.Features.ToDo.GetAllToDoItems.Presentation;

internal static class Endpoint
{
    internal static WebApplication MapGetAllToDoItemsEndpoints(this WebApplication app)
    {
        _ = app.MapGet("/todoitems", GetAllToDoItems)
            .WithName("GetAllToDoItems");

        return app;
    }

    private static async Task<IResult> GetAllToDoItems(WebApiAdapter adapter, CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await adapter.Handle(cancellationToken));
    }
}
