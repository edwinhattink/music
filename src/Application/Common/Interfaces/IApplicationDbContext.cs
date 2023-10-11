using Microsoft.EntityFrameworkCore;
using Music.Domain.Entities;

namespace Music.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Album> Albums { get; }

    DbSet<Artist> Artists { get; }

    DbSet<Contribution> Contributions { get; }

    DbSet<Disc> Discs { get; }

    DbSet<DiscContribution> DiscContributions { get; }

    DbSet<Genre> Genres { get; }

    DbSet<Track> Tracks { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
