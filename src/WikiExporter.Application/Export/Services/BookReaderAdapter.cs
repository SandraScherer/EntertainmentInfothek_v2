using WikiExporter.Application.Abstractions.Persistence;
using WikiExporter.Application.Abstractions.Export;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export.Services;

/// <summary>Adapts the book persistence reader to the common export reader interface.</summary>
internal sealed class BookReaderAdapter(IBookExportReader reader) : Adapter<BookExportData>(reader.GetAsync, reader.ReadAllAsync)
{
}
