using Microsoft.EntityFrameworkCore;
using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.DbContext;

public sealed class EntertainmentInfothekDbContext
    : Microsoft.EntityFrameworkCore.DbContext
{
    public EntertainmentInfothekDbContext(
         DbContextOptions<EntertainmentInfothekDbContext> options)
        : base(options)
    {
    }

    public DbSet<MovieEntity> Movies => Set<MovieEntity>();

    public DbSet<MovieGenreEntity> MovieGenres => Set<MovieGenreEntity>();

    public DbSet<GenreEntity> Genres => Set<GenreEntity>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(EntertainmentInfothekDbContext).Assembly);
    }
}
