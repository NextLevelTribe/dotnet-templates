using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Features.ToDo.GetToDos;

internal sealed class ToDoApiClient(HttpClient httpClient)
{
    internal async Task<ToDoItem[]> GetAllToDoItems(CancellationToken cancellationToken = default)
    {
        List<ToDoItem> response = [];

        IAsyncEnumerable<ToDoItem?> toDoItems = httpClient.GetFromJsonAsAsyncEnumerable<ToDoItem>("/todoitems", cancellationToken);
        await foreach (ToDoItem? toDoItem in toDoItems)
        {
            if (toDoItem is not null)
            {
                response.Add(toDoItem);
            }
        }

        return response.Count > 0 ? response.ToArray() : [];
    }
}
