using System.Globalization;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Documents.Builders;

/// <summary>
/// Base class for the seven fachlich oriented document builders.
///
/// Persistence deliberately keeps the complete bounded export graph as rows. This class
/// turns those rows into semantic document sections. The builder therefore knows about
/// the export vocabulary (cast, crew, awards, publications, ...), but never about EF Core.
/// </summary>
public abstract class DocumentBuilderBase(ILocalizedValueSelector selector)
{
    protected ILocalizedValueSelector Selector => selector;

    protected string Title(LocalizedValue value, ExportLanguage language)
        => selector.Select(value, language) ?? "Untitled";

    protected static Dictionary<string, string?> Metadata(string type, string id, string title)
        => new(StringComparer.Ordinal) { ["type"] = type, ["id"] = id, ["title"] = title };

    protected static void AddDetails(List<MarkdownBlock> blocks, string? details)
    {
        if (string.IsNullOrWhiteSpace(details)) return;
        blocks.Add(new HeadingBlock(2, "Details"));
        blocks.Add(new ParagraphBlock(details));
    }

    protected void AddConnections(List<MarkdownBlock> blocks, ExportDataBase data, ExportLanguage language)
    {
        switch (data)
        {
            case MovieExportData movie when !string.IsNullOrWhiteSpace(movie.ConnectionId):
                AddReferenceSection(blocks, "Connection", "Connection", movie.ConnectionId!, language, data.RelatedData);
                break;
            case SeriesExportData series when !string.IsNullOrWhiteSpace(series.ConnectionId):
                AddReferenceSection(blocks, "Connection", "Connection", series.ConnectionId!, language, data.RelatedData);
                break;
            case BookExportData book when !string.IsNullOrWhiteSpace(book.ConnectionId):
                AddReferenceSection(blocks, "Connection", "Connection", book.ConnectionId!, language, data.RelatedData);
                break;
            case VideoGameExportData game when !string.IsNullOrWhiteSpace(game.ConnectionId):
                AddReferenceSection(blocks, "Connection", "Connection", game.ConnectionId!, language, data.RelatedData);
                break;
        }
    }

    private void AddReferenceSection(List<MarkdownBlock> blocks, string heading, string type, string id, ExportLanguage language, IReadOnlyList<ExportRowData> rows)
    {
        blocks.Add(new HeadingBlock(2, heading));
        blocks.Add(new LinkBlock(ReferenceName(rows, type, id, language), type, id));
    }

    /// <summary>Adds common, semantic sections shared by Movie, Series, Episode, Book and VideoGame.</summary>
    protected void AddCommonMediaSections(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language, bool includeCast = true, bool includeCrew = true)
    {
        AddCast(blocks, rows, language, includeCast);
        AddCrew(blocks, rows, language, includeCrew);
        AddAwards(blocks, rows, language);
        AddCompanyCredits(blocks, rows, language);
        AddClassifications(blocks, rows, language);
        AddDates(blocks, rows, language);
        AddMedia(blocks, rows, language);
        AddTexts(blocks, rows, language);
        AddWeblinks(blocks, rows, language);
    }

    protected void AddCast(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language, bool enabled = true)
    {
        if (!enabled) return;
        var cast = rows.Where(r => r.Table.EndsWith("_Cast", StringComparison.Ordinal)).OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
        if (cast.Length == 0) return;

        blocks.Add(new HeadingBlock(2, "Cast"));
        foreach (var row in cast)
        {
            var actor = AddPersonLink(blocks, row, "ActorID", "Actor", rows, language);
            var character = AddPersonLink(blocks, row, "CharacterID", "Character", rows, language);
            var enDubber = AddPersonLink(blocks, row, "EnglishDubberID", "English dubber", rows, language);
            var deDubber = AddPersonLink(blocks, row, "GermanDubberID", "German dubber", rows, language);
            var role = LocalizedField(row, language, "EnglishRole", "GermanRole");
            var details = Field(row, "Details");
            var prefix = string.IsNullOrWhiteSpace(role) ? "" : $" — {role}";
            if (actor is null && character is null && enDubber is null && deDubber is null && string.IsNullOrWhiteSpace(role)) continue;
            if (!string.IsNullOrWhiteSpace(prefix)) blocks.Add(new ParagraphBlock(prefix.TrimStart(' ', '—')));
            if (!string.IsNullOrWhiteSpace(details)) blocks.Add(new ParagraphBlock($"Details: {details}"));
        }
    }

