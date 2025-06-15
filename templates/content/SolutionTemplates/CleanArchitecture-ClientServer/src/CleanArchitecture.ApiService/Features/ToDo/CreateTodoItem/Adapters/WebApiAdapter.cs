using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Application;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters;

internal sealed class WebApiAdapter(UseCase useCase)
{
    private readonly UseCase _useCase = useCase;

    internal async Task<ResponseVM> Handle(RequestVM requestVM, CancellationToken cancellationToken = default)
    {
        ToDoItem toDoItem = new() { Name = requestVM.Name, IsComplete = requestVM.IsComplete };

        ToDoItem responseToDoItem = await _useCase.Handle(toDoItem, cancellationToken);
        ResponseVM responseVM = new(responseToDoItem.Id, responseToDoItem.Name, responseToDoItem.IsComplete);

        return responseVM;
    }
}
