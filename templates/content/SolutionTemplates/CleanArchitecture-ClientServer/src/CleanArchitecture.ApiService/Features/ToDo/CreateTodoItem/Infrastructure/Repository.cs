using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Application;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Infrastructure;

internal sealed class Repository(ToDoDbContext toDoDbContext) : IRepository
{
    private readonly ToDoDbContext _toDoDbContext = toDoDbContext ?? throw new ArgumentNullException(nameof(toDoDbContext));

    public async Task<ToDoItem> AddNewToDoItem(ToDoItem toDoItem, CancellationToken cancellationToken = default)
    {
        _ = _toDoDbContext.ToDos.Add(toDoItem);
        _ = await _toDoDbContext.SaveChangesAsync(cancellationToken);

        return toDoItem;
    }
}