    protected void AddCrew(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language, bool enabled = true)
    {
        if (!enabled) return;
        var crew = rows.Where(r => r.Table.EndsWith("_Crew", StringComparison.Ordinal)).OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
        if (crew.Length == 0) return;

        blocks.Add(new HeadingBlock(2, "Crew"));
        foreach (var row in crew)
        {
            var person = AddPersonLink(blocks, row, "PersonID", "Person", rows, language);
            var department = Field(row, "DepartmentID");
            var role = LocalizedField(row, language, "EnglishRole", "GermanRole");
            if (person is null && string.IsNullOrWhiteSpace(role) && string.IsNullOrWhiteSpace(department)) continue;
            var parts = new List<string>();
            if (!string.IsNullOrWhiteSpace(role)) parts.Add(role!);
            if (!string.IsNullOrWhiteSpace(department)) parts.Add($"Department: {department}");
            if (parts.Count > 0) blocks.Add(new ParagraphBlock(string.Join("; ", parts)));
            var details = Field(row, "Details");
            if (!string.IsNullOrWhiteSpace(details)) blocks.Add(new ParagraphBlock($"Details: {details}"));
        }
    }

    protected void AddAwards(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language)
    {
        var awards = rows.Where(r => r.Table.EndsWith("_Award", StringComparison.Ordinal) && !r.Table.EndsWith("_Award_Person", StringComparison.Ordinal))
            .OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
        if (awards.Length == 0) return;

        blocks.Add(new HeadingBlock(2, "Awards"));
        foreach (var award in awards)
        {
            blocks.Add(new HeadingBlock(3, ReferenceName(rows, "Award", Field(award, "AwardID") ?? "", language)));
            blocks.Add(new TableBlock(
                new[] { "Field", "Value" },
                NonEmptyRows(
                    ("Category", Field(award, "Category")),
                    ("Date", Field(award, "Date")),
                    ("Winner", Field(award, "Winner")),
                    ("Details", Field(award, "Details")))));

            var people = rows.Where(r => r.Table.EndsWith("_Award_Person", StringComparison.Ordinal)
                                      && string.Equals(Field(r, r.Table[..r.Table.LastIndexOf('_')] + "ID"), award.Id, StringComparison.Ordinal))
                         .OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
            // Some schema variants use Movie_AwardID / Series_AwardID / Episode_AwardID / Book_AwardID.
            if (people.Length == 0)
            {
                people = rows.Where(r => r.Table.EndsWith("_Award_Person", StringComparison.Ordinal)
                                      && r.ForeignKeys.Values.Any(v => string.Equals(v, award.Id, StringComparison.Ordinal))).OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
            }
            foreach (var person in people)
            {
                var personId = Field(person, "PersonID");
                if (string.IsNullOrWhiteSpace(personId)) continue;
                blocks.Add(new LinkBlock(ReferenceName(rows, "Person", personId, language), "Person", personId));
                var role = LocalizedField(person, language, "EnglishRole", "GermanRole");
                if (!string.IsNullOrWhiteSpace(role)) blocks.Add(new ParagraphBlock(role!));
            }
        }
    }

    protected void AddCompanyCredits(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language)
    {
        var credits = rows.Where(r => r.Table.EndsWith("_CompanyCredits", StringComparison.Ordinal))
            .OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
        if (credits.Length == 0) return;

        blocks.Add(new HeadingBlock(2, "Company Credits"));
        foreach (var row in credits)
        {
            var companyId = Field(row, "CompanyID");
            if (!string.IsNullOrWhiteSpace(companyId))
                blocks.Add(new LinkBlock(ReferenceName(rows, "Company", companyId, language), "Company", companyId));
            var role = LocalizedField(row, language, "EnglishRole", "GermanRole");
            var department = Field(row, "DepartmentID");
            var country = Field(row, "CountryID");
            var values = new List<string>();
            if (!string.IsNullOrWhiteSpace(role)) values.Add(role!);
            if (!string.IsNullOrWhiteSpace(department)) values.Add($"Department: {department}");
            if (!string.IsNullOrWhiteSpace(country)) values.Add($"Country: {country}");
            if (values.Count > 0) blocks.Add(new ParagraphBlock(string.Join("; ", values)));
        }
    }

