namespace WikiExporter.Application.DTOs;

public sealed class MovieCastDto
{
    public string Actor { get; init; } = string.Empty;

    public string Role { get; init; } = string.Empty;

    public string? OrderText { get; init; }
}
