using WikiExporter.Application.Persistence;
using WikiExporter.Application.Export;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export.Services;

/// <summary>Adapts the person persistence reader to the common export reader interface.</summary>
internal sealed class PersonReaderAdapter(IPersonExportReader reader) : Adapter<PersonExportData>(reader.GetAsync, reader.ReadAllAsync)
{
}