    protected void AddClassifications(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language)
    {
        AddLookupList(blocks, rows, language, "Genres", "_Genre", "GenreID", "Genre");
        AddLookupList(blocks, rows, language, "Countries", "_Country", "CountryID", "Country");
        AddLookupList(blocks, rows, language, "Languages", "_Language", "LanguageID", "Language");
        AddLookupList(blocks, rows, language, "Certifications", "_Certification", "CertificationID", "Certification");
        AddLookupList(blocks, rows, language, "Platforms", "_Platform", "PlatformID", "Platform");
        AddLookupList(blocks, rows, language, "Settings", "_Setting", "SettingID", "Setting");
        AddLookupList(blocks, rows, language, "Perspectives", "_Perspective", "PerspectiveID", "Perspective");
    }

    protected void AddDates(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language)
    {
        var dateTables = rows.Where(r => r.Table.Contains("ReleaseDate", StringComparison.Ordinal)
                                      || r.Table.Contains("ProductionDate", StringComparison.Ordinal)
                                      || r.Table.Contains("FilmingDate", StringComparison.Ordinal)
                                      || r.Table.EndsWith("_Runtime", StringComparison.Ordinal)
                                      || r.Table.EndsWith("_FilmLength", StringComparison.Ordinal))
            .GroupBy(r => r.Table, StringComparer.Ordinal).OrderBy(g => g.Key, StringComparer.Ordinal);
        foreach (var group in dateTables)
        {
            var rowsToShow = group.OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).Select(r => new[]
            {
                Field(r,"StartDate") ?? Field(r,"ReleaseDate") ?? Field(r,"Date") ?? Field(r,"Length") ?? Field(r,"Runtime") ?? "",
                Field(r,"EndDate") ?? LocalizedField(r, language, "EnglishDescription", "GermanDescription") ?? ""
            }).Where(x => x.Any(v => !string.IsNullOrWhiteSpace(v))).ToArray();
            if (rowsToShow.Length == 0) continue;
            blocks.Add(new HeadingBlock(2, HumanizeTableName(group.Key)));
            blocks.Add(new TableBlock(new[] { "Value", "Description" }, rowsToShow));
        }
    }

    protected void AddMedia(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language)
    {
        var images = rows.Where(r => r.Table.EndsWith("_Image", StringComparison.Ordinal)).OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
        if (images.Length > 0)
        {
            blocks.Add(new HeadingBlock(2, "Images"));
            foreach (var row in images)
            {
                var imageId = Field(row, "ImageID");
                var fileName = LookupField(rows, "Image", imageId, "FileName");
                var description = LookupLocalized(rows, "Image", imageId, language, "EnglishDescription", "GermanDescription");
                blocks.Add(new ImageBlock(fileName, description, imageId));
            }
        }
    }

    protected void AddTexts(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language)
    {
        var texts = rows.Where(r => r.Table.EndsWith("_Text", StringComparison.Ordinal) && !r.Table.Equals("Publication_Text", StringComparison.Ordinal))
            .OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
        if (texts.Length == 0) return;
        blocks.Add(new HeadingBlock(2, "Texts"));
        foreach (var row in texts)
        {
            var textId = Field(row, "TextID");
            var content = LookupField(rows, "Text", textId, "Content");
            var type = Field(row, "TypeID");
            if (!string.IsNullOrWhiteSpace(type)) blocks.Add(new HeadingBlock(3, ReferenceName(rows, "TextType", type, language)));
            if (!string.IsNullOrWhiteSpace(content)) blocks.Add(new ParagraphBlock(content!));
        }
    }

    protected void AddWeblinks(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language)
    {
        var links = rows.Where(r => r.Table.EndsWith("_Weblink", StringComparison.Ordinal)).OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
        if (links.Length == 0) return;
        blocks.Add(new HeadingBlock(2, "Weblinks"));
        foreach (var row in links)
        {
            var id = Field(row, "WeblinkID");
            var url = LookupField(rows, "Weblink", id, "URL");
            var name = LookupLocalized(rows, "Weblink", id, language, "EnglishName", "GermanName") ?? url ?? id ?? "Weblink";
            if (!string.IsNullOrWhiteSpace(url)) blocks.Add(new ParagraphBlock($"{name}: {url}"));
        }
    }

    /// <summary>Book-only publication section. Publication is intentionally embedded, never exported as its own document.</summary>
    protected void AddPublications(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language)
    {
        var publications = rows.Where(r => r.Table.Equals("Publication", StringComparison.Ordinal))
            .OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
        if (publications.Length == 0) return;

        blocks.Add(new HeadingBlock(2, "Publications"));
        foreach (var publication in publications)
        {
            var title = LookupLocalizedDirect(publication, language, "EnglishTitle", "GermanTitle") ?? "Publication";
            blocks.Add(new HeadingBlock(3, title));
            blocks.Add(new TableBlock(new[] { "Field", "Value" }, NonEmptyRows(
                ("ISBN-13", Field(publication, "ISBN13")),
                ("ISBN-10", Field(publication, "ISBN10")),
                ("Edition", Field(publication, "EditionID")),
                ("Format", Field(publication, "Format")),
                ("Pages", Field(publication, "NoOfPages")),
                ("Details", Field(publication, "Details")))));

            AddPublicationChildren(blocks, rows, publication.Id, language, "Publication_Certification", "Certifications", "CertificationID", "Certification");
            AddPublicationChildren(blocks, rows, publication.Id, language, "Publication_CompanyCredits", "Company Credits", "CompanyID", "Company");
            AddPublicationChildren(blocks, rows, publication.Id, language, "Publication_Language", "Languages", "LanguageID", "Language");
            AddPublicationChildren(blocks, rows, publication.Id, language, "Publication_ReleaseDate", "Release Dates", null, null);

            var texts = rows.Where(r => r.Table.Equals("Publication_Text", StringComparison.Ordinal) && string.Equals(Field(r, "PublicationID"), publication.Id, StringComparison.Ordinal)).OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
            foreach (var text in texts)
            {
                var content = LookupField(rows, "Text", Field(text, "TextID"), "Content");
                if (!string.IsNullOrWhiteSpace(content)) blocks.Add(new ParagraphBlock(content!));
            }
        }
    }

    /// <summary>Video-game-only technical specification section, including its dependent feature tables.</summary>
    protected void AddTechnicalSpecifications(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language)
    {
        var specs = rows.Where(r => r.Table.Equals("TechnicalSpecification", StringComparison.Ordinal))
            .OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
        if (specs.Length == 0) return;

        blocks.Add(new HeadingBlock(2, "Technical Specifications"));
        foreach (var spec in specs)
        {
            blocks.Add(new HeadingBlock(3, "Specification"));
            blocks.Add(new TableBlock(new[] { "Field", "Value" }, NonEmptyRows(
                ("Platform", Field(spec, "PlatformID")),
                ("Business model", Field(spec, "BusinessModelID")),
                ("Minimum CPU", Field(spec, "MinimumCPUClassID")),
                ("Minimum OS", Field(spec, "MinimumOSClassID")),
                ("Minimum RAM", Field(spec, "MinimumRAMID")),
                ("Minimum DirectX", Field(spec, "MinimumDirectXID")),
                ("Minimum CD-ROM speed", Field(spec, "MinimumCDRomDriveSpeedID")),
                ("Minimum video RAM", Field(spec, "MinimumVideoRAMID")),
                ("Players offline", Field(spec, "NoOfPlayersOffline")),
                ("Players offline multitap", Field(spec, "NoOfPlayersOfflineMultitap")),
                ("Players online", Field(spec, "NoOfPlayersOnline")),
                ("Annotation", LocalizedField(spec, language, "EnglishAnnotation", "GermanAnnotation")),
                ("Miscellaneous", Field(spec, "MiscAttributes")),
                ("Details", Field(spec, "Details"))));

            foreach (var child in rows.Where(r => r.Table.StartsWith("TechnicalSpecification_", StringComparison.Ordinal)
                                               && string.Equals(Field(r, "TechnicalSpecificationID"), spec.Id, StringComparison.Ordinal))
                                       .GroupBy(r => r.Table, StringComparer.Ordinal).OrderBy(g => g.Key, StringComparer.Ordinal))
            {
                blocks.Add(new HeadingBlock(4, HumanizeTableName(child.Key)));
                var items = child.OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).Select(r =>
                {
                    var lookup = r.ForeignKeys.FirstOrDefault(x => x.Key.EndsWith("ID", StringComparison.Ordinal) && !x.Key.Equals("TechnicalSpecificationID", StringComparison.Ordinal)).Value;
                    return lookup ?? r.Id;
                }).ToArray();
                blocks.Add(new ListBlock(items));
            }
        }
    }

    protected static string? Field(ExportRowData row, string name)
        => row.Fields.TryGetValue(name, out var value) ? value : row.ForeignKeys.TryGetValue(name, out var fk) ? fk : null;

    protected static string? LookupField(IEnumerable<ExportRowData> rows, string table, string? id, string field)
        => rows.FirstOrDefault(r => r.Table.Equals(table, StringComparison.Ordinal) && r.Id == id)?.Fields.GetValueOrDefault(field);

    protected string? LookupLocalized(IEnumerable<ExportRowData> rows, string table, string? id, ExportLanguage language, string englishField, string germanField)
    {
        var row = rows.FirstOrDefault(r => r.Table.Equals(table, StringComparison.Ordinal) && r.Id == id);
        return row is null ? null : LocalizedField(row, language, englishField, germanField);
    }

    protected string? LocalizedField(ExportRowData row, ExportLanguage language, string englishField, string germanField)
    {
        var english = Field(row, englishField);
        var german = Field(row, germanField);
        return language switch
        {
            ExportLanguage.German => FirstNonEmpty(german, Field(row, "OriginalName"), Field(row, "OriginalTitle"), english),
            ExportLanguage.English => FirstNonEmpty(english, Field(row, "OriginalName"), Field(row, "OriginalTitle"), german),
            _ => FirstNonEmpty(Field(row, "OriginalName"), Field(row, "OriginalTitle"), english, german)
        };
    }

    protected string ReferenceName(IEnumerable<ExportRowData> rows, string table, string id, ExportLanguage language)
    {
        if (string.IsNullOrWhiteSpace(id)) return table;
        var row = rows.FirstOrDefault(r => r.Table.Equals(table, StringComparison.Ordinal) && r.Id == id);
        return row is null ? id : ReferenceName(row, language);
    }

    private string ReferenceName(ExportRowData row, ExportLanguage language)
    {
        var localized = LocalizedField(row, language, "EnglishName", "GermanName")
                        ?? LocalizedField(row, language, "EnglishTitle", "GermanTitle")
                        ?? Field(row, "Name");
        if (!string.IsNullOrWhiteSpace(localized)) return localized!;
        var first = Field(row, "FirstName");
        var last = Field(row, "LastName");
        return string.Join(' ', new[] { first, last }.Where(x => !string.IsNullOrWhiteSpace(x))).Trim() switch
        {
            { Length: > 0 } name => name,
            _ => row.Id
        };
    }

    protected string? AddPersonLink(List<MarkdownBlock> blocks, ExportRowData row, string field, string label, IReadOnlyList<ExportRowData> rows, ExportLanguage language)
    {
        var id = Field(row, field);
        if (string.IsNullOrWhiteSpace(id)) return null;
        blocks.Add(new LinkBlock($"{label}: {ReferenceName(rows, "Person", id, language)}", "Person", id));
        return id;
    }

    protected static IReadOnlyList<IReadOnlyList<string>> NonEmptyRows(params (string Name, string? Value)[] values)
        => values.Where(x => !string.IsNullOrWhiteSpace(x.Value)).Select(x => (IReadOnlyList<string>)new[] { x.Name, x.Value! }).ToArray();

    protected static string HumanizeTableName(string table)
    {
        var name = table;
        var underscore = name.LastIndexOf('_');
        if (underscore >= 0) name = name[(underscore + 1)..];
        return string.Concat(name.Select((c, i) => i > 0 && char.IsUpper(c) ? " " + c : c.ToString())).Trim();
    }

    protected static string? OrderKey(ExportRowData row) => row.Order ?? "";
    private static string? FirstNonEmpty(params string?[] values) => values.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x));
    private static string? LookupLocalizedDirect(ExportRowData row, ExportLanguage language, string english, string german)
        => language switch { ExportLanguage.German => FirstNonEmpty(Field(row, german), Field(row, "OriginalTitle"), Field(row, english)), ExportLanguage.English => FirstNonEmpty(Field(row, english), Field(row, "OriginalTitle"), Field(row, german)), _ => FirstNonEmpty(Field(row, "OriginalTitle"), Field(row, english), Field(row, german)) };

    private void AddLookupList(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language, string heading, string suffix, string fk, string lookupTable)
    {
        var selected = rows.Where(r => r.Table.EndsWith(suffix, StringComparison.Ordinal)).OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
        if (selected.Length == 0) return;
        blocks.Add(new HeadingBlock(2, heading));
        foreach (var row in selected)
        {
            var id = Field(row, fk);
            if (!string.IsNullOrWhiteSpace(id)) blocks.Add(new LinkBlock(ReferenceName(rows, lookupTable, id, language), lookupTable, id));
        }
    }

    private void AddPublicationChildren(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, string publicationId, ExportLanguage language, string table, string heading, string? lookupField, string? lookupTable)
    {
        var children = rows.Where(r => r.Table.Equals(table, StringComparison.Ordinal) && string.Equals(Field(r, "PublicationID"), publicationId, StringComparison.Ordinal)).OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
        if (children.Length == 0) return;
        blocks.Add(new HeadingBlock(4, heading));
        foreach (var child in children)
        {
            if (lookupField is not null && lookupTable is not null)
            {
                var id = Field(child, lookupField);
                if (!string.IsNullOrWhiteSpace(id)) blocks.Add(new LinkBlock(ReferenceName(rows, lookupTable, id, language), lookupTable, id));
            }
            else
            {
                var date = Field(child, "ReleaseDate");
                var description = LocalizedField(child, language, "EnglishDescription", "GermanDescription");
                blocks.Add(new ParagraphBlock(string.Join(" — ", new[] { date, description }.Where(x => !string.IsNullOrWhiteSpace(x)))));
            }
        }
    }
}

