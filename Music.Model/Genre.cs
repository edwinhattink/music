﻿using System.Collections.Generic;

namespace Music.Model
{
	public class Genre
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;

		public int? ParentGenreId { get; set; }
		public Genre? ParentGenre { get; set; }

		public List<Track> Tracks { get; set; } = new List<Track>();

		public List<Genre> Genres { get; set; } = new List<Genre>();

	}
}
