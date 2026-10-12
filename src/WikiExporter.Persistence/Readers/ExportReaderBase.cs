using Microsoft.EntityFrameworkCore.Metadata;
using WikiExporter.Application.Persistence;
using WikiExporter.Domain.Export;
using WikiExporter.Persistence.DbContext;
using WikiExporter.Persistence.Queries;

namespace WikiExporter.Persistence.Readers;

/// <summary>Represents export reader base.</summary>
internal abstract class ExportReaderBase
{
/// <summary>Stores factory for use by this component.</summary>
    private readonly IDbContextFactory<EntertainmentInfothekDbContext> _factory;
    /// <summary>Initializes the shared reader behavior with a context factory.</summary>
    /// <param name="factory">Creates database contexts for individual reader operations.</param>
    protected ExportReaderBase(IDbContextFactory<EntertainmentInfothekDbContext> factory) => _factory = factory;
/// <summary>Stores factory for use by this component.</summary>
    protected IDbContextFactory<EntertainmentInfothekDbContext> Factory => _factory;
/// <summary>Performs the size operation.</summary>
    protected static int Size(BatchOptions o) => o.NormalizedSize;
}
