using Microsoft.Extensions.Logging;
using Microsoft.TemplateEngine.Authoring.TemplateVerifier;

namespace Template.Tests.ItemTemplates;

[TestClass]
public sealed class RecordCSharpTests : TestBase
{
    private const string _templateName = "nlt-record";
    private const string _relativeTemplatePath = @"templates\content\ItemTemplates\Record-CSharp\";

    public RecordCSharpTests() : base(_relativeTemplatePath)
    { }

    [TestMethod]
    public async Task Record_SetName_CreatesWithCustomName()
    {
        // Arrange
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        TemplateVerifierOptions templateVerifierOptions = CreateTemplateVerifierOptions(_templateName, new[] { "-n", "MyRecord" });
        VerificationEngine engine = new(loggerFactory);

        // Act and Assert
        await engine.Execute(templateVerifierOptions).ConfigureAwait(false);
    }

    [TestMethod]
    public async Task Record_SetRecordTypeToStruct_CreatesRecordStruct()
    {
        // Arrange
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        TemplateVerifierOptions templateVerifierOptions = CreateTemplateVerifierOptions(_templateName, new[] { "-n", "MyRecord", "-T", "struct" });
        VerificationEngine engine = new(loggerFactory);

        // Act and Assert
        await engine.Execute(templateVerifierOptions).ConfigureAwait(false);
    }

    [TestMethod]
    public async Task Record_SetWrongRecordType_Fails()
    {
        // Arrange
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        TemplateVerifierOptions templateVerifierOptions = new(_templateName)
        {
            TemplatePath = _templatePath,
            TemplateSpecificArgs = new[] { "-n", "MyRecord", "-T", "wrongArgument" },
            DoNotPrependCallerMethodNameToScenarioName = false,
            DoNotPrependTemplateNameToScenarioName = true,
            DoNotAppendTemplateArgsToScenarioName = true,
            IsCommandExpectedToFail = true,
        };
        VerificationEngine engine = new(loggerFactory);

        // Act and Assert
        await engine.Execute(templateVerifierOptions).ConfigureAwait(false);
    }
}
