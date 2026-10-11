using Microsoft.EntityFrameworkCore.Metadata;
using WikiExporter.Application.Persistence;
using WikiExporter.Domain.Export;
using WikiExporter.Persistence.DbContext;
using WikiExporter.Persistence.Queries;

namespace WikiExporter.Persistence.Readers;

/// <summary>Defines the export reader base type.</summary>
internal abstract class ExportReaderBase
{
/// <summary>Stores the  factory value.</summary>
    private readonly IDbContextFactory<EntertainmentInfothekDbContext> _factory;
    protected ExportReaderBase(IDbContextFactory<EntertainmentInfothekDbContext> factory) => _factory = factory;
/// <summary>Stores the factory value.</summary>
    protected IDbContextFactory<EntertainmentInfothekDbContext> Factory => _factory;
/// <summary>Executes the size operation.</summary>
    protected static int Size(BatchOptions o) => o.NormalizedSize;
}
