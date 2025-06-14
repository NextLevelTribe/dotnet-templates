using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.GetToDoItemById.Application;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.GetToDoItemById.Infrastructure;

internal sealed class Repository(ToDoDbContext toDoDbContext) : IRepository
{
    private readonly ToDoDbContext _toDoDbContext = toDoDbContext ?? throw new ArgumentNullException(nameof(toDoDbContext));

    public async ValueTask<ToDoItem?> GetToDoItemById(int id, CancellationToken cancellationToken = default)
    {
        ToDoItem? toDoItem = await _toDoDbContext.ToDos.FindAsync([id], cancellationToken);
        return toDoItem;
    }
}
