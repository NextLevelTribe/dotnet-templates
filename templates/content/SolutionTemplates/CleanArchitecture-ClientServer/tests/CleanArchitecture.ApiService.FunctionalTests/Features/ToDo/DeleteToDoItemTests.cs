using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanArchitecture.ApiService.FunctionalTests.Features.ToDo;

[TestClass]
public sealed class DeleteToDoItemTests : ToDoTestsBase
{
    public DeleteToDoItemTests() : base("DeleteToDoItemTestsDb")
    {
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
        ResponseVM addedToDoItem = await CreateTodoItem();
        string requestUri = $"{_requestUriBase}/{addedToDoItem.Id}";

        // Act
        using HttpResponseMessage getResponse = await _client.DeleteAsync(requestUri);

        // Assert
        Assert.AreEqual(HttpStatusCode.NoContent, getResponse.StatusCode);
    }
}
