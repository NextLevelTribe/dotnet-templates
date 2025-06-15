using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Application;

internal interface IRepository
{
    public Task<ToDoItem> AddNewToDoItem(ToDoItem toDoItem, CancellationToken cancellationToken = default);
}