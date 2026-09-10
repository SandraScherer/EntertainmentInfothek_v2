using Microsoft.EntityFrameworkCore;
using WikiExporter.Application.DTOs;
using WikiExporter.Application.Interfaces;
using WikiExporter.Infrastructure.Persistence.DbContext;

namespace WikiExporter.Infrastructure.Persistence.Repositories;

/// <summary>
/// Lädt Movie-Exportdaten.
/// </summary>
public sealed class MovieRepository
    : IMovieRepository
{
    private readonly EntertainmentInfothekDbContext _db;

    public MovieRepository(
        EntertainmentInfothekDbContext db)
    {
        _db = db;
    }

    public async Task<MovieExportDto>
        GetForExportAsync(
            string movieId,
            CancellationToken cancellationToken)
    {
        var movie =
            await _db.Movies
                .AsNoTracking()
                .Where(x => x.Id == movieId)
                .Select(x =>
                    new MovieExportDto
                    {
                        Id = x.Id,
                        OriginalTitle =
                            x.OriginalTitle ?? "",
                        EnglishTitle =
                            x.EnglishTitle ?? "",
                        GermanTitle =
                            x.GermanTitle ?? "",
                        LastUpdated =
                            x.LastUpdated ?? "",

                        Genres =
                            x.Genres.Select(g =>
                                new MovieGenreDto
                                {
                                    Name =
                                        g.Genre.GermanName ??
                                        g.Genre.EnglishName ??
                                        ""
                                })
                            .ToList(),

                        Cast =
                            x.Cast.Select(c =>
                                new MovieCastDto
                                {
                                    Actor =
                                        c.Actor.FullName,
                                    Role =
                                        c.GermanRole ??
                                        c.EnglishRole ??
                                        "",
                                    Order =
                                        int.TryParse(
                                            c.Order,
                                            out var o)
                                            ? o
                                            : 0
                                })
                            .ToList(),

                        Crew =
                            x.Crew.Select(c =>
                                new MovieCrewDto
                                {
                                    Person =
                                        c.Person.FullName,

                                    Department =
                                        c.Department.GermanName ??
                                        c.Department.EnglishName ??
                                        "",

                                    Role =
                                        c.GermanRole ??
                                        c.EnglishRole ??
                                        "",

                                    Order =
                                        int.TryParse(
                                            c.Order,
                                            out var o)
                                            ? o
                                            : 0
                                })
                            .ToList(),

                         Texts =
                             x.Texts.Select(t =>
                                new MovieTextDto
                                {
                                    Content =
                                        t.Text.Content ?? "",

                                    TextType =
                                        t.TextType.GermanName ??
                                        t.TextType.EnglishName ??
                                        ""
                                })
                            .ToList(),

                        Images =
                            x.Images.Select(i =>
                                new MovieImageDto
                                {
                                    FileName =
                                        i.Image.FileName ?? "",

                                    Description =
                                        i.Image.GermanDescription ??
                                        i.Image.EnglishDescription ??
                                        ""
                                })
                            .ToList(),

                       Weblinks =
                            x.Weblinks.Select(w =>
                                new MovieWeblinkDto
                                {
                                    Name =
                                        w.Weblink.GermanName ??
                                        w.Weblink.EnglishName ??
                                        "",

                                    Url =
                                        w.Weblink.Url ?? ""
                                })
                            .ToList(),

                        Status =
                            x.Status != null
                                ? (x.Status.GermanName ??
                                    x.Status.EnglishName ??
                                    "")
                                : ""
                    })
                .SingleAsync(cancellationToken);

        return movie;
    }
}
