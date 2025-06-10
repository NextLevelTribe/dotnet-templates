using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.DeleteToDoItem.Application;
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

    private static async Task<Results<NoContent, NotFound>> DeleteToDoItem(int id, UseCase usecase, CancellationToken cancellationToken)
    {
        bool success = await usecase.Handle(id, cancellationToken);
        return success ? TypedResults.NoContent() : TypedResults.NotFound();
    }
}
