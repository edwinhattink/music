using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Model
{
	public class Disc
	{
		public int Id { get; set; }
		public int Number { get; set; }

		public int AlbumId { get; set; }
		public Album Album { get; set; }

		public List<DiscContribution> DiscContributions { get; set; }

		public List<Track> Tracks { get; set; }
	}
}
