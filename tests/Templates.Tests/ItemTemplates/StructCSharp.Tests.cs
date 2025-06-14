using Microsoft.Extensions.Logging;
using Microsoft.TemplateEngine.Authoring.TemplateVerifier;

namespace Template.Tests.ItemTemplates;

[TestClass]
public sealed class StructCSharpTests : TestBase
{
    private const string _templateName = "nlt-struct";
    private const string _templateFolderName = "Struct-CSharp";

    public StructCSharpTests() : base(_templateFolderName)
    { }

    [TestMethod]
    public async Task Struct_SetName_CreatesWithCustomName()
    {
        // Arrange
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        TemplateVerifierOptions templateVerifierOptions = CreateTemplateVerifierOptions(_templateName, new[] { "-n", "MyStruct" });
        VerificationEngine engine = new(loggerFactory);

        // Act and Assert
        await engine.Execute(templateVerifierOptions).ConfigureAwait(false);
    }
}
