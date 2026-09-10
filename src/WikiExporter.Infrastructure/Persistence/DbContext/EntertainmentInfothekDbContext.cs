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

    public DbSet<PersonEntity> Persons => Set<PersonEntity>();

    public DbSet<DepartmentEntity> Departments => Set<DepartmentEntity>();

    public DbSet<TextEntity> Texts => Set<TextEntity>();

    public DbSet<TextTypeEntity> TextTypes => Set<TextTypeEntity>();

    public DbSet<ImageEntity> Images => Set<ImageEntity>();

    public DbSet<WeblinkEntity> Weblinks => Set<WeblinkEntity>();

    public DbSet<StatusEntity> Statuses => Set<StatusEntity>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(EntertainmentInfothekDbContext).Assembly);
    }
}