public sealed class MovieDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
    public ExportEntityType EntityType => ExportEntityType.Movie;
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage language)
    {
        var d = (MovieExportData)data; var title = Title(d.Title, language); var blocks = new List<MarkdownBlock> { new HeadingBlock(1, title) };
        AddConnections(blocks, d, language);
        blocks.Add(new HeadingBlock(2, "General"));
        blocks.Add(new TableBlock(new[] { "Field", "Value" }, NonEmptyRows(("ID", d.Id), ("Type", d.TypeId), ("Budget", d.Budget), ("Worldwide gross", d.WorldwideGross), ("Worldwide gross date", d.WorldwideGrossDate))));
        AddCommonMediaSections(blocks, d.RelatedData, language);
        AddDetails(blocks, d.Details);
        return new("Movie", d.Id, Metadata("Movie", d.Id, title), blocks);
    }
}

public sealed class SeriesDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
    public ExportEntityType EntityType => ExportEntityType.Series;
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage language)
    {
        var d = (SeriesExportData)data; var title = Title(d.Title, language); var blocks = new List<MarkdownBlock> { new HeadingBlock(1, title) };
        AddConnections(blocks, d, language);
        blocks.Add(new HeadingBlock(2, "General"));
        blocks.Add(new TableBlock(new[] { "Field", "Value" }, NonEmptyRows(("ID", d.Id), ("Type", d.TypeId), ("Seasons", d.NoOfSeasons), ("Episodes", d.NoOfEpisodes))));
        if (d.Episodes.Count > 0)
        {
            blocks.Add(new HeadingBlock(2, "Episodes"));
            foreach (var episode in d.Episodes.OrderBy(x => x.SeasonNo, StringComparer.Ordinal).ThenBy(x => x.EpisodeNo, StringComparer.Ordinal).ThenBy(x => x.Id, StringComparer.Ordinal))
                blocks.Add(new LinkBlock($"{Title(episode.Title, language)} ({episode.SeasonNo}/{episode.EpisodeNo})", "Episode", episode.Id));
        }
        AddCommonMediaSections(blocks, d.RelatedData, language);
        AddDetails(blocks, d.Details);
        return new("Series", d.Id, Metadata("Series", d.Id, title), blocks);
    }
}

