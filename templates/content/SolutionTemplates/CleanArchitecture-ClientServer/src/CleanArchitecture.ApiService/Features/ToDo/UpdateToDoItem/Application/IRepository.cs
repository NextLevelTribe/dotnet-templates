using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.UpdateToDoItem.Application;

internal interface IRepository
{
    public Task<bool> UpdateToDoItem(int id, ToDoItem toDoItem, CancellationToken cancellationToken = default);
}