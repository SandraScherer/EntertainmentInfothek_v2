using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export.Services;

/// <summary>Adapts a typed persistence reader to the common application reader interface.</summary>
internal abstract class Adapter<T> : IExportReaderAdapter where T : ExportDataBase
{
    private readonly Func<string, CancellationToken, Task<T?>> _get;
    private readonly Func<BatchOptions, CancellationToken, IAsyncEnumerable<T>> _all;

    /// <summary>Initializes an adapter from single-item and batch reader delegates.</summary>
    protected Adapter(Func<string, CancellationToken, Task<T?>> get, Func<BatchOptions, CancellationToken, IAsyncEnumerable<T>> all)
    {
        _get = get;
        _all = all;
    }

    /// <inheritdoc />
    public async Task<ExportDataBase?> GetAsync(string id, CancellationToken ct) => await _get(id, ct);

    /// <inheritdoc />
    public async IAsyncEnumerable<ExportDataBase> ReadAllAsync(BatchOptions options, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct)
    {
        await foreach (var item in _all(options, ct)) yield return item;
    }
}
