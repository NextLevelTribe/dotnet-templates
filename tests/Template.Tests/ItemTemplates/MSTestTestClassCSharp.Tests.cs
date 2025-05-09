using Microsoft.Extensions.Logging;
using Microsoft.TemplateEngine.Authoring.TemplateVerifier;

namespace Template.Tests.ItemTemplates;

[TestClass]
public sealed class MSTestTestClassCSharpTests : TestBase
{
    private const string _templateName = "nlt-mstest-class";
    private const string _templateFolderName = "MSTest-TestClass-CSharp";

    public MSTestTestClassCSharpTests() : base(_templateFolderName)
    { }

    [TestMethod]
    public async Task MSTestClass_SetName_CreatesWithCustomName()
    {
        // Arrange
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        TemplateVerifierOptions templateVerifierOptions = CreateTemplateVerifierOptions(_templateName, new[] { "-n", "MyTest" });
        VerificationEngine engine = new(loggerFactory);

        // Act and Assert
        await engine.Execute(templateVerifierOptions).ConfigureAwait(false);
    }
}
