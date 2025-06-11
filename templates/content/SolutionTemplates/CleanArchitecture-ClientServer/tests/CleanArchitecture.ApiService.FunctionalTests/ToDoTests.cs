using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CleanArchitecture.Domain.ToDo.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanArchitecture.ApiService.FunctionalTests;

[TestClass]
public sealed class ToDoTests : WebApplicationFactory<Program>
{
    private const string _requestUriBase = "/todoitems";

    private readonly HttpClient _client;

    public ToDoTests()
    {
        _client = CreateClient();
    }

    [TestMethod]
    public async Task Post_CreateTodoItem_ReturnsCreated()
    {
        // Arrange
        CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters.RequestVM requestVM = new()
        {
            Name = "Walk the dog",
            IsComplete = false
        };

        // Act
        using HttpResponseMessage response = await _client.PostAsJsonAsync(_requestUriBase, requestVM);

        // Assert
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters.ResponseVM responseVM = await response.Content.ReadFromJsonAsync<CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters.ResponseVM>();

        Assert.AreNotEqual(0, responseVM.Id);
        Assert.AreEqual(requestVM.Name, responseVM.Name);
        Assert.AreEqual(requestVM.IsComplete, responseVM.IsComplete);
    }

    [TestMethod]
    public async Task Get_GetAllTodos_ReturnsOk()
    {
        // Arrange - Act
        using HttpResponseMessage response = await _client.GetAsync(_requestUriBase);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [TestMethod]
    public async Task Get_GetToDoItemById_ReturnsNotFound()
    {
        // Arrange
        int nonExistentId = 1;
        string requestUri = $"{_requestUriBase}/{nonExistentId}";

        // Act
        using HttpResponseMessage response = await _client.GetAsync(requestUri);

        // Assert
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [TestMethod]
    public async Task Get_GetToDoItemById_ReturnsOk()
    {
        // Arrange
        CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters.ResponseVM addedToDoItem = await CreateTodoItem();
        string requestUri = $"{_requestUriBase}/{addedToDoItem.Id}";

        // Act
        using HttpResponseMessage getResponse = await _client.GetAsync(requestUri);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
    }

    [TestMethod]
    public async Task Put_UpdateToDoItem_ReturnsNotFound()
    {
        // Arrange
        ToDoItem toDoItem = new();

        // Act
        using HttpResponseMessage getResponse = await _client.PutAsJsonAsync(_requestUriBase, toDoItem);

        // Assert
        Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    [TestMethod]
    public async Task Put_UpdateToDoItem_ReturnsNoContent()
    {
        // Arrange
        CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters.ResponseVM addedToDoItem = await CreateTodoItem();
        Assert.IsFalse(addedToDoItem.IsComplete);

        Features.ToDo.UpdateToDoItem.Adapters.RequestVM updatedToDoItem = new(addedToDoItem.Id, addedToDoItem.Name, true);

        // Act
        using HttpResponseMessage getResponse = await _client.PutAsJsonAsync(_requestUriBase, updatedToDoItem);

        // Assert
        Assert.AreEqual(HttpStatusCode.NoContent, getResponse.StatusCode);
    }

    [TestMethod]
    public async Task Delete_DeleteToDoItem_ReturnsNotFound()
    {
        // Arrange
        int nonExistentId = 1;
        string requestUri = $"{_requestUriBase}/{nonExistentId}";

        // Act
        using HttpResponseMessage getResponse = await _client.DeleteAsync(requestUri);

        // Assert
        Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    [TestMethod]
    public async Task Delete_DeleteToDoItem_ReturnsNoContent()
    {
        // Arrange
        CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters.ResponseVM addedToDoItem = await CreateTodoItem();
        string requestUri = $"{_requestUriBase}/{addedToDoItem.Id}";

        // Act
        using HttpResponseMessage getResponse = await _client.DeleteAsync(requestUri);

        // Assert
        Assert.AreEqual(HttpStatusCode.NoContent, getResponse.StatusCode);
    }

    private async Task<CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters.ResponseVM> CreateTodoItem(string? name = "", bool isComplete = false)
    {
        Features.ToDo.CreateToDoItem.Adapters.RequestVM request = new(name, isComplete);
        using HttpResponseMessage postResponse = await _client.PostAsJsonAsync(_requestUriBase, request);
        Features.ToDo.CreateToDoItem.Adapters.ResponseVM addedToDoItem = await postResponse.Content.ReadFromJsonAsync<CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters.ResponseVM>();
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
