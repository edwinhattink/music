using Microsoft.EntityFrameworkCore;

namespace Music.Model.Data
{
	public class ModelContext : DbContext
	{
		public DbSet<Album> Albums { get; set; }
		public DbSet<Artist> Artists { get; set; }
		public DbSet<Contribution> Contributions { get; set; }
		public DbSet<ContributionType> ContributionTypes { get; set; }
		public DbSet<Disc> Discs { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Track> Tracks { get; set; }
        public DbSet<DiscContribution> DiscContributions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=Library.db");
			base.OnConfiguring(optionsBuilder);
		}

		public ModelContext()
		{

		}
	}
}
