using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanArchitecture.ApiService.FunctionalTests.Features.ToDo;

[TestClass]
public sealed class GetAllToDoItemsTests : ToDoTestsBase
{
    public GetAllToDoItemsTests() : base("GetAllToDoItemsTestsDb")
    {
    }

    [TestMethod]
    public async Task Get_GetAllTodos_ReturnsOk()
    {
        // Arrange - Act
        using HttpResponseMessage response = await _client.GetAsync(_requestUriBase);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
}
