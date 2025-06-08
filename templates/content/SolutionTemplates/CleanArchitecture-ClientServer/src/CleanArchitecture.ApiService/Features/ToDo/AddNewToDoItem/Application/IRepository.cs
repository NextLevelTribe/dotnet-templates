using System.Threading.Tasks;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.AddNewToDoItem.Application;

internal interface IRepository
{
    internal Task<ToDoItem> AddNewToDoItem(ToDoItem toDoItem);
}