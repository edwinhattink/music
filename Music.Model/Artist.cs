using System.Collections.Generic;

namespace Music.Model
{ 
	public class Artist
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public List<Contribution> Contributions { get; set; }

		public List<Disc> Discs { get; set; }
	}
}
