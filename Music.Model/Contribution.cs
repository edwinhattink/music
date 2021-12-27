namespace Music.Model
{
	public class Contribution
	{
		public int Id { get; set; }

		public int TrackId { get; set; }
		public Track Track { get; set; }

		public int ArtistId { get; set; }
		public Artist Artist { get; set; }

		public int ContributionTypeId { get; set; }
		public ContributionType ContributionType { get; set; }
	}
}
