using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CleanArchitecture.Domain.ToDo.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanArchitecture.ApiService.FunctionalTests;

[TestClass]
public sealed class ToDoTest : WebApplicationFactory<Program>
{
    private const string _requestUriBase = "/todoitems";

    private readonly HttpClient _client;

    public ToDoTest()
    {
        _client = CreateClient();
    }

    [TestMethod]
    public async Task Post_CreateTodoItem_ReturnsCreated()
    {
        // Arrange
        ToDoItem toDoItem = new()
        {
            Name = "Walk the dog",
            IsComplete = false
        };

        // Act
        using HttpResponseMessage response = await _client.PostAsJsonAsync(_requestUriBase, toDoItem);

        // Assert
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        ToDoItem? addedToDoItem = await response.Content.ReadFromJsonAsync<ToDoItem>();

        Assert.IsNotNull(addedToDoItem);
        Assert.AreNotEqual(toDoItem.Id, addedToDoItem.Id);
        Assert.AreEqual(toDoItem.Name, addedToDoItem.Name);
        Assert.AreEqual(toDoItem.IsComplete, addedToDoItem.IsComplete);
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
    public async Task Get_GetCompletedToDoItems_ReturnsOk()
    {
        // Arrange
        string requestUri = $"{_requestUriBase}/complete";

        // Act
        using HttpResponseMessage response = await _client.GetAsync(requestUri);

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
        ToDoItem toDoItem = new();
        ToDoItem addedToDoItem = await CreateTodoItem(toDoItem);
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
        int nonExistentId = 1;
        string requestUri = $"{_requestUriBase}/{nonExistentId}";
        ToDoItem toDoItem = new();

        // Act
        using HttpResponseMessage getResponse = await _client.PutAsJsonAsync(requestUri, toDoItem);

        // Assert
        Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    [TestMethod]
    public async Task Put_UpdateToDoItem_ReturnsNoContent()
    {
        // Arrange
        ToDoItem toDoItem = new() { IsComplete = false };
        ToDoItem addedToDoItem = await CreateTodoItem(toDoItem);
        string requestUri = $"{_requestUriBase}/{addedToDoItem.Id}";

        addedToDoItem.IsComplete = true;

        // Act
        using HttpResponseMessage getResponse = await _client.PutAsJsonAsync(requestUri, addedToDoItem);

        // Assert
        Assert.AreEqual(HttpStatusCode.NoContent, getResponse.StatusCode);
        Assert.IsTrue(addedToDoItem.IsComplete);
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
        ToDoItem toDoItem = new();
        ToDoItem addedToDoItem = await CreateTodoItem(toDoItem);
        string requestUri = $"{_requestUriBase}/{addedToDoItem.Id}";

        // Act
        using HttpResponseMessage getResponse = await _client.DeleteAsync(requestUri);

        // Assert
        Assert.AreEqual(HttpStatusCode.NoContent, getResponse.StatusCode);
    }

    private async Task<ToDoItem> CreateTodoItem(ToDoItem toDoItem)
    {
        using HttpResponseMessage postResponse = await _client.PostAsJsonAsync(_requestUriBase, toDoItem);
        ToDoItem? addedToDoItem = await postResponse.Content.ReadFromJsonAsync<ToDoItem>();
        Assert.IsNotNull(addedToDoItem);

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
