using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Presentation;

internal static class Endpoint
{
    internal static WebApplication MapCreateTodoItemEndpoint(this WebApplication app)
    {
        _ = app.MapPost("/todoitems", CreateTodoItem).WithName("CreateTodoItem");
        return app;
    }

    private static async Task<IResult> CreateTodoItem(WebApiVM webApiVM, WebApiAdapter adapter)
    {
        WebApiVM responseVM = await adapter.Handle(webApiVM);
        return TypedResults.Created($"/todoitems/{responseVM.Id}", responseVM);
    }
}
