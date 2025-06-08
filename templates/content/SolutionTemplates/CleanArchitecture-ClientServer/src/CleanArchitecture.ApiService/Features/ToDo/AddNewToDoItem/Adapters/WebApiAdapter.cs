using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.AddNewToDoItem.Application;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.AddNewToDoItem.Adapters;

internal sealed class WebApiAdapter(UseCase useCase)
{
    private readonly UseCase _useCase = useCase;

    internal async Task<WebApiVM> HandleAsync(WebApiVM webApiVM)
    {
        ToDoItem toDoItem = new() { Name = webApiVM.Name, IsComplete = webApiVM.IsComplete };

        ToDoItem responseToDoItem = await _useCase.HandleAsync(toDoItem);
        WebApiVM viewModel = new(responseToDoItem.Id, responseToDoItem.Name, responseToDoItem.IsComplete);

        return viewModel;
    }
}
