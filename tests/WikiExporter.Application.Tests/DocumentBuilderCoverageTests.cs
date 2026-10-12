using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace WikiExporter.Application.Tests;

/// <summary>Represents document builder coverage tests.</summary>
public sealed partial class DocumentBuilderCoverageTests
{
    [Fact]
    public void AllSevenDocumentBuilders_AreRegisteredAndResolvable()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddWikiExporterApplication();
        using var provider = services.BuildServiceProvider();
        var resolver = provider.GetRequiredService<IDocumentBuilderResolver>();

        foreach (var type in Enum.GetValues<ExportEntityType>())
            Assert.Equal(type, resolver.Resolve(type).EntityType);
    }
}
