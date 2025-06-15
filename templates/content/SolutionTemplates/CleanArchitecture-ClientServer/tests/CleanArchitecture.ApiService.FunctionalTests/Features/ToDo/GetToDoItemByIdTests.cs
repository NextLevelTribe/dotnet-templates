using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanArchitecture.ApiService.FunctionalTests.Features.ToDo;

[TestClass]
public sealed class GetToDoItemByIdTests
{
    [TestMethod]
    public async Task Get_GetToDoItemById_ReturnsNotFound()
    {
        // Arrange
        await using ToDoTestApplication application = new(nameof(Get_GetToDoItemById_ReturnsNotFound));
        using HttpClient client = application.CreateClient();

        int nonExistentId = 1;
        string requestUri = $"{application.RequestUriBase}/{nonExistentId}";

        // Act
        using HttpResponseMessage response = await client.GetAsync(requestUri);

        // Assert
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [TestMethod]
    public async Task Get_GetToDoItemById_ReturnsOk()
    {
        // Arrange
        await using ToDoTestApplication application = new(nameof(Get_GetToDoItemById_ReturnsOk));
        using HttpClient client = application.CreateClient();

        ApiService.Features.ToDo.CreateToDoItem.Adapters.ResponseVM addedToDoItem = await application.CreateTodoItem();
        string requestUri = $"{application.RequestUriBase}/{addedToDoItem.Id}";

        // Act
        using HttpResponseMessage getResponse = await client.GetAsync(requestUri);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
    }
}
