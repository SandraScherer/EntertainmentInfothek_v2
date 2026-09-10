namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle Department
/// </summary>
public sealed class DepartmentEntity
{
    public string Id { get; set; } = string.Empty;

    public string? EnglishName { get; set; }

    public string? GermanName { get; set; }
}
