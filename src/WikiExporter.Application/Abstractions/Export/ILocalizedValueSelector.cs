using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Defines the i localized value selector type.</summary>
public interface ILocalizedValueSelector
{
    string? Select(LocalizedValue value, ExportLanguage language);
}
