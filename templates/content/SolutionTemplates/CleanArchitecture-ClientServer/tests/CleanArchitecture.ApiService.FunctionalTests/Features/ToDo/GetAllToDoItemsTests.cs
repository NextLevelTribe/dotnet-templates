using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanArchitecture.ApiService.FunctionalTests.Features.ToDo;

[TestClass]
public sealed class GetAllToDoItemsTests
{
    [TestMethod]
    public async Task Get_GetAllTodos_ReturnsOk()
    {
        // Arrange - Act
        await using ToDoTestApplication application = new(nameof(Get_GetAllTodos_ReturnsOk));
        using HttpClient client = application.CreateClient();

        using HttpResponseMessage response = await client.GetAsync(application.RequestUriBase);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
}
