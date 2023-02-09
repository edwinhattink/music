using Microsoft.EntityFrameworkCore;

namespace Music.Model.Data
{
	public class ModelContext : DbContext
	{
		public DbSet<Album> Albums { get; set; }
		public DbSet<Artist> Artists { get; set; }
		public DbSet<Contribution> Contributions { get; set; }
		public DbSet<Disc> Discs { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Track> Tracks { get; set; }
        public DbSet<DiscContribution> DiscContributions { get; set; }


		public ModelContext(DbContextOptions<ModelContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Album>().ToTable("Album");
			modelBuilder.Entity<Artist>().ToTable("Artist");
			modelBuilder.Entity<Contribution>().ToTable("Contribution");
			modelBuilder.Entity<Disc>().ToTable("Disc");
			modelBuilder.Entity<DiscContribution>().ToTable("DiscContribution");
			modelBuilder.Entity<Genre>().ToTable("Genre");
			modelBuilder.Entity<Track>().ToTable("Track");
		}
	}
}
