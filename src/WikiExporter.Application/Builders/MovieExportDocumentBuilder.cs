using WikiExporter.Application.Documents;
using WikiExporter.Application.DTOs;
using WikiExporter.Application.Interfaces;
using WikiExporter.Application.Models;
using WikiExporter.Application.Services;

namespace WikiExporter.Application.Builders;

/// <summary>
/// Erstellt ein generisches ExportDocument aus einem MovieExportDto.
/// </summary>
public sealed class MovieExportDocumentBuilder
    : IMovieExportDocumentBuilder
{
    public ExportDocument Build(
        MovieExportDto dto,
        string language)
    {
        var title = ResolveTitle(dto, language);

        var document = new ExportDocument
        {
            Id = dto.Id,
            Title = title,
            Slug = SlugGenerator.Create(title),
            Language = language,
            EntityType = ExportEntityType.Movie,
            Metadata = CreateMetadata(dto)
        };

        AddGeneralSection(document, dto);

        AddGenreSection(document, dto);

        AddStorySection(document, dto);

        AddCastSection(document, dto);

        AddCrewSection(document, dto);

        AddImagesSection(document, dto);

        AddLinksSection(document, dto);

        return document;
    }

    private static string ResolveTitle(
        MovieExportDto dto,
        string language)
    {
        if (language.StartsWith("de"))
        {
            return FirstNotEmpty(
                dto.GermanTitle,
                dto.OriginalTitle,
                dto.EnglishTitle);
        }

        return FirstNotEmpty(
            dto.EnglishTitle,
            dto.OriginalTitle,
            dto.GermanTitle);
    }

    private static string FirstNotEmpty(
        params string[] values)
    {
        return values.FirstOrDefault(
                v => !string.IsNullOrWhiteSpace(v))
            ?? "Unknown";
    }

    private static ExportMetadata CreateMetadata(
        MovieExportDto dto)
    {
        return new ExportMetadata
        {
            SourceTable = "Movie",
            Status = dto.Status,
            LastUpdated = dto.LastUpdated,
            Tags = dto.Genres
                .Select(g => g.Name)
                .Distinct()
                .ToList()
        };
    }

    private static void AddGeneralSection(
        ExportDocument document,
        MovieExportDto dto)
    {
        var table = new TableBlock
        {
            Headers =
            {
                "Feld",
                "Wert"
            },
            Rows =
            {
                new List<string>
                {
                    "Originaltitel",
                    dto.OriginalTitle
                },
                new List<string>
                {
                    "Englischer Titel",
                    dto.EnglishTitle
                },
                new List<string>
                {
                    "Deutscher Titel",
                    dto.GermanTitle
                },
                new List<string>
                {
                    "Status",
                    dto.Status
                }
            }
        };

        document.Sections.Add(
            new ExportSection
            {
                Title = "Allgemein",
                Order = 1,
                Blocks =
                {
                    table
                }
            });
    }

    private static void AddGenreSection(
        ExportDocument document,
        MovieExportDto dto)
    {
        if (!dto.Genres.Any())
        {
            return;
        }

        document.Sections.Add(
            new ExportSection
            {
                Title = "Genres",
                Order = 2,
                Blocks =
                {
                    new ListBlock
                    {
                        Items = dto.Genres
                            .Select(g => g.Name)
                            .Distinct()
                            .ToList()
                    }
                }
            });
    }

    private static void AddStorySection(
        ExportDocument document,
        MovieExportDto dto)
    {
        var texts =
            dto.Texts
                .Where(x =>
                      !string.IsNullOrWhiteSpace(
                        x.Content))
                .ToList();

        if (!texts.Any())
        {
            return;
        }

        var section =
            new ExportSection
            {
                Title = "Handlung",
                Order = 3
            };

        foreach (var text in texts)
        {
            section.Blocks.Add(
                new TextBlock
                {
                    Text = text.Content
                });
        }

        document.Sections.Add(section);
    }

    private static void AddCastSection(
        ExportDocument document,
        MovieExportDto dto)
    {
        if (!dto.Cast.Any())
        {
            return;
        }

        var table = new TableBlock
        {
            Headers =
            {
                "Darsteller",
                "Rolle"
            }
        };

        foreach (var item
                in dto.Cast.OrderBy(x => x.Order))
        {
            table.Rows.Add(
                new List<string>
                {
                    item.Actor,
                    item.Role
                });
        }

        document.Sections.Add(
            new ExportSection
            {
                Title = "Besetzung",
                Order = 4,
                Blocks =
                {
                    table
                }
            });
    }

    private static void AddCrewSection(
        ExportDocument document,
        MovieExportDto dto)
    {
        if (!dto.Crew.Any())
        {
            return;
        }

        var table = new TableBlock
        {
            Headers =
            {
                "Person",
                "Abteilung",
                "Rolle"
            }
        };

        foreach (var item
                 in dto.Crew.OrderBy(x => x.Order))
        {
            table.Rows.Add(
                new List<string>
                {
                    item.Person,
                    item.Department,
                    item.Role
                });
        }

        document.Sections.Add(
            new ExportSection
            {
                Title = "Crew",
                Order = 5,
                Blocks =
                {
                    table
                }
            });
    }

    private static void AddImagesSection(
        ExportDocument document,
        MovieExportDto dto)
    {
        if (!dto.Images.Any())
        {
            return;
        }

        var section =
            new ExportSection
            {
                Title = "Bilder",
                Order = 6
            };

        foreach (var image in dto.Images)
        {
            section.Blocks.Add(
                new ImageBlock
                {
                    FileName = image.FileName,
                    Caption = image.Description
                });
        }

        document.Sections.Add(section);
    }

    private static void AddLinksSection(
        ExportDocument document,
        MovieExportDto dto)
    {
        if (!dto.Weblinks.Any())
        {
            return;
        }

        var section =
            new ExportSection
            {
                Title = "Weblinks",
                Order = 7
            };

        foreach (var link in dto.Weblinks)
        {
            section.Blocks.Add(
                new LinkBlock
                {
                    Text = link.Name,
                    Url = link.Url
                });
        }

        document.Sections.Add(section);
    }
}
