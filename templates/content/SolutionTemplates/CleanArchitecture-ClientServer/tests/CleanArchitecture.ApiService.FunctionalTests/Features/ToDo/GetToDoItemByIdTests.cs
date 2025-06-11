using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanArchitecture.ApiService.FunctionalTests.Features.ToDo;

[TestClass]
public sealed class GetToDoItemByIdTests : ToDoTestsBase
{
    public GetToDoItemByIdTests() : base("GetToDoItemByIdTestsDb")
    {
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
        ApiService.Features.ToDo.CreateToDoItem.Adapters.ResponseVM addedToDoItem = await CreateTodoItem();
        string requestUri = $"{_requestUriBase}/{addedToDoItem.Id}";

        // Act
        using HttpResponseMessage getResponse = await _client.GetAsync(requestUri);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
    }
}
