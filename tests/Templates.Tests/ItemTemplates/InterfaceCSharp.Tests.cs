using Microsoft.Extensions.Logging;
using Microsoft.TemplateEngine.Authoring.TemplateVerifier;

namespace Template.Tests.ItemTemplates;

[TestClass]
public sealed class InterfaceCSharpTests : TestBase
{
    private const string _templateName = "nlt-interface";
    private const string _templateFolderName = "Interface-CSharp";

    public InterfaceCSharpTests() : base(_templateFolderName)
    { }

    [TestMethod]
    public async Task Interface_SetName_CreatesWithCustomName()
    {
        // Arrange
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        TemplateVerifierOptions templateVerifierOptions = CreateTemplateVerifierOptions(_templateName, new[] { "-n", "MyInterface" });
        VerificationEngine engine = new(loggerFactory);

        // Act and Assert
        await engine.Execute(templateVerifierOptions).ConfigureAwait(false);
    }
}
