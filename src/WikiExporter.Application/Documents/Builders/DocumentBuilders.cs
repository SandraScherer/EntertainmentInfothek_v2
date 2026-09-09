using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Documents.Builders;

public abstract class DocumentBuilderBase(ILocalizedValueSelector selector)
{
    protected string Title(LocalizedValue value, ExportLanguage language) => selector.Select(value,language) ?? "Untitled";
    protected static List<MarkdownBlock> Common(ExportDataBase d, ExportLanguage l, ILocalizedValueSelector s)
    {
        var blocks=new List<MarkdownBlock>();
        if (!string.IsNullOrWhiteSpace(d.Details)) blocks.Add(new HeadingBlock(2,"Details"));
        if (!string.IsNullOrWhiteSpace(d.Details)) blocks.Add(new ParagraphBlock(d.Details!));
        return blocks;
    }
    protected static void AddRows(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language, ILocalizedValueSelector selector)
    {
        // Generic schema rows are retained by Persistence. The builder presents them deterministically without leaking EF types.
        foreach (var group in rows.Where(r=>!string.IsNullOrWhiteSpace(r.Table)).GroupBy(r=>r.Table,StringComparer.Ordinal).OrderBy(g=>g.Key,StringComparer.Ordinal))
        {
            var visible=group.Select(r=>r.Fields.Where(p=>!string.IsNullOrWhiteSpace(p.Value)).OrderBy(p=>p.Key,StringComparer.Ordinal).Select(p=>$"{p.Key}: {p.Value}").ToArray()).Where(x=>x.Length>0).ToArray();
            if(visible.Length==0) continue;
            blocks.Add(new HeadingBlock(2, Humanize(group.Key)));
            blocks.Add(new ListBlock(visible.Select(x=>string.Join("; ",x)).ToArray()));
        }
    }
    private static string Humanize(string table)=>table.Replace('_',' ');
    protected static IReadOnlyDictionary<string,string?> Metadata(string type,string id,string title)=>new Dictionary<string,string?> { ["type"]=type,["id"]=id,["title"]=title };
}

