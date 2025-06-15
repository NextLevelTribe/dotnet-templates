using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanArchitecture.ApiService.FunctionalTests.Features.ToDo;

[TestClass]
public sealed class CreateToDoItemTests
{
    [TestMethod]
    public async Task Post_CreateTodoItem_ReturnsCreated()
    {
        // Arrange
        await using ToDoTestApplication application = new(nameof(Post_CreateTodoItem_ReturnsCreated));
        using HttpClient client = application.CreateClient();

        RequestVM requestVM = new()
        {
            Name = "Walk the dog",
            IsComplete = false
        };

        // Act
        using HttpResponseMessage response = await client.PostAsJsonAsync(application.RequestUriBase, requestVM);

        // Assert
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        ResponseVM responseVM = await response.Content.ReadFromJsonAsync<ResponseVM>();

        Assert.AreNotEqual(0, responseVM.Id);
        Assert.AreEqual(requestVM.Name, responseVM.Name);
        Assert.AreEqual(requestVM.IsComplete, responseVM.IsComplete);
    }
}
