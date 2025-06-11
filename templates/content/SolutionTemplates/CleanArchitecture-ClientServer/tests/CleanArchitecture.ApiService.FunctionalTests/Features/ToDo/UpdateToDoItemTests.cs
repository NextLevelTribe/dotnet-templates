using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.UpdateToDoItem.Adapters;
using CleanArchitecture.Domain.ToDo.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanArchitecture.ApiService.FunctionalTests.Features.ToDo;

[TestClass]
public sealed class UpdateToDoItemTests : ToDoTestsBase
{
    public UpdateToDoItemTests() : base("UpdateToDoItemTestsDb")
    {
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
        ApiService.Features.ToDo.CreateToDoItem.Adapters.ResponseVM addedToDoItem = await CreateTodoItem();
        Assert.IsFalse(addedToDoItem.IsComplete);

        RequestVM updatedToDoItem = new(addedToDoItem.Id, addedToDoItem.Name, true);

        // Act
        using HttpResponseMessage getResponse = await _client.PutAsJsonAsync(_requestUriBase, updatedToDoItem);

        // Assert
        Assert.AreEqual(HttpStatusCode.NoContent, getResponse.StatusCode);
    }
}
