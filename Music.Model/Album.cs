﻿using System.Collections.Generic;

namespace Music.Model
{
	public class Album
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;

		public int ReleaseYear { get; set; }
		public string? Image { get; set; }

		public List<Disc> Discs { get; set; } = new List<Disc>();
	}
}
