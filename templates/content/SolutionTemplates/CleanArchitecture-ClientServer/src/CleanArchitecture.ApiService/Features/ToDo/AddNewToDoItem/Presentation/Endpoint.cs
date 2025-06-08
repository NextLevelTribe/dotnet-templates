using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.AddNewToDoItem.Adapters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.ApiService.Features.ToDo.AddNewToDoItem.Presentation;

internal static class Endpoint
{
    internal static WebApplication MapAddNewToDoItemEndpoint(this WebApplication app)
    {
        _ = app.MapPost("/todoitems", async Task<IResult> (WebApiVM webApiVM, WebApiAdapter adapter) =>
        {
            WebApiVM responseVM = await adapter.HandleAsync(webApiVM);
            return TypedResults.Created($"/todoitems/{responseVM.Id}", responseVM);
        })
        .WithName("AddNewToDoItem");

        return app;
    }
}
