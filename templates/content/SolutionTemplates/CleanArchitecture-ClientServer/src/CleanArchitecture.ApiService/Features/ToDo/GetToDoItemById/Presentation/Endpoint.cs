using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.GetToDoItemById.Adapters;
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

    private static async Task<Results<Ok<ResponseVM>, NotFound>> GetToDoItemById(int id, WebApiAdapter adapter, CancellationToken cancellationToken)
    {
        (ResponseVM responseVM, bool success) = await adapter.Handle(id, cancellationToken);
        if (!success)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(responseVM);
    }
}