public sealed class EpisodeDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
    public ExportEntityType EntityType => ExportEntityType.Episode;
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage language)
    {
        var d = (EpisodeExportData)data; var title = Title(d.Title, language); var blocks = new List<MarkdownBlock> { new HeadingBlock(1, title) };
        if (!string.IsNullOrWhiteSpace(d.SeriesId)) { blocks.Add(new HeadingBlock(2, "Series")); blocks.Add(new LinkBlock(ReferenceName(d.RelatedData, "Series", d.SeriesId!, language), "Series", d.SeriesId!)); }
        blocks.Add(new HeadingBlock(2, "Episode Information"));
        blocks.Add(new TableBlock(new[] { "Field", "Value" }, NonEmptyRows(("ID", d.Id), ("Season", d.SeasonNo), ("Episode", d.EpisodeNo))));
        AddCommonMediaSections(blocks, d.RelatedData, language);
        AddDetails(blocks, d.Details);
        return new("Episode", d.Id, Metadata("Episode", d.Id, title), blocks);
    }
}

public sealed class BookDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
    public ExportEntityType EntityType => ExportEntityType.Book;
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage language)
    {
        var d = (BookExportData)data; var title = Title(d.Title, language); var blocks = new List<MarkdownBlock> { new HeadingBlock(1, title) };
        AddConnections(blocks, d, language);
        blocks.Add(new HeadingBlock(2, "General"));
        blocks.Add(new TableBlock(new[] { "Field", "Value" }, NonEmptyRows(("ID", d.Id), ("Type", d.TypeId))));
        AddCommonMediaSections(blocks, d.RelatedData, language);
        AddPublications(blocks, d.RelatedData, language);
        AddDetails(blocks, d.Details);
        return new("Book", d.Id, Metadata("Book", d.Id, title), blocks);
    }
}

