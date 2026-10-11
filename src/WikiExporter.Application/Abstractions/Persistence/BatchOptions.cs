using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

/// <summary>Bounded batch size used by all export readers.</summary>
public sealed record BatchOptions(int Size = 250)
{
/// <summary>Stores the normalized size value.</summary>
    public int NormalizedSize => Math.Clamp(Size, 1, 10_000);
}
