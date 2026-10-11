using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

/// <summary>Defines the i person export reader type.</summary>
public interface IPersonExportReader { Task<PersonExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<PersonExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