public sealed class VideoGameDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
    public ExportEntityType EntityType => ExportEntityType.VideoGame;
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage language)
    {
        var d = (VideoGameExportData)data; var title = Title(d.Title, language); var blocks = new List<MarkdownBlock> { new HeadingBlock(1, title) };
        AddConnections(blocks, d, language);
        blocks.Add(new HeadingBlock(2, "General"));
        blocks.Add(new TableBlock(new[] { "Field", "Value" }, NonEmptyRows(("ID", d.Id), ("Type", d.TypeId), ("Budget", d.Budget), ("Worldwide gross", d.WorldwideGross), ("Worldwide gross date", d.WorldwideGrossDate))));
        AddTechnicalSpecifications(blocks, d.RelatedData, language);
        AddCommonMediaSections(blocks, d.RelatedData, language);
        AddDetails(blocks, d.Details);
        return new("VideoGame", d.Id, Metadata("VideoGame", d.Id, title), blocks);
    }
}

public sealed class PersonDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
    public ExportEntityType EntityType => ExportEntityType.Person;
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage language)
    {
        var d = (PersonExportData)data; var title = Title(d.Name, language); var blocks = new List<MarkdownBlock> { new HeadingBlock(1, title) };
        blocks.Add(new HeadingBlock(2, "Personal Data"));
        blocks.Add(new TableBlock(new[] { "Field", "Value" }, NonEmptyRows(("ID", d.Id), ("Birth name", d.BirthName), ("Date of birth", d.DateOfBirth), ("Date of death", d.DateOfDeath), ("Gender", d.GenderId), ("Height", d.Height), ("Type", d.TypeId))));
        var cause = language == ExportLanguage.German ? d.GermanCauseOfDeath : d.EnglishCauseOfDeath;
        if (!string.IsNullOrWhiteSpace(cause)) { blocks.Add(new HeadingBlock(2, "Cause of Death")); blocks.Add(new ParagraphBlock(cause!)); }
        AddPersonRelations(blocks, d.RelatedData, language);
        AddMedia(blocks, d.RelatedData, language); AddTexts(blocks, d.RelatedData, language); AddWeblinks(blocks, d.RelatedData, language);
        AddDetails(blocks, d.Details);
        return new("Person", d.Id, Metadata("Person", d.Id, title), blocks);
    }

    private void AddPersonRelations(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language)
    {
        AddRelationList(blocks, rows, language, "Family", "Person_Family", "FamilyID", "RelationshipID");
        AddRelationList(blocks, rows, language, "Employers", "Person_Employer", "EmployerID", null);
        AddRelationList(blocks, rows, language, "Positions", "Person_Position", "PositionID", null);
        AddRelationList(blocks, rows, language, "Professions", "Person_Profession", "ProfessionID", null);
        AddRelationList(blocks, rows, language, "Species", "Person_Species", "SpeciesID", null);
    }

    private void AddRelationList(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language, string heading, string table, string targetField, string? relationField)
    {
        var selected = rows.Where(r => r.Table.Equals(table, StringComparison.Ordinal)).OrderBy(OrderKey).ThenBy(r => r.Id, StringComparer.Ordinal).ToArray();
        if (selected.Length == 0) return;
        blocks.Add(new HeadingBlock(2, heading));
        foreach (var row in selected)
        {
            var id = Field(row, targetField); if (string.IsNullOrWhiteSpace(id)) continue;
            var targetTable = targetField[..^2];
            var targetType = targetTable switch { "Family" => "Person", "Employer" => "Employer", "Position" => "Position", "Profession" => "Profession", "Species" => "Species", _ => targetTable };
            blocks.Add(new LinkBlock(ReferenceName(rows, targetType, id, language), targetType, id));
            if (relationField is not null && !string.IsNullOrWhiteSpace(Field(row, relationField))) blocks.Add(new ParagraphBlock($"Relationship: {Field(row, relationField)}"));
            var role = LocalizedField(row, language, "EnglishRole", "GermanRole"); if (!string.IsNullOrWhiteSpace(role)) blocks.Add(new ParagraphBlock(role!));
        }
    }
}

