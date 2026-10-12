using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Represents i localized value selector.</summary>
public interface ILocalizedValueSelector
{
    string? Select(LocalizedValue value, ExportLanguage language);
}
