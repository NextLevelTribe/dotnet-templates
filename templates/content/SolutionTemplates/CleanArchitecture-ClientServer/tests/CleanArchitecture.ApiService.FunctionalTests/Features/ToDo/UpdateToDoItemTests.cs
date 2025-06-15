using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.UpdateToDoItem.Adapters;
using CleanArchitecture.Domain.ToDo.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanArchitecture.ApiService.FunctionalTests.Features.ToDo;

[TestClass]
public sealed class UpdateToDoItemTests
{
    [TestMethod]
    public async Task Put_UpdateToDoItem_ReturnsNotFound()
    {
        // Arrange
        await using ToDoTestApplication application = new(nameof(Put_UpdateToDoItem_ReturnsNotFound));
        using HttpClient client = application.CreateClient();

        ToDoItem toDoItem = new();

        // Act
        using HttpResponseMessage getResponse = await client.PutAsJsonAsync(application.RequestUriBase, toDoItem);

        // Assert
        Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    [TestMethod]
    public async Task Put_UpdateToDoItem_ReturnsNoContent()
    {
        // Arrange
        await using ToDoTestApplication application = new(nameof(Put_UpdateToDoItem_ReturnsNoContent));
        using HttpClient client = application.CreateClient();

        ApiService.Features.ToDo.CreateToDoItem.Adapters.ResponseVM addedToDoItem = await CreateTodoItem();
        Assert.IsFalse(addedToDoItem.IsComplete);

        RequestVM updatedToDoItem = new(addedToDoItem.Id, addedToDoItem.Name, true);

        // Act
        using HttpResponseMessage getResponse = await client.PutAsJsonAsync(application.RequestUriBase, updatedToDoItem);

        // Assert
        Assert.AreEqual(HttpStatusCode.NoContent, getResponse.StatusCode);
    }
}
