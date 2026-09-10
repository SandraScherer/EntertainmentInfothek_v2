namespace WikiExporter.Application.DTOs;

public sealed class MovieCrewDto
{
    public string Person { get; init; } = string.Empty;

    public string Department { get; init; } = string.Empty;

    public string Role { get; init; } = string.Empty;

    public string? OrderText { get; init; }
}
