using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;

namespace CleanArchitecture.ApiService.FunctionalTests.Features.ToDo;

public abstract class ToDoTestsBase : WebApplicationFactoryBase<ToDoDbContext>
{
    private protected const string _requestUriBase = "/todoitems";

    private protected readonly HttpClient _client;

    public ToDoTestsBase(string inMemoryDatabaseName) : base(inMemoryDatabaseName)
    {
        _client = CreateClient();
    }

    private protected async Task<ResponseVM> CreateTodoItem(string? name = "", bool isComplete = false)
    {
        RequestVM request = new(name, isComplete);
        using HttpResponseMessage postResponse = await _client.PostAsJsonAsync(_requestUriBase, request);
        ResponseVM addedToDoItem = await postResponse.Content.ReadFromJsonAsync<ResponseVM>();
        return addedToDoItem;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _client.Dispose();
        }

        base.Dispose(disposing);
    }
}
