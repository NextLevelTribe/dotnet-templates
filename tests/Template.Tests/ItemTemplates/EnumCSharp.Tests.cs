using Microsoft.Extensions.Logging;
using Microsoft.TemplateEngine.Authoring.TemplateVerifier;

namespace Template.Tests.ItemTemplates;

[TestClass]
public sealed class EnumCSharpTests : TestBase
{
    private const string _templateName = "nlt-enum";
    private const string _relativeTemplatePath = @"templates\content\ItemTemplates\Enum-CSharp\";

    public EnumCSharpTests() : base(_relativeTemplatePath)
    { }

    [TestMethod]
    public async Task Enum_SetName_CreatesWithCustomName()
    {
        // Arrange
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        TemplateVerifierOptions templateVerifierOptions = CreateTemplateVerifierOptions(_templateName, new[] { "-n", "MyEnum" });
        VerificationEngine engine = new(loggerFactory);

        // Act and Assert
        await engine.Execute(templateVerifierOptions).ConfigureAwait(false);
    }
}
