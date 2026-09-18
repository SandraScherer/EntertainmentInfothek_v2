using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using WikiExporter.Application.Documents.Models;

namespace WikiExporter.Export.FileNames;

/// <summary>Creates deterministic, file-system-safe names. The ID hash makes title collisions impossible in normal operation.</summary>
public sealed class ExportFileNameGenerator : IExportFileNameGenerator
{
    public string Generate(MarkdownDocument document)
    {
        var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(document.EntityId))).ToLowerInvariant()[..8];
        return $"{Sanitize(document.DocumentType)}-{hash}.md";
    }

    private static string Sanitize(string value)
    {
        var invalid = new string(Path.GetInvalidFileNameChars()) + "#%&{}\\<>*?$!'\"@+`|=:/";
        var safe = Regex.Replace(value, $"[{Regex.Escape(invalid)}]", "_");
        return string.IsNullOrWhiteSpace(safe) ? "Document" : safe.Trim('.');
    }
}
