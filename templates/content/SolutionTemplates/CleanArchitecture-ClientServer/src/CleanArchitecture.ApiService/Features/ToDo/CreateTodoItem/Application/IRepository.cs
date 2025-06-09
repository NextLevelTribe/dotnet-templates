using System.Threading.Tasks;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.CreateTodoItem.Application;

internal interface IRepository
{
    internal Task<ToDoItem> AddNewToDoItem(ToDoItem toDoItem);
}