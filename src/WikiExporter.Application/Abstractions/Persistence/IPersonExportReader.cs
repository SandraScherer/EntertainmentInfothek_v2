using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

/// <summary>Represents i person export reader.</summary>
public interface IPersonExportReader { Task<PersonExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<PersonExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
