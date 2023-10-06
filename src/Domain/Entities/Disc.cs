using System.Collections.Generic;

namespace Music.Model
{
	public class Disc
	{
		public int Id { get; set; }
		public int Number { get; set; }
		public string Name { get; set; } = string.Empty;

        public int AlbumId { get; set; }
		public Album? Album { get; set; }

		public List<DiscContribution> DiscContributions { get; set; } = new List<DiscContribution>();

		public List<Track> Tracks { get; set; } = new List<Track>();
	}
}