public sealed class MovieDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
    public ExportEntityType EntityType=>ExportEntityType.Movie;
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage l) { var d=(MovieExportData)data; var t=Title(d.Title,l); var b=Common(d,l,s); b.Insert(0,new HeadingBlock(1,t)); b.Add(new HeadingBlock(2,"General")); b.Add(new TableBlock(new[]{"Field","Value"},new[]{new[]{"ID",d.Id},new[]{"Type",d.TypeId??""},new[]{"Budget",d.Budget??""},new[]{"Worldwide gross",d.WorldwideGross??""},new[]{"Worldwide gross date",d.WorldwideGrossDate??""}})); AddRows(b,d.RelatedData,l,s); return new("Movie",d.Id,Metadata("Movie",d.Id,t),b); }
}
public sealed class SeriesDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
    public ExportEntityType EntityType=>ExportEntityType.Series;
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage l) { var d=(SeriesExportData)data; var t=Title(d.Title,l); var b=Common(d,l,s); b.Insert(0,new HeadingBlock(1,t)); b.Add(new HeadingBlock(2,"General")); b.Add(new TableBlock(new[]{"Field","Value"},new[]{new[]{"ID",d.Id},new[]{"Type",d.TypeId??""},new[]{"Seasons",d.NoOfSeasons??""},new[]{"Episodes",d.NoOfEpisodes??""}})); if(d.Episodes.Count>0)b.Add(new HeadingBlock(2,"Episodes")); if(d.Episodes.Count>0)b.Add(new ListBlock(d.Episodes.OrderBy(x=>x.SeasonNo,StringComparer.Ordinal).ThenBy(x=>x.EpisodeNo,StringComparer.Ordinal).ThenBy(x=>x.Id,StringComparer.Ordinal).Select(x=>$"{Title(x.Title,l)} ({x.SeasonNo}/{x.EpisodeNo})").ToArray())); AddRows(b,d.RelatedData,l,s); return new("Series",d.Id,Metadata("Series",d.Id,t),b); }
}
public sealed class EpisodeDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
    public ExportEntityType EntityType=>ExportEntityType.Episode;
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage l) { var d=(EpisodeExportData)data; var t=Title(d.Title,l); var b=Common(d,l,s); b.Insert(0,new HeadingBlock(1,t)); b.Add(new TableBlock(new[]{"Field","Value"},new[]{new[]{"ID",d.Id},new[]{"Series ID",d.SeriesId??""},new[]{"Season",d.SeasonNo??""},new[]{"Episode",d.EpisodeNo??""}})); AddRows(b,d.RelatedData,l,s); return new("Episode",d.Id,Metadata("Episode",d.Id,t),b); }
}
public sealed class BookDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
    public ExportEntityType EntityType=>ExportEntityType.Book;
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage l) { var d=(BookExportData)data; var t=Title(d.Title,l); var b=Common(d,l,s); b.Insert(0,new HeadingBlock(1,t)); b.Add(new TableBlock(new[]{"Field","Value"},new[]{new[]{"ID",d.Id},new[]{"Type",d.TypeId??""},new[]{"Connection ID",d.ConnectionId??""}})); AddRows(b,d.RelatedData,l,s); return new("Book",d.Id,Metadata("Book",d.Id,t),b); }
}
public sealed class VideoGameDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
    public ExportEntityType EntityType=>ExportEntityType.VideoGame;
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage l) { var d=(VideoGameExportData)data; var t=Title(d.Title,l); var b=Common(d,l,s); b.Insert(0,new HeadingBlock(1,t)); b.Add(new TableBlock(new[]{"Field","Value"},new[]{new[]{"ID",d.Id},new[]{"Type",d.TypeId??""},new[]{"Budget",d.Budget??""},new[]{"Worldwide gross",d.WorldwideGross??""}})); AddRows(b,d.RelatedData,l,s); return new("VideoGame",d.Id,Metadata("VideoGame",d.Id,t),b); }
}
public sealed class PersonDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
    public ExportEntityType EntityType=>ExportEntityType.Person;
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage l) { var d=(PersonExportData)data; var t=Title(d.Name,l); var b=Common(d,l,s); b.Insert(0,new HeadingBlock(1,t)); b.Add(new TableBlock(new[]{"Field","Value"},new[]{new[]{"ID",d.Id},new[]{"Birth name",d.BirthName??""},new[]{"Date of birth",d.DateOfBirth??""},new[]{"Date of death",d.DateOfDeath??""},new[]{"Gender",d.GenderId??""},new[]{"Height",d.Height??""}})); var cause=l==ExportLanguage.German?d.GermanCauseOfDeath:d.EnglishCauseOfDeath; if(!string.IsNullOrWhiteSpace(cause)){b.Add(new HeadingBlock(2,"Cause of death"));b.Add(new ParagraphBlock(cause!));} AddRows(b,d.RelatedData,l,s); return new("Person",d.Id,Metadata("Person",d.Id,t),b); }
}
public sealed class ConnectionDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
    public ExportEntityType EntityType=>ExportEntityType.Connection;
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage l) { var d=(ConnectionExportData)data; var t=Title(d.Name,l); var b=Common(d,l,s); b.Insert(0,new HeadingBlock(1,t)); if(!string.IsNullOrWhiteSpace(d.ParentConnectionId)) b.Add(new TableBlock(new[]{"Field","Value"},new[]{new[]{"Parent connection",d.ParentConnectionId!}})); if(d.Children.Count>0){b.Add(new HeadingBlock(2,"Child connections"));b.Add(new ListBlock(d.Children.Select(x=>x.DisplayName??x.Id).ToArray()));} if(d.Works.Count>0){b.Add(new HeadingBlock(2,"Works"));b.Add(new TableBlock(new[]{"Type","Title","ID"},d.Works.Select(x=>new[]{x.Type,Title(x.Title,l),x.Id}).ToArray()));} AddRows(b,d.RelatedData,l,s); return new("Connection",d.Id,Metadata("Connection",d.Id,t),b); }
}
