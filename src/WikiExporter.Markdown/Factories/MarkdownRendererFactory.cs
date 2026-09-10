using Microsoft.Extensions.DependencyInjection;

using WikiExporter.Application.Interfaces;
using WikiExporter.Application.Models;

using WikiExporter.Markdown.Renderers;

namespace WikiExporter.Markdown.Factories;

/// <summary>
/// Erstellt passende Markdown Renderer.
/// </summary>
public sealed class MarkdownRendererFactory
    : IMarkdownRendererFactory
{
    private readonly IServiceProvider _serviceProvider;

    public MarkdownRendererFactory(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IMarkdownRenderer Create(
        ExportFormat format)
    {
        return format switch
        {
            ExportFormat.Obsidian =>
                _serviceProvider
                    .GetRequiredService<ObsidianRenderer>(),

            ExportFormat.DokuWiki =>
                _serviceProvider
                    .GetRequiredService<DokuWikiRenderer>(),

            _ =>
                throw new NotSupportedException(
                    $"Format {format} not supported.")
        };
    }
}
