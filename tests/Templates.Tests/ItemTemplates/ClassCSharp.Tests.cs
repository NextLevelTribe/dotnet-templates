using Microsoft.Extensions.Logging;
using Microsoft.TemplateEngine.Authoring.TemplateVerifier;

namespace Template.Tests.ItemTemplates;

[TestClass]
public sealed class ClassCSharpTests : TestBase
{
    private const string _templateName = "nlt-class";
    private const string _templateFolderName = "Class-CSharp";

    public ClassCSharpTests() : base(_templateFolderName)
    { }

    [TestMethod]
    public async Task Class_SetName_CreatesWithCustomName()
    {
        // Arrange
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        TemplateVerifierOptions templateVerifierOptions = CreateTemplateVerifierOptions(_templateName, new[] { "-n", "MyClass" });        
        VerificationEngine engine = new(loggerFactory);

        // Act and Assert
        await engine.Execute(templateVerifierOptions).ConfigureAwait(false);
    }
}