public sealed class ConnectionDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
    public ExportEntityType EntityType => ExportEntityType.Connection;
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage language)
    {
        var d = (ConnectionExportData)data; var title = Title(d.Name, language); var blocks = new List<MarkdownBlock> { new HeadingBlock(1, title) };
        if (!string.IsNullOrWhiteSpace(d.ParentConnectionId)) { blocks.Add(new HeadingBlock(2, "Parent Connection")); blocks.Add(new LinkBlock(d.ParentConnectionId!, "Connection", d.ParentConnectionId!)); }
        if (d.Children.Count > 0)
        {
            blocks.Add(new HeadingBlock(2, "Child Connections"));
            foreach (var child in d.Children.OrderBy(x => x.DisplayName ?? x.Id, StringComparer.Ordinal).ThenBy(x => x.Id, StringComparer.Ordinal)) blocks.Add(new LinkBlock(child.DisplayName ?? child.Id, "Connection", child.Id));
        }
        foreach (var group in d.Works.GroupBy(x => x.Type, StringComparer.Ordinal).OrderBy(g => g.Key, StringComparer.Ordinal))
        {
            blocks.Add(new HeadingBlock(2, group.Key));
            foreach (var work in group.OrderBy(x => Title(x.Title, language), StringComparer.Ordinal).ThenBy(x => x.Id, StringComparer.Ordinal)) blocks.Add(new LinkBlock(Title(work.Title, language), work.Type, work.Id));
        }
        AddDetails(blocks, d.Details);
        return new("Connection", d.Id, Metadata("Connection", d.Id, title), blocks);
    }
}
