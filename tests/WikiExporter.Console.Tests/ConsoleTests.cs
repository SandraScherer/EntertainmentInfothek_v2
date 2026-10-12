using Microsoft.Extensions.DependencyInjection;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Console.Configuration;
using WikiExporter.ConsoleApp;

namespace WikiExporter.Console.Tests;

/// <summary>Represents console tests.</summary>
public sealed class ConsoleTests
{
    [Fact]
    public void Parser_ReadsCompleteCommandLine()
    {
        var options = CommandLineParser.Parse(new[] { "--database", "db.sqlite", "--output", "out", "--type", "Movie", "--id", "m1", "--language", "German", "--format", "DokuWiki", "--batch-size", "50" });
        Assert.Equal("db.sqlite", options.DatabasePath);
        Assert.Equal("out", options.OutputDirectory);
        Assert.Equal(ExportEntityType.Movie, options.EntityType);
        Assert.Equal("m1", options.EntityId);
        Assert.Equal(ExportLanguage.German, options.Language);
        Assert.Equal(ExportFormat.DokuWiki, options.Format);
        Assert.Equal(50, options.BatchSize);
    }

    [Fact]
    public void Parser_RejectsAllAndIdTogether()
        => Assert.Throws<ArgumentException>(() => CommandLineParser.Parse(new[] { "--all", "--id", "m1" }));

    [Fact]
    public void CompositionRoot_RegistersApplicationPersistenceAndExportServices()
    {
        using var host = CompositionRoot.BuildHost(Array.Empty<string>(), Path.Combine(Path.GetTempPath(), "nonexistent", "EntertainmentInfothek.db"));
        Assert.NotNull(host.Services.GetService<WikiExporter.Application.Export.IExportUseCase>());
        Assert.NotNull(host.Services.GetService<WikiExporter.Export.Markdown.IMarkdownExportService>());
        Assert.NotNull(host.Services.GetService<WikiExporter.Application.Persistence.IMovieExportReader>());
    }


    [Fact]
    public void Parser_SupportsEqualsSyntaxAndHelpFlag()
    {
        var options = CommandLineParser.Parse(new[] { "--database=db.sqlite", "--type=Person", "--help" });
        Assert.Equal("db.sqlite", options.DatabasePath);
        Assert.Equal(ExportEntityType.Person, options.EntityType);
        Assert.True(options.Help);
    }

    [Theory]
    [InlineData("--batch-size", "0")]
    [InlineData("--batch-size", "-2")]
    [InlineData("--batch-size", "abc")]
    public void Parser_RejectsInvalidBatchSizes(string argument, string value)
        => Assert.Throws<ArgumentException>(() => CommandLineParser.Parse(new[] { argument, value }));

    [Fact]
    public void Parser_RejectsUnknownArguments()
        => Assert.Throws<ArgumentException>(() => CommandLineParser.Parse(new[] { "--unknown" }));

    [Fact]
    public void Parser_RejectsMissingValues()
        => Assert.Throws<ArgumentException>(() => CommandLineParser.Parse(new[] { "--database" }));
}
