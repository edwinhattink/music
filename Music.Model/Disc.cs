﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Model
{
	public class Disc
	{
		public int Id { get; set; }
		public int Number { get; set; }
		public string Name { get; set; }

		public int AlbumId { get; set; }
		public Album Album { get; set; }

		public int ArtistId { get; set; }
		public Artist Artist { get; set; }

		public List<Track> Tracks { get; set; }
	}
}
