namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle Movie_Crew
/// </summary>
public sealed class MovieCrewEntity
{
    public string Id { get; set; } = string.Empty;

    public string? MovieId { get; set; }

    public MovieEntity Movie { get; set; } = null!;

    public string? PersonId { get; set; }

    public PersonEntity Person { get; set; } = null!;

    public string? DepartmentId { get; set; }

    public DepartmentEntity Department { get; set; } = null!;

    public string? EnglishRole { get; set; }

    public string? GermanRole { get; set; }

    public string? Order { get; set; }
}
