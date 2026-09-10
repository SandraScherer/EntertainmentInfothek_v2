namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle Person
/// </summary>
public sealed class PersonEntity
{
    public string Id { get; set; } = string.Empty;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

     public string FullName => $"{FirstName} {LastName}".Trim();
}
