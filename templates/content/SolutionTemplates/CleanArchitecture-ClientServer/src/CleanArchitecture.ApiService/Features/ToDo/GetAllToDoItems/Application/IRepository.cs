using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.GetAllToDoItems.Application;

internal interface IRepository
{
    public Task<ToDoItem[]> GetAllToDoItems(CancellationToken cancellationToken = default);
}