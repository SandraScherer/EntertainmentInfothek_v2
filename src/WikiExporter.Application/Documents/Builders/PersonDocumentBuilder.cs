using System.Globalization;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Documents.Builders;

/// <summary>Represents person document builder.</summary>
public sealed class PersonDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
/// <summary>Stores entity type for use by this component.</summary>
    public ExportEntityType EntityType => ExportEntityType.Person;
/// <summary>Performs the build operation.</summary>
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

/// <summary>Performs the add person relations operation.</summary>
    private void AddPersonRelations(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language)
    {
        AddRelationList(blocks, rows, language, "Family", "Person_Family", "FamilyID", "RelationshipID");
        AddRelationList(blocks, rows, language, "Employers", "Person_Employer", "EmployerID", null);
        AddRelationList(blocks, rows, language, "Positions", "Person_Position", "PositionID", null);
        AddRelationList(blocks, rows, language, "Professions", "Person_Profession", "ProfessionID", null);
        AddRelationList(blocks, rows, language, "Species", "Person_Species", "SpeciesID", null);
    }

/// <summary>Performs the add relation list operation.</summary>
    private void AddRelationList(List<MarkdownBlock> blocks, IReadOnlyList<ExportRowData> rows, ExportLanguage language, string heading, string table, string targetField, string? relationField)
    {
        var selected = rows
            .Where(r => r.Table.Equals(table, StringComparison.Ordinal) && !string.IsNullOrWhiteSpace(Field(r, targetField)))
            .OrderBy(OrderKey)
            .ThenBy(r => r.Id, StringComparer.Ordinal)
            .ToArray();
        if (selected.Length == 0) return;
        blocks.Add(new HeadingBlock(2, heading));
        foreach (var row in selected)
        {
            var id = Field(row, targetField);
            var targetTable = targetField[..^2];
            var targetType = targetTable switch { "Family" => "Person", "Employer" => "Employer", "Position" => "Position", "Profession" => "Profession", "Species" => "Species", _ => targetTable };
            blocks.Add(new LinkBlock(ReferenceName(rows, targetType, id, language), targetType, id));
            if (relationField is not null && !string.IsNullOrWhiteSpace(Field(row, relationField))) blocks.Add(new ParagraphBlock($"Relationship: {Field(row, relationField)}"));
            var role = LocalizedField(row, language, "EnglishRole", "GermanRole"); if (!string.IsNullOrWhiteSpace(role)) blocks.Add(new ParagraphBlock(role!));
        }
    }
}
