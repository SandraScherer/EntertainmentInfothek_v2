using Microsoft.EntityFrameworkCore.Metadata;
using WikiExporter.Application.Persistence;
using WikiExporter.Domain.Export;
using WikiExporter.Persistence.DbContext;
using WikiExporter.Persistence.Queries;

namespace WikiExporter.Persistence.Readers;

internal abstract class ExportReaderBase
{
    private readonly IDbContextFactory<EntertainmentInfothekDbContext> _factory;
    protected ExportReaderBase(IDbContextFactory<EntertainmentInfothekDbContext> factory) => _factory = factory;
    protected IDbContextFactory<EntertainmentInfothekDbContext> Factory => _factory;
    protected static int Size(BatchOptions o) => o.NormalizedSize;
}
