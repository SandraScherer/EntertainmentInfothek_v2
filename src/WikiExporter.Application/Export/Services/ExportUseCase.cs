using Microsoft.Extensions.Logging;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Persistence;

namespace WikiExporter.Application.Export.Services;

/// <summary>Application orchestration only: select reader, load bounded data, build neutral documents and collect errors.</summary>
public sealed class ExportUseCase(IExportReaderResolver readers, IDocumentBuilderResolver builders, ILocalizedValueSelector localization, ILogger<ExportUseCase> logger) : IExportUseCase
{
    public async Task<ExportResult> ExecuteAsync(ExportRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        var reader=readers.Resolve(request.EntityType); var builder=builders.Resolve(request.EntityType);
        var docs=new List<ExportedDocument>(); var errors=new List<ExportError>(); var requested=0;
        if(request.Scope is ExportScope.Single single)
        {
            requested=1;
            var data=await reader.GetAsync(single.EntityId,ct);
            if(data is null) return new(request.EntityType,1,0,1,docs,new[]{new ExportError(single.EntityId,"The requested entity does not exist.")});
            try { docs.Add(new(data.Id,request.EntityType,builder.Build(data,request.Language))); logger.LogInformation("Exported {Type} {Id}",request.EntityType,data.Id); }
            catch(Exception ex) { logger.LogError(ex,"Failed to build {Type} {Id}",request.EntityType,data.Id); errors.Add(new(data.Id,ex.Message,ex)); }
        }
        else if(request.Scope is ExportScope.All all)
        {
            await foreach(var data in reader.ReadAllAsync(new BatchOptions(all.BatchSize),ct))
            {
                requested++;
                try { docs.Add(new(data.Id,request.EntityType,builder.Build(data,request.Language))); }
                catch(Exception ex) { logger.LogError(ex,"Failed to build {Type} {Id}",request.EntityType,data.Id); errors.Add(new(data.Id,ex.Message,ex)); }
            }
        }
        return new(request.EntityType,requested,docs.Count,errors.Count,docs,errors);
    }
}
