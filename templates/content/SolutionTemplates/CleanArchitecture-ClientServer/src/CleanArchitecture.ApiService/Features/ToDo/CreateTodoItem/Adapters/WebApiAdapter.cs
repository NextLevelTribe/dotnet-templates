using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Application;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters;

internal sealed class WebApiAdapter(UseCase useCase)
{
    private readonly UseCase _useCase = useCase;

    internal async Task<WebApiVM> Handle(WebApiVM webApiVM)
    {
        ToDoItem toDoItem = new() { Name = webApiVM.Name, IsComplete = webApiVM.IsComplete };

        ToDoItem responseToDoItem = await _useCase.Handle(toDoItem);
        WebApiVM viewModel = new(responseToDoItem.Id, responseToDoItem.Name, responseToDoItem.IsComplete);

        return viewModel;
    }
}
