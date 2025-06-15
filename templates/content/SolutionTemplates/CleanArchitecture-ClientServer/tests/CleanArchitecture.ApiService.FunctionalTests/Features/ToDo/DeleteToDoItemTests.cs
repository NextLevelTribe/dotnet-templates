using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanArchitecture.ApiService.FunctionalTests.Features.ToDo;

[TestClass]
public sealed class DeleteToDoItemTests
{
    [TestMethod]
    public async Task Delete_DeleteToDoItem_ReturnsNotFound()
    {
        // Arrange
        await using ToDoTestApplication application = new(nameof(Delete_DeleteToDoItem_ReturnsNotFound));
        using HttpClient client = application.CreateClient();

        int nonExistentId = 1;
        string requestUri = $"{application.RequestUriBase}/{nonExistentId}";

        // Act
        using HttpResponseMessage getResponse = await client.DeleteAsync(requestUri);

        // Assert
        Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    [TestMethod]
    public async Task Delete_DeleteToDoItem_ReturnsNoContent()
    {
        // Arrange
        await using ToDoTestApplication application = new(nameof(Delete_DeleteToDoItem_ReturnsNotFound));
        using HttpClient client = application.CreateClient();

        ResponseVM addedToDoItem = await application.CreateTodoItem();
        string requestUri = $"{application.RequestUriBase}/{addedToDoItem.Id}";

        // Act
        using HttpResponseMessage getResponse = await client.DeleteAsync(requestUri);

        // Assert
        Assert.AreEqual(HttpStatusCode.NoContent, getResponse.StatusCode);
    }
}
